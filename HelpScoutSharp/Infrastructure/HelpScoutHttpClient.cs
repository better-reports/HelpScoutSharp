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

        public static RateLimitBreachBehavior RateLimitBreachBehavior { get; set; } = RateLimitBreachBehavior.Throw;

        private readonly string _accessToken;

        public HelpScoutHttpClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<TResponse> GetAsync<TResponse>(Uri uri, object queryParams = null, Action<Url> configureUrl = null)
        {
            Func<HttpRequestMessage> makeRequest = () =>
            {
                var url = new Url(uri).SetQueryParams(queryParams);
                configureUrl?.Invoke(url);
                return new HttpRequestMessage(HttpMethod.Get, url.ToString());
            };
            return await this.SendAsync<TResponse>(makeRequest);
        }

        public async Task<TResponse> PostAsync<TResponse>(Uri uri, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync<TResponse>(makeRequest);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri uri, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync(makeRequest);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri uri, object content)
        {
            Func<HttpRequestMessage> makeRequest = () => new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
            };
            return await this.SendAsync(makeRequest);
        }

        public async Task<HttpResponseMessage> DeleteAsync(Uri uri)
        {
            Func<HttpRequestMessage> request = () => new HttpRequestMessage(HttpMethod.Delete, uri);
            return await this.SendAsync(request);
        }

        private async Task<TResponse> SendAsync<TResponse>(Func<HttpRequestMessage> makeRequest)
        {
            var response = await this.SendAsync(makeRequest);
            return JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
        }

        private async Task<HttpResponseMessage> SendAsync(Func<HttpRequestMessage> makeRequest)
        {
            //we use a request factory to make a new request when a retry is needed
            //that is because request message cannot be reused
            bool isFirstTry = true;

        send:
            using (var request = makeRequest())
            {
                if (_accessToken != null)
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);


                var response = await HttpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var exception = new HelpScoutException(response, await response.Content.ReadAsStringAsync());
                    if (isFirstTry && RateLimitBreachBehavior == RateLimitBreachBehavior.WaitAndRetryOnce && exception.IsRateLimit)
                    {
                        isFirstTry = false;
                        //adding an extra 1 second wait to avoid chance of retrying jus a little too early
                        await Task.Delay(exception.RateLimitRetryAfter + TimeSpan.FromSeconds(1) ?? TimeSpan.FromMinutes(1));
                        goto send;
                    }
                    throw exception;
                }

                return response;
            }
        }
    }
}
