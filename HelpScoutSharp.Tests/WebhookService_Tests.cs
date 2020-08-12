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
        private string[] ALL_EVENTS = @"
convo.agent.reply.created
convo.assigned
convo.created
convo.customer.reply.created
convo.deleted
convo.merged
convo.moved
convo.note.created
convo.status
convo.tags
customer.created
customer.updated
satisfaction.ratings".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        [TestInitialize]
        public async Task Initialize()
        {
            HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new WebhookService(token.access_token);
        }

        [TestMethod]
        public async Task ListWebhooksAsync_Works()
        {
            var res = await _service.ListAsync();
            Assert.IsTrue(res.page.size > 0);
        }

        [TestMethod]
        public async Task MutateWebhook_Works()
        {
            var webhookId = await _service.CreateAsync(new CreateWebhookRequest
            {
                url = "https://www.example.com",
                secret = "mySecret",
                notification = true,
                events = ALL_EVENTS,
                payloadVersion = "V2"
            });
            Assert.IsTrue(webhookId > 0);

            await _service.UpdateAsync(webhookId, new UpdateWebhookRequest
            {
                url = "https://www.google.com",
                secret = "mySecretNew",
                notification = false,
                events = ALL_EVENTS,
                payloadVersion = "V2"
            });

            await _service.DeleteAsync(webhookId);
        }
    }
}
