using Flurl;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class HelpScoutHttpClient
    {
        public static HttpClient HttpClient = new HttpClient();
        
        private readonly string _accessToken;

        public HelpScoutHttpClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<TResponse> GetAsync<TQueryString, TResponse>(Uri uri, TQueryString r = null) where TQueryString : class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Url(uri).SetQueryParams(r).ToString());
            return await this.SendAsync<TResponse>(request);
        }

        public async Task<TResponse> PostAsync<TBody, TResponse>(Uri uri, TBody r)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            { 
                Content = new StringContent(JsonSerializer.Serialize(r), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync<TResponse>(request);
        }

        private async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage request)
        {
            using (request)
            {
                if (_accessToken != null)
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    throw new HelpScoutException(response);

                return JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
