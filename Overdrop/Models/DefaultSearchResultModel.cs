using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overdrop.Models
{
    public class DefaultSearchResultModel
    {
        public List<HeaderSliderData> HeaderSliderData { get; set; }
    }

    public class HeaderSliderData
    {
        public string TokenId { get; set; }
        public string TokenAddress { get; set; }
        public string MainSliderImage { get; set; }
        public string Name { get; set; }
        public string CreatorImage { get; set; }
        public string CreatorName { get; set; }
        public string InstantPrice { get; set; }
        public string CurrentPrice { get; set; }
        public string MainPrice { get; set; }
        public string SellerName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ContractAddress { get; set; }
    }
}
