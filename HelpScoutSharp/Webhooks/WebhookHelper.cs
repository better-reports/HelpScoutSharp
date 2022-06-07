using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace HelpScoutSharp
{
    public static class WebhookHelper
    {
        public static readonly Dictionary<string, Type> ObjectTypeNameToObjectType = new Dictionary<string, Type>
                                                                                        {
                                                                                            { "convo", typeof(Conversation) },
                                                                                            { "customer", typeof(Customer) },
                                                                                            { "satisfaction", typeof(Rating) },
                                                                                            { "tag", typeof(Tag) },
                                                                                        };

        public static readonly Dictionary<Type, string> ObjectTypeToObjectTypeName = ObjectTypeNameToObjectType.ToDictionary(kv => kv.Value, kv => kv.Key);

        public static IHasId ParseWebhookRequest(string json, string eventName)
        {
            string objectTypeName = eventName.Substring(0, eventName.IndexOf("."));
            var objectType = ObjectTypeNameToObjectType[objectTypeName];
            return (IHasId)JsonSerializer.Deserialize(json, objectType);
        }

        public static bool IsAuthenticWebhook(string appSecretKey, string signature, string requestBody)
        {
            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(appSecretKey)))
            {
                string hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(requestBody)));
                return hash == signature;
            }
        }
    }
}
