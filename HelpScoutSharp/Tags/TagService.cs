using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class TagService : ServiceBase
    {
        public TagService(string accessToken)
            : base(accessToken, "tags")
        {
        }

        public async Task<ListTagsResponse> LisTagsAsync(ListUsersOptions options = null)
        {
            return await _client.GetAsync<ListTagsResponse>(_serviceUri, options);
        }
    }
}
