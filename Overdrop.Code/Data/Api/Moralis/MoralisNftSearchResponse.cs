using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Data.Api.Moralis
{
    public class MoralisNftSearchResponse
    {
        public SearchResult result { get; set; }
    }

    public class SearchResult
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Page_size { get; set; }
        public Result1[] Result { get; set; }
    }

    public class Result1
    {
        public string Token_Id { get; set; }
        public string Token_Address { get; set; }
        public string Token_Uri { get; set; }
        public string Metadata { get; set; }
        public MoralisNftSearchResponseMetadata DeserializedMetadata 
        { 
            get 
            {
                if (!string.IsNullOrWhiteSpace(Metadata))
                {
                    return JsonConvert.DeserializeObject<MoralisNftSearchResponseMetadata>(Metadata);
                }
                else
                    return null;
            } 
        }
        public string Contract_type { get; set; }
        public string Token_hash { get; set; }
        public string Minter_address { get; set; }
        public string Block_number_minted { get; set; }
        public string Transaction_minted { get; set; }
        public DateTime? Synced_at { get; set; }
        public DateTime? Created_at { get; set; }
    }

}
