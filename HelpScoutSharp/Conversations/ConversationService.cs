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
            return await _client.GetAsync<ListConversationsOptions, ListConversationsResponse>(URI, options);
        }
    }
}
