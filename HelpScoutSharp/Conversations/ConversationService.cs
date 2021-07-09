using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class ConversationService : ServiceBase, IListableService<Conversation, ListConversationsOptions>
    {
        public ConversationService(string accessToken)
            : base(accessToken, "conversations")
        {
        }

        public async Task<Conversation> GetAsync(long conversationId, GetConversationsOptions options = null)
        {
            return await _client.GetAsync<Conversation>(new Url(_serviceUri).AppendPathSegment(conversationId).ToUri(), options);
        }

        public async Task<IPage<Conversation>> ListAsync(ListConversationsOptions options = null)
        {
            return await _client.GetAsync<ConversationPage>(_serviceUri, options, url =>
            {
                //Taking control of datetime serialization because API expects a different formant that Flurl's default
                if (options?.modifiedSince != null)
                    url.SetQueryParam(nameof(ListConversationsOptions.modifiedSince), options.modifiedSince.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            });
        }

        public async Task UpdateTagsAsync(long conversationId, UpdateTagsRequest request)
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
