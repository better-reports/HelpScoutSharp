using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class Mailbox
    {
        public long id { get; set; }

        public string name { get; set; }

        public string slug { get; set; }

        public string email { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
