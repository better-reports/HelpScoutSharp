using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListCustomersOptions
    {
        public int? page { get; set; }

        public long? mailbox { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime? modifiedSince { get; set; }

        public string sortField { get; set; }

        public string sortOrder { get; set; }

        public string query { get; set; }
    }
}
