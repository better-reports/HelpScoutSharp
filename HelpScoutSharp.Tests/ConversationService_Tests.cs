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
            Assert.IsTrue(res._embedded.conversations.Length > 0);
        }
    }
}
