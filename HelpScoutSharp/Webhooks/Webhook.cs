using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class Webhook : IHasId
    {
        public long id { get; set; }

        public string url { get; set; }

        public string[] events { get; set; }

        public bool notification { get; set; }

        public string state { get; set; }

        public string payloadVersion { get; set; }
    }
}
