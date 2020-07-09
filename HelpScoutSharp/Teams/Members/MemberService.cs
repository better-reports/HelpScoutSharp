
using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class MemberService : ServiceBase, INestedListableService<User, ListOptions>
    {
        public MemberService(string accessToken)
            : base(accessToken, "teams")
        {
        }

        public async Task<IPage<User>> ListAsync(long teamId, ListOptions options = null)
        {
            return await _client.GetAsync<MemberPage>(new Url(_serviceUri)
                                                                .AppendPathSegment($"{teamId}/members")
                                                                .ToUri(), options);
        }
    }
}
