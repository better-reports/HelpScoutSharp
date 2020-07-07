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

        [TestMethod]
        public async Task MutateWebhook_Works()
        {
            var webhookId = await _service.CreateWebhookAsync(new CreateWebhookRequest
            {
                url = "https://www.example.com",
                secret = "mySecret",
                notification = true,
                events = ALL_EVENTS
            });
            Assert.IsTrue(webhookId > 0);

            await _service.UpdateWebhookAsync(webhookId, new UpdateWebhookRequest
            {
                url = "https://www.google.com",
                secret = "mySecretNew",
                notification = false,
                events = ALL_EVENTS
            });

            await _service.DeleteWebhookAsync(webhookId);
        }

        [TestMethod]
        public void IsAuthenticWebhook_Works()
        {
            string secretKey = "MyTestKey";
            string invalidSignature = "ABC";
            string validSignature = "1O44Ikj7OBBstt+Dx+5/qhqnnHc=";
            string body = "{\"id\":350514837,\"firstName\":\"K\\u00e9vin\",\"lastName\":\"EmoJ\\ud83d\\ude03\",\"gender\":\"Unknown\",\"photoType\":\"default\",\"photoUrl\":\"https:\\/\\/d33v4339jhl8k0.cloudfront.net\\/customer-avatar\\/07.png\",\"createdAt\":\"2020-07-07T08:15:55Z\",\"updatedAt\":\"2020-07-07T08:41:59Z\",\"background\":\"\",\"_embedded\":{\"emails\":[{\"id\":471779621,\"value\":\"clement.gutel@gmail.com\",\"type\":\"work\"}],\"phones\":[],\"chats\":[],\"social_profiles\":[],\"websites\":[],\"properties\":[]},\"_links\":{\"address\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/address\\/\"},\"chats\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/chats\\/\"},\"emails\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/emails\\/\"},\"phones\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/phones\\/\"},\"social-profiles\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/social-profiles\\/\"},\"websites\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/websites\\/\"},\"self\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\"}}}";
            Assert.IsFalse(_service.IsAuthenticWebhook(secretKey, invalidSignature, body));
            Assert.IsTrue(_service.IsAuthenticWebhook(secretKey, validSignature, body));
        }
    }
}
