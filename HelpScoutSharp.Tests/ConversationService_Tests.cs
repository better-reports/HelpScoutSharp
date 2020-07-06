using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class ConversationService_Tests
    {
        private ConversationService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new ConversationService(token.access_token);
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
    }
}
