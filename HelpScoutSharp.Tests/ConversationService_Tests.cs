using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class ConversationService_Tests
    {
        private ConversationService _service;
        private MailboxService _mailboxService;

        [TestInitialize]
        public async Task Initialize()
        {
            HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new ConversationService(token.access_token);
            _mailboxService = new MailboxService(token.access_token);
        }

        [TestMethod]
        public async Task GetConversationsAsync_Works()
        {
            var res = await _service.ListAsync();
            var conv = await _service.GetAsync(res.entities[0].id, new GetConversationsOptions { embed = "threads" });
            Assert.IsTrue(conv.id > 0);
            Assert.IsTrue(conv._embedded.threads[0].id > 0);
        }

        [TestMethod]
        public async Task ListConversationsAsync_Works()
        {
            var res = await _service.ListAsync();
            Assert.IsTrue(res.page.size > 0);
            Assert.IsTrue(res.entities.Length > 0);
            Assert.IsTrue(res.entities[0].state.Length > 0);
        }

        [TestMethod]
        public async Task ListConversationsAsync_EmbedThreads()
        {
            var res = await _service.ListAsync(new ListConversationsOptions
            {
                embed = "threads",
                status = "all"
            });
            Assert.IsTrue(res.page.size > 0);
            Assert.IsTrue(res.entities.Length > 0);
            Assert.IsTrue(res.entities[0].state.Length > 0);
            Assert.IsTrue(res.entities[0]._embedded.threads.Length > 0);
            Assert.IsTrue(res.entities[0]._embedded.threads[0].source.type.Length > 0);
        }

        [TestMethod]
        public async Task UpdateConversationTagsAsync_Works()
        {
            var conv = (await _service.ListAsync()).entities[0];

            await _service.UpdateTagsAsync(conv.id, new UpdateTagsRequest
            {
                tags = conv.tags.Select(t => t.tag).Concat(new[] { "unit-test" }).ToArray()
            });

            await _service.UpdateTagsAsync(conv.id, new UpdateTagsRequest
            {
                tags = conv.tags.Select(t => t.tag).Where(t => t != "unit-test").ToArray()
            });
        }

        [TestMethod]
        public async Task UpdateCustomFieldsAsync_Works()
        {
            var conv = (await _service.ListAsync()).entities[0];
            var mailbox = (await _mailboxService.ListAsync()).entities[0];
            var customFieldsResponse = await _mailboxService.ListCustomFieldsAsync(mailbox.id);

            if (customFieldsResponse._embedded.fields.Length == 0)
            {
                Assert.Inconclusive();
                return;
            }

            var customField = customFieldsResponse._embedded.fields[0];
            await _service.UpdateCustomFieldsAsync(conv.id, new UpdateCustomFieldsRequest
            {
                fields = new UpdateCustomFieldsRequest.CustomFieldValue[0]
            });
            await _service.UpdateCustomFieldsAsync(conv.id, new UpdateCustomFieldsRequest
            {
                fields = new[]
                {
                    new UpdateCustomFieldsRequest.CustomFieldValue
                    {
                        id = customField.id,
                        value = $"Unit test - {DateTime.UtcNow.Ticks}"
                    }
                }
            });
        }
    }
}
