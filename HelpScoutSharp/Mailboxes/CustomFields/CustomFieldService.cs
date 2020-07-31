
using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class CustomFieldService : ServiceBase, INestedListableService<CustomField, ListOptions>
    {
        public CustomFieldService(string accessToken)
            : base(accessToken, "mailboxes")
        {
        }

        public async Task<IPage<CustomField>> ListAsync(long mailboxId, ListOptions options = null)
        {
            var res = await _client.GetAsync<CustomFieldPage>(new Url(_serviceUri)
                                                                .AppendPathSegment($"{mailboxId}/fields")
                                                                .ToUri(), options);

            foreach (var i in res.entities)
                i.mailboxId = mailboxId;

            return res;
        }
    }
}
