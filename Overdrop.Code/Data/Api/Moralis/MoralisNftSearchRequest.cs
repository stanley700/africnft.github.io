using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Data.Api.Moralis
{
    public class MoralisNftSearchRequest
    {
        [JsonProperty("q")]
        public string Para { get; set; }
        public string Chain { get; set; }
        public string Filter { get; set; } = "eth";
        public string Format { get; set; }
        public string OffSet { get; set; }
        public int Limit { get; set; }
    }
}
