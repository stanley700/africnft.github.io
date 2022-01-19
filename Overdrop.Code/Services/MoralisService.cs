using Overdrop.Code.Data.Api.Moralis;
using Overdrop.Code.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Services
{
    public class MoralisService : IMoralisService
    {
        private IRestApiManager _restApiManager;
        public MoralisService(IRestApiManager restApiManager)
        {
            _restApiManager = restApiManager;
        }

        public async Task<MoralisNftSearchResponse> SearchNfts(MoralisNftSearchRequest request)
        {
            IDictionary<string, string> headers = new Dictionary<string, string>();
            //headers.Add("X-API-Key", "an9bzw6zzay6R26lzSwPpm0debICNEIdQ0wAzBQI");

            var url = $"https://k7hima10eexg.usemoralis.com:2053/server/functions/searchNFTs";
            var result = await _restApiManager.Send<MoralisNftSearchResponse>(HttpMethod.Post, url, request, headers);

            //var nt = new Moralis.Web3Api.Api.TokenApi("https://k7hima10eexg.usemoralis.com:2053");
            //var result1 = nt.SearchNFTs(request.Para, Moralis.Web3Api.Models.ChainList.eth, request.Format, request.Filter, limit: request.Limit);
            

            return result;
        }
    }
}
