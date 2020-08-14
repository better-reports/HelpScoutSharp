using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class CustomPropertyService_Tests
    {
        private CustomerPropertyService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new CustomerPropertyService(token.access_token);
        }

        [TestMethod]
        public async Task ListCustomerPropertiesAsync_Works()
        {
            var res = await _service.ListAsync();
            Assert.IsTrue(res._embedded.customer_properties.Length > 0);
        }
    }
}
