using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class TokenResponse
    {
        /// <summary>
        /// "bearer"
        /// </summary>
        public string token_type { get; set; }

        public string access_token { get; set; }

        public string refresh_token { get; set; }

        /// <summary>
        /// duration in seconds
        /// </summary>
        public int expires_in { get; set; }
    }
}
