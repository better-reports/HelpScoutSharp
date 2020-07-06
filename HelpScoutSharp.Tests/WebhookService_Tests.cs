using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class WebhookService_Tests
    {
        private WebhookService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new WebhookService(token.access_token);
        }

        [TestMethod]
        public async Task ListWebhooksAsync_Works()
        {
            var res = await _service.ListWebhooksAsync();
            Assert.IsTrue(res.page.size > 0);
        }
    }
}
