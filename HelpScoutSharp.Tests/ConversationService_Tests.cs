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
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new ConversationService(token.access_token);
            _mailboxService = new MailboxService(token.access_token);
        }

        [TestMethod]
        public async Task ListConversationsAsync_Works()
        {
            var res = await _service.ListConversationsAsync();
            Assert.IsTrue(res.page.size > 0);
            Assert.IsTrue(res._embedded.conversations.Length > 0);
            Assert.IsTrue(res._embedded.conversations[0].state.Length > 0);
        }

        [TestMethod]
        public async Task ListConversationsAsync_EmbedThreads()
        {
            var res = await _service.ListConversationsAsync(new ListConversationsOptions
            {
                embed = "threads",
                status = "all"
            });
            Assert.IsTrue(res.page.size > 0);
            Assert.IsTrue(res._embedded.conversations.Length > 0);
            Assert.IsTrue(res._embedded.conversations[0].state.Length > 0);
            Assert.IsTrue(res._embedded.conversations[0]._embedded.threads.Length > 0);
            Assert.IsTrue(res._embedded.conversations[0]._embedded.threads[0].source.type.Length > 0);
        }

        [TestMethod]
        public async Task UpdateConversationTagsAsync_Works()
        {
            var conv = (await _service.ListConversationsAsync())._embedded.conversations[0];

            await _service.UpdateConversationTagsAsync(conv.id, new UpdateTagsRequest
            {
                tags = conv.tags.Select(t => t.tag).Concat(new[] { "unit-test" }).ToArray()
            });

            await _service.UpdateConversationTagsAsync(conv.id, new UpdateTagsRequest
            {
                tags = conv.tags.Select(t => t.tag).Where(t => t != "unit-test").ToArray()
            });
        }

        [TestMethod]
        public async Task UpdateCustomFieldsAsync_Works()
        {
            var conv = (await _service.ListConversationsAsync())._embedded.conversations[0];
            var mailbox = (await _mailboxService.ListMailboxesAsync())._embedded.mailboxes[0];
            var customFieldsResponse = await _mailboxService.ListMailboxCustomFieldsAsync(mailbox.id);

            if (customFieldsResponse._embedded.fields.Length == 0)
            {
                Assert.Inconclusive();
                return;
            }

            var customField = customFieldsResponse._embedded.fields[0];
            await _service.UpdateCustomFieldsAsync(conv.id, new UpdateCustomFieldsRequest
            {
                fields = new[]
                {
                    new UpdateCustomFieldsRequest.CustomFieldValue
                    {
                        id = customField.id,
                        value = $"Unit test - {DateTime.UtcNow.Ticks}"
                    }
                }.Concat(conv.customFields.Select(f => new UpdateCustomFieldsRequest.CustomFieldValue
                {
                    id = f.id,
                    value = f.value
                })).ToArray()
            });
        }
    }
}
