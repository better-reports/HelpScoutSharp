using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class ConversationService
    {
        private readonly HelpScoutHttpClient _client;

        private readonly Uri URI = new Uri("https://api.helpscout.net/v2/conversations");

        public ConversationService(string accessToken)
        {
            _client = new HelpScoutHttpClient(accessToken);
        }

        public async Task<ListConversationsResponse> ListConversationsAsync(ListConversationsOptions options = null)
        {
            return await _client.GetAsync<ListConversationsOptions, ListConversationsResponse>(URI, options);
        }
    }
}
