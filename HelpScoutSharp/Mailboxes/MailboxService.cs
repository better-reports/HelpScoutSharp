
using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class MailboxService : ServiceBase, IListableService<Mailbox, ListOptions>
    {
        public MailboxService(string accessToken)
            : base(accessToken, "mailboxes")
        {
        }

        public async Task<IPage<Mailbox>> ListAsync(ListOptions options = null)
        {
            return await _client.GetAsync<MailboxPage>(_serviceUri, options);
        }
    }
}
