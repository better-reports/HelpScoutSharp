using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class TeamService_Tests
    {
        private TeamService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new TeamService(token.access_token);
        }

        [TestMethod]
        public async Task LisTeamsAsync_Works()
        {
            var res = await _service.ListAsync();
            Assert.IsTrue(res.page.size > 0);
            Assert.IsNotNull(res._embedded.teams[0].name);
        }

        [TestMethod]
        public async Task LisTeamMembersAsync_Works()
        {
            var team = (await _service.ListAsync())._embedded.teams[0];
            var res = await _service.LisMembersAsync(team.id);
            Assert.IsTrue(res.page.size > 0);
            Assert.IsNotNull(res._embedded.users[0].firstName);
        }
    }
}
