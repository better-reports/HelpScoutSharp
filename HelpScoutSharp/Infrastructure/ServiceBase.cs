using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ServiceBase
    {
        protected readonly HelpScoutHttpClient _client;

        protected readonly Uri _serviceUri;

        public ServiceBase(string accessToken, string endpointPath)
        {
            _client = new HelpScoutHttpClient(accessToken);
            _serviceUri = new Uri($"https://api.helpscout.net/v2/{endpointPath}");
        }
    }
}
