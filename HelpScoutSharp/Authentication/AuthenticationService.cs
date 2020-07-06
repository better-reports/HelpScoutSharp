using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutSharp
{
    public class AuthenticationService : ServiceBase
    {
        public AuthenticationService()
            : base(null, "oauth2/token")
        {
        }


        public string GenerateAuthorizationPromptUrl(string applicationId, string state = null)
        {
            string url = $"https://secure.helpscout.net/authentication/authorizeClientApplication?client_id={applicationId}";

            if (state != null)
                url += $"&state={state}";

            return url;
        }

        public async Task<TokenResponse> GetOAuthTokenAsync(string applicationId, string applicationSecret, string code)
        {
            return await _client.PostAsync<TokenRequest, TokenResponse>(_serviceUri, new TokenRequest
            {
                client_id = applicationId,
                client_secret = applicationSecret,
                grant_type = "authorization_code",
                code = code,
            });
        }

        public async Task<TokenResponse> RefreshOAuthTokenAsync(string applicationId, string applicationSecret, string refreshToken)
        {
            return await _client.PostAsync<TokenRequest, TokenResponse>(_serviceUri, new TokenRequest
            {
                client_id = applicationId,
                client_secret = applicationSecret,
                grant_type = "refresh_token",
                refresh_token = refreshToken,
            });
        }

        public async Task<TokenResponse> GetApplicationTokenAsync(string applicationId, string applicationSecret)
        {
            return await _client.PostAsync<TokenRequest, TokenResponse>(_serviceUri, new TokenRequest
            {
                client_id = applicationId,
                client_secret = applicationSecret,
                grant_type = "client_credentials",
            });
        }
    }
}
