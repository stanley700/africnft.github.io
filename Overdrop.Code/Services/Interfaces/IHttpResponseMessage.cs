using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Overdrop.Code.Services.Interfaces
{
    public interface IHttpResponseMessage
    {
        HttpResponseMessage ResponseMessage { get; set; }
    }
}
