using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListWebhooksResponse
    {
        public class Embedded
        {
            public Webhook[] webhooks { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
