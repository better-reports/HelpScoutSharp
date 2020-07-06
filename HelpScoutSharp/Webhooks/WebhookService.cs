﻿using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _client.GetAsync<ListWebhooksResponse>(_serviceUri);
        }

        public async Task<long> CreateWebhookAsync(CreateWebhookRequest request)
        {
            var response = await _client.PostAsync(_serviceUri, request);
            return long.Parse(response.Headers.GetValues("Resource-ID").First());
        }

        public async Task UpdateWebhookAsync(long webhookId, UpdateWebhookRequest request)
        {
            await _client.PutAsync(new Url(_serviceUri)
                                        .AppendPathSegment($"{webhookId}")
                                        .ToUri(), request);
        }

        public async Task DeleteWebhookAsync(long webhookId)
        {
            await _client.DeleteAsync(new Url(_serviceUri)
                                                .AppendPathSegment($"{webhookId}")
                                                .ToUri());
        }
    }
}
