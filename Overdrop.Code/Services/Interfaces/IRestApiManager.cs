using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Services.Interfaces
{
    public interface IRestApiManager
    {
        Task<T> Get<T>(string requestUrl, IDictionary<string, string> headers, int timeout = 0);
        Task<T> Send<T>(HttpMethod httpMethod, string requestUrl, object data, IDictionary<string, string> headers, int timeout = 0);
        Task<T> PostForm<T>(string requestUrl, IDictionary<string, string> formData = null, IDictionary<string, string> headers = null, int timeout = 0);
    }
}
