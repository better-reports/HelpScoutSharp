using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class UserService : ServiceBase, IListableService<User, ListUsersOptions>
    {
        public UserService(string accessToken)
            : base(accessToken, "users")
        {
        }

        public async Task<User> GetMeAsync()
        {
            return await _client.GetAsync<User>(new Url(_serviceUri).AppendPathSegment("me").ToUri());
        }

        public async Task<User> GetAsync(long userId)
        {
            return await _client.GetAsync<User>(new Url(_serviceUri).AppendPathSegment(userId).ToUri());
        }

        public async Task<IPage<User>> ListAsync(ListUsersOptions options = null)
        {
            return await _client.GetAsync<UserPage>(_serviceUri, options);
        }
    }
}
