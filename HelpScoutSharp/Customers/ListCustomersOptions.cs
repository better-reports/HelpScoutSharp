using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListCustomersOptions : ListOptions
    {
        public long? mailbox { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime? modifiedSince { get; set; }

        public string sortField { get; set; }

        public string sortOrder { get; set; }

        public string query { get; set; }
    }
}
