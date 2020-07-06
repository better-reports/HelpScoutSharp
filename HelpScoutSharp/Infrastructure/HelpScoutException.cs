using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HelpScoutSharp
{
    public class HelpScoutException : Exception
    {
        public HttpResponseMessage Response { get; }

        public HelpScoutException(HttpResponseMessage response)
        {
            this.Response = response;
        }
    }
}
