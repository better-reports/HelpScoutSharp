
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
            return await _client.GetAsync<CustomFieldPage>(new Url(_serviceUri)
                                                                .AppendPathSegment($"{mailboxId}/fields")
                                                                .ToUri(), options);
        }
    }
}
