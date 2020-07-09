
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
            return await _client.GetAsync<FolderPage>(new Url(_serviceUri)
                                                            .AppendPathSegment($"{mailboxId}/folders")
                                                            .ToUri(), options);
        }
    }
}
