using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class UserService_Tests
    {
        private UserService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new UserService(token.access_token);
        }

        [TestMethod]
        public async Task ListCustomersAsync_Works()
        {
            var res = await _service.ListAsync();
            Assert.IsTrue(res.page.size > 0);
        }

        [TestMethod]
        public async Task GetMeAsync_Works()
        {
            var user = await _service.GetMeAsync();
            Assert.IsTrue(user.id > 0);
        }

        [TestMethod]
        public async Task GetUserAsync_Works()
        {
            var res = await _service.ListAsync();
            var user = await _service.GetAsync(res.entities[0].id);
            Assert.IsTrue(user.id > 0);
        }
    }
}
