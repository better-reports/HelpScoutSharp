using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class AuthenticationService_Tests
    {
        private AuthenticationService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new AuthenticationService();
        }

        [TestMethod]
        public async Task GetApplicationTokenAsync_Works()
        {
            var token = await _service.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > TimeSpan.Zero);
            Assert.IsNull(token.refresh_token);
        }

        [TestMethod]
        [Ignore("Requires manual input of code")]
        public async Task GetOAuthTokenAsync_Works()
        {
            var token = await _service.GetOAuthTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret, "ENTER_CODE_HERE");
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > TimeSpan.Zero);
            Assert.IsNotNull(token.refresh_token);
        }


        [TestMethod]
        [Ignore("Requires manual input of refresh token")]
        public async Task RefreshOAuthTokenAsync_Works()
        {
            var token = await _service.RefreshOAuthTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret, "ENTER_REFRESH_TOKEN_HERE");
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > TimeSpan.Zero);
            Assert.IsNotNull(token.refresh_token);
        }
    }
}
