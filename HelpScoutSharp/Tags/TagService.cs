using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class TagService : ServiceBase, IListableService<Tag, ListOptions>
    {
        public TagService(string accessToken)
            : base(accessToken, "tags")
        {
        }

        public async Task<IPage<Tag>> ListAsync(ListOptions options = null)
        {
            return await _client.GetAsync<TagPage>(_serviceUri, options);
        }
    }
}
