using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class HelpScoutHttpClient
    {
        public static HttpClient HttpClient = new HttpClient();

        public async Task<TResponse> Post<TRequest, TResponse>(Uri uri, TRequest r)
        {
            var json = new StringContent(JsonSerializer.Serialize(r), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(uri, json);

            if (!response.IsSuccessStatusCode)
                throw new HelpScoutException(response);

            return JsonSerializer.Deserialize<TResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
