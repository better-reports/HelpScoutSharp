using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class TeamService : ServiceBase
    {
        public TeamService(string accessToken)
            : base(accessToken, "teams")
        {
        }

        public async Task<ListTeamsResponse> LisTeamsAsync(ListTeamsOptions options = null)
        {
            return await _client.GetAsync<ListTeamsResponse>(_serviceUri, options);
        }

        public async Task<ListTeamMembersResponse> LisTeamMembersAsync(long teamId, ListTeamMembersOptions options = null)
        {
            return await _client.GetAsync<ListTeamMembersResponse>(new Url(_serviceUri)
                                                                        .AppendPathSegment($"{teamId}/members")
                                                                        .ToUri(), options);
        }
    }
}
