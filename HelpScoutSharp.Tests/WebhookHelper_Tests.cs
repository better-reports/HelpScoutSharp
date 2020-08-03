using HelpScoutSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HelpScoutSharp.Tests
{
    [TestClass]
    public class WebhookHelper_Tests
    {
        private const string customerUpdatedBody = "{\"id\":350514837,\"firstName\":\"K\\u00e9vin\",\"lastName\":\"EmoJ\\ud83d\\ude03\",\"gender\":\"Unknown\",\"photoType\":\"default\",\"photoUrl\":\"https:\\/\\/d33v4339jhl8k0.cloudfront.net\\/customer-avatar\\/07.png\",\"createdAt\":\"2020-07-07T08:15:55Z\",\"updatedAt\":\"2020-07-07T08:41:59Z\",\"background\":\"\",\"_embedded\":{\"emails\":[{\"id\":471779621,\"value\":\"clement.gutel@gmail.com\",\"type\":\"work\"}],\"phones\":[],\"chats\":[],\"social_profiles\":[],\"websites\":[],\"properties\":[]},\"_links\":{\"address\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/address\\/\"},\"chats\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/chats\\/\"},\"emails\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/emails\\/\"},\"phones\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/phones\\/\"},\"social-profiles\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/social-profiles\\/\"},\"websites\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\\/websites\\/\"},\"self\":{\"href\":\"https:\\/\\/api.helpscout.net\\/v2\\/customers\\/350514837\"}}}";

        [TestMethod]
        public void IsAuthenticWebhook_Works()
        {
            string secretKey = "MyTestKey";
            string invalidSignature = "ABC";
            string validSignature = "1O44Ikj7OBBstt+Dx+5/qhqnnHc=";
            Assert.IsFalse(WebhookHelper.IsAuthenticWebhook(secretKey, invalidSignature, customerUpdatedBody));
            Assert.IsTrue(WebhookHelper.IsAuthenticWebhook(secretKey, validSignature, customerUpdatedBody));
        }

        [TestMethod]
        public void ParseWebhookRequest_Works()
        {
            var customer = WebhookHelper.ParseWebhookRequest(customerUpdatedBody, "customer.updated") as Customer;
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.id, 350514837);
        }
    }
}
