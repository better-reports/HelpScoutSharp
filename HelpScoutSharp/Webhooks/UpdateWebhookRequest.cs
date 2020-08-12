using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class UpdateWebhookRequest
    {
        public string url { get; set; }

        public string[] events { get; set; }

        public bool notification { get; set; }

        public string secret { get; set; }

        public string payloadVersion { get; set; }
    }
}
