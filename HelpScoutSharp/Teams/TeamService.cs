using Flurl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class TeamService : ServiceBase, IListableService<Team, ListOptions>
    {
        public TeamService(string accessToken)
            : base(accessToken, "teams")
        {
        }

        public async Task<IPage<Team>> ListAsync(ListOptions options = null)
        {
            return await _client.GetAsync<TeamPage>(_serviceUri, options);
        }
    }
}
