using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class RatingService_Tests
    {
        private RatingService _service;

        [TestInitialize]
        public async Task Initialize()
        {
            HelpScoutHttpClient.RateLimitBreachBehavior = RateLimitBreachBehavior.WaitAndRetryOnce;
            var authSvc = new AuthenticationService();
            var token = await authSvc.GetApplicationTokenAsync(TestHelper.ApplicationId, TestHelper.ApplicationSecret);
            _service = new RatingService(token.access_token);
        }

        [TestMethod]
        public async Task GetRatingAsync_Works()
        {
            try
            {
                //hard coded rating Id would only be found on integrating test HelpScout accout
                var rating = await _service.GetAsync(20177871);
                Assert.IsTrue(rating.id > 0);
            }
            catch (HelpScoutException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Assert.Inconclusive();
            }
        }
    }
}
