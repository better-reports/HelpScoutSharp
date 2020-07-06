
using Flurl;
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
            return await _client.GetAsync<ListMailboxesResponse>(_serviceUri);
        }

        public async Task<ListMailboxCustomFieldsResponse> ListMailboxCustomFieldsAsync(long mailboxId)
        {
            return await _client.GetAsync<ListMailboxCustomFieldsResponse>(new Url(_serviceUri)
                                                                                .AppendPathSegment($"{mailboxId}/fields")
                                                                                .ToUri());
        }

        public async Task<ListMailboxFoldersResponse> ListMailboxFoldersAsync(long mailboxId)
        {
            return await _client.GetAsync<ListMailboxFoldersResponse>(new Url(_serviceUri)
                                                                                .AppendPathSegment($"{mailboxId}/folders")
                                                                                .ToUri());
        }
    }
}
