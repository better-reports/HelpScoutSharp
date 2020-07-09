using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class MemberService_Tests
    {
        private TeamService _teamService;
        private MemberService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _teamService = new TeamService(token.access_token);
            _service = new MemberService(token.access_token);
        }

        [TestMethod]
        public async Task LisTeamMembersAsync_Works()
        {
            var team = (await _teamService.ListAsync()).entities[0];
            var res = await _service.ListAsync(team.id);
            Assert.IsTrue(res.page.size > 0);
            Assert.IsNotNull(res.entities[0].firstName);
        }
    }
}
