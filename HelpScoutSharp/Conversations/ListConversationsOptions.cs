using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListConversationsOptions : ListOptions
    {
        public string embed { get; set; }

        public long[] mailbox { get; set; }

        public long? folder { get; set; }

        public string status { get; set; }

        public string tag { get; set; }

        public long? assigned_to { get; set; }

        public DateTime? modifiedSince { get; set; }

        public long? number { get; set; }

        public string sortField { get; set; }

        public string sortOrder { get; set; }

        public string query { get; set; }

        public string customFieldsByIds { get; set; }
    }
}
