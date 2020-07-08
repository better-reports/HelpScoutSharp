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
        public static HttpClient HttpClient { get; set; } = new HttpClient();

        private readonly string _accessToken;

        public HelpScoutHttpClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<TResponse> GetAsync<TResponse>(Uri uri, object queryParams = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, new Url(uri).SetQueryParams(queryParams).ToString());
            return await this.SendAsync<TResponse>(request);
        }

        public async Task<TResponse> PostAsync<TResponse>(Uri uri, object content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync<TResponse>(request);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri uri, object content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync(request);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri uri, object content)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync(request);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            return await this.SendAsync(request);
        }

        private async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage request)
        {
            var response = await this.SendAsync(request);
            return JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            using (request)
            {
                if (_accessToken != null)
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    throw new HelpScoutException(response, await response.Content.ReadAsStringAsync());

                return response;
            }
        }
    }
}
