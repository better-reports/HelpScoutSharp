using Flurl;
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

        public async Task<Conversation> GetConversationAsync(long conversationId, GetConversationsOptions options = null)
        {
            return await _client.GetAsync<Conversation>(new Url(_serviceUri).AppendPathSegment(conversationId).ToUri(), options);
        }

        public async Task<ListConversationsResponse> ListConversationsAsync(ListConversationsOptions options = null)
        {
            return await _client.GetAsync<ListConversationsResponse>(_serviceUri, options);
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
