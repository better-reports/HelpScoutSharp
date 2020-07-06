using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class CustomerService_Tests
    {
        private CustomerService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new CustomerService(token.access_token);
        }

        [TestMethod]
        public async Task ListCustomersAsync_Works()
        {
            var res = await _service.ListCustomersAsync();
            Assert.IsTrue(res.page.size > 0);
        }
    }
}
