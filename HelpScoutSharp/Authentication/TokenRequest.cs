using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class TokenRequest
    {
        public string client_id { get; set; }

        public string client_secret { get; set; }

        /// <summary>
        /// "authorization_code" or "refresh_token" or "client_credentials"
        /// </summary>
        public string grant_type { get; set; }

        public string refresh_token { get; set; }

        /// <summary>
        /// Supply if grant_type = "authorization_code"
        /// </summary>
        public string code { get; set; }
    }
}
