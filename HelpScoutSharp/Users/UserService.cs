using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class USerService : ServiceBase
    {
        public USerService(string accessToken)
            : base(accessToken, "users")
        {
        }

        public async Task<User> GetMeAsync()
        {
            return await _client.GetAsync<User>(new Url(_serviceUri).AppendPathSegment("me").ToUri());
        }
        
        public async Task<ListUsersResponse> ListUsersAsync(ListUsersOptions options = null)
        {
            return await _client.GetAsync<ListUsersOptions, ListUsersResponse>(_serviceUri, options);
        }
    }
}
