using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class MailboxFolder
    {
        public long id { get; set; }

        public string type { get; set; }

        public string name { get; set; }

        public int totalCount { get; set; }

        public long userId { get; set; }

        public int activeCount { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
