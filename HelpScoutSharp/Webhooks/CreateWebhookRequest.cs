using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class CreateWebhookRequest
    {
        public string url { get; set; }

        public string[] events { get; set; }

        public bool notification { get; set; }

        public string secret { get; set; }
    }
}
