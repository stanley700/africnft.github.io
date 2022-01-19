using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Overdrop.Code.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Overdrop.Code.Services
{
    public class RestApiManager : IRestApiManager
    {
        private IConfiguration _configuration;
        public RestApiManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private int GetTimeOut(int timeout)
        {
            if(timeout == 0)
            {
                _ = int.TryParse(_configuration["DefaultRestApiTimeout"], out var defaultTimeout);

                timeout = defaultTimeout == 0 ? 60000 : defaultTimeout;
            }

            return timeout;
        }

        private static HttpClient GetHttpClient(int timeout)
        {
            HttpClient httpClient = HttpClientFactory.Create();

            httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);
            return httpClient;
        }

        public async Task<T> Get<T>(string requestUrl, IDictionary<string, string> headers, int timeout = 0)
        {
            timeout = GetTimeOut(timeout);
            var client = GetHttpClient(timeout);

            var httpRegMsg = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            httpRegMsg.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            httpRegMsg.Content = new StringContent("", Encoding.UTF8, "application/json");

            if(headers != null && headers.Any())
            {
                foreach(var header in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(header.Key))
                        client.DefaultRequestHeaders.Remove(header.Key);

                    httpRegMsg.Headers.Add(header.Key, header.Value);
                }
            }

            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);

            var response = await client.SendAsync(httpRegMsg, HttpCompletionOption.ResponseHeadersRead, cts.Token);
            var responseStr = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseStr))
                return default;

            var responseObj = JsonConvert.DeserializeObject<T>(responseStr);

            return responseObj;
        }

        public async Task<T> PostForm<T>(string requestUrl, IDictionary<string, string> formData = null, IDictionary<string, string> headers = null, int timeout = 0)
        {
            try
            {
                timeout = GetTimeOut(timeout);
                var client = GetHttpClient(timeout);

                var httpRegMsg = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                if (headers != null && headers.Any())
                {
                    foreach (var header in headers)
                    {
                        if (client.DefaultRequestHeaders.Contains(header.Key))
                            client.DefaultRequestHeaders.Remove(header.Key);

                        httpRegMsg.Headers.Add(header.Key, header.Value);
                    }
                }

                var data = "";
                data = formData.Aggregate(data, (current, input) => current + (input.Key + "=" + Uri.EscapeDataString(input.Value) + "&")).TrimEnd('&');
                httpRegMsg.Content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.SendAsync(httpRegMsg);
                var responseStr = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseStr))
                    return default;

                var responseObj = JsonConvert.DeserializeObject<T>(responseStr);

                return responseObj;
            }
            catch (Exception ex)
            {
                //Log
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        public async Task<T> Send<T>(HttpMethod httpMethod, string requestUrl, object data, IDictionary<string, string> headers, int timeout = 0)
        {
            timeout = GetTimeOut(timeout);
            var client = GetHttpClient(timeout);

            var httpRegMsg = new HttpRequestMessage(httpMethod, requestUrl);
            httpRegMsg.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var serializationSetting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonData = JsonConvert.SerializeObject(data, serializationSetting);

            httpRegMsg.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    if (client.DefaultRequestHeaders.Contains(header.Key))
                        client.DefaultRequestHeaders.Remove(header.Key);

                    httpRegMsg.Headers.Add(header.Key, header.Value);
                }
            }

            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeout);

            var response = await client.SendAsync(httpRegMsg, HttpCompletionOption.ResponseHeadersRead, cts.Token);
            var responseStr = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseStr))
                return SetHttpResponseMessageOnResponseObject(default(T), response);

            var responseObj = JsonConvert.DeserializeObject<T>(responseStr);

            return SetHttpResponseMessageOnResponseObject(responseObj, response);
        }

        private T SetHttpResponseMessageOnResponseObject<T>(T responseObject, HttpResponseMessage responseMessage)
        {
            if(responseObject == null)
            {
                responseObject = Activator.CreateInstance<T>();
            }

            try
            {
                var type = typeof(T);
                if(!type.GetInterfaces().Contains(typeof(IHttpResponseMessage)))
                {
                    return responseObject;
                }

                var prop = responseObject.GetType().GetProperty(nameof(IHttpResponseMessage.ResponseMessage), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if(prop != null && prop.CanWrite)
                {
                    prop.SetValue(responseObject, responseMessage);
                }
            }
            catch (Exception ex)
            {
                //Log
            }

            return responseObject;
        }
    }
}
