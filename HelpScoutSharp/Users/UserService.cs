using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class UserService : ServiceBase
    {
        public UserService(string accessToken)
            : base(accessToken, "users")
        {
        }


        public async Task<ListUsersResponse> ListUsersAsync(ListUsersOptions options = null)
        {
            return await _client.GetAsync<ListUsersOptions, ListUsersResponse>(URI, options);
        }
    }
}
