﻿using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class ConversationService : ServiceBase
    {
        public ConversationService(string accessToken) 
            : base(accessToken, "conversations")
        {
        }

        public async Task<ListConversationsResponse> ListConversationsAsync(ListConversationsOptions options = null)
        {
            return await _client.GetAsync<ListConversationsOptions, ListConversationsResponse>(_serviceUri, options);
        }

        public async Task UpdateConversationTagsAsync(long conversationId, UpdateTagsRequest request)
        {
            await _client.PutAsync(new Url(_serviceUri)
                                                     .AppendPathSegment($"{conversationId}/tags")
                                                     .ToUri(), request);
        }

        public async Task UpdateCustomFieldsAsync(long conversationId, UpdateCustomFieldsRequest request)
        {
            await _client.PutAsync(new Url(_serviceUri)
                                                     .AppendPathSegment($"{conversationId}/fields")
                                                     .ToUri(), request);
        }
    }
}
