using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HelpScoutSharp
{
    public class HelpScoutException : Exception
    {
        public HttpResponseMessage Response { get; }

        public string ResponseContent { get; }

        public HelpScoutException(HttpResponseMessage response, string responseContent)
            : base($@"Help Scout API call failed with code: {response.StatusCode}
Reason: {response.ReasonPhrase}
Content: {responseContent}")
        {
            this.Response = response;
            this.ResponseContent = responseContent;
        }
    }
}
