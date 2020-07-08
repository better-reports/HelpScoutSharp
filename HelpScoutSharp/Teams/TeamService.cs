using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class TeamService : ServiceBase, IListableService<Team, ListTeamsOptions>
    {
        public TeamService(string accessToken)
            : base(accessToken, "teams")
        {
        }

        public async Task<IPage<Team>> ListAsync(ListTeamsOptions options = null)
        {
            return await _client.GetAsync<TeamPage>(_serviceUri, options);
        }

        public async Task<MemberPage> LisMembersAsync(long teamId, ListTeamMembersOptions options = null)
        {
            return await _client.GetAsync<MemberPage>(new Url(_serviceUri)
                                                                        .AppendPathSegment($"{teamId}/members")
                                                                        .ToUri(), options);
        }
    }
}
