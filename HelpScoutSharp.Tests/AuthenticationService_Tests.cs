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
        private AuthenticationService _authenticationSvc;

        [TestInitialize]
        public void Initialize()
        {
            var services = new ServiceCollection();
            services.AddSingleton<HelpScoutHttpClient>();

            var provider = services.BuildServiceProvider();
            var client = provider.GetRequiredService<HelpScoutHttpClient>();
            _authenticationSvc = new AuthenticationService(client);
        }

        [TestMethod]
        public async Task GetApplicationTokenAsync_Works()
        {
            var token = await _authenticationSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > 0);
            Assert.IsNull(token.refresh_token);
        }

        [TestMethod]
        [Ignore("Requires manual input of code")]
        public async Task GetOAuthTokenAsync_Works()
        {
            var token = await _authenticationSvc.GetOAuthTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret, "ENTER_CODE_HERE");
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > 0);
            Assert.IsNotNull(token.refresh_token);
        }


        [TestMethod]
        [Ignore("Requires manual input of refresh token")]
        public async Task RefreshOAuthTokenAsync_Works()
        {
            var token = await _authenticationSvc.RefreshOAuthTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret, "ENTER_REFRESH_TOKEN_HERE");
            Assert.IsNotNull(token.access_token);
            Assert.IsTrue(token.expires_in > 0);
            Assert.IsNotNull(token.refresh_token);
        }
    }
}
