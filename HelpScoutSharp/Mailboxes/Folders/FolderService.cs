
using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class FolderService : ServiceBase, INestedListableService<Folder, ListOptions>
    {
        public FolderService(string accessToken)
            : base(accessToken, "mailboxes")
        {
        }

        public async Task<IPage<Folder>> ListAsync(long mailboxId, ListOptions options = null)
        {
            var res = await _client.GetAsync<FolderPage>(new Url(_serviceUri)
                                                            .AppendPathSegment($"{mailboxId}/folders")
                                                            .ToUri(), options);
            foreach (var i in res.entities)
                i.mailboxId = mailboxId;

            return res;
        }
    }
}
