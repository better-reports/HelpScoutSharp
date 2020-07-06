using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ServiceBase
    {
        protected readonly HelpScoutHttpClient _client;

        protected readonly Uri URI;

        public ServiceBase(string accessToken, string endpointPath)
        {
            _client = new HelpScoutHttpClient(accessToken);
            URI = new Uri($"https://api.helpscout.net/v2/{endpointPath}");
        }
    }
}
