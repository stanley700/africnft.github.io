using Overdrop.Code.Data.Api.Moralis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Services.Interfaces
{
    public interface IMoralisService
    {
        Task<MoralisNftSearchResponse> SearchNfts(MoralisNftSearchRequest request);
        
    }
}
