using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class WebhookService : ServiceBase
    {
        public WebhookService(string accessToken)
            : base(accessToken, "webhooks")
        {
        }


        public async Task<ListWebhooksResponse> ListWebhooksAsync()
        {
            return await _client.GetAsync<ListWebhooksResponse>(URI);
        }
    }
}
