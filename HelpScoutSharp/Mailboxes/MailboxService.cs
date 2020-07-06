
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class MailboxService : ServiceBase
    {
        public MailboxService(string accessToken)
            : base(accessToken, "mailboxes")
        {
        }


        public async Task<ListMailboxesResponse> ListMailboxesAsync()
        {
            return await _client.GetAsync<ListMailboxesResponse>(URI);
        }
    }
}
