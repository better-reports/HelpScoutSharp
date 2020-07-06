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
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new UserService(token.access_token);
        }

        [TestMethod]
        public async Task ListCustomersAsync_Works()
        {
            var res = await _service.ListUsersAsync();
            Assert.IsTrue(res.page.size > 0);
        }
    }
}