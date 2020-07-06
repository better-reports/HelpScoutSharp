using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class Customer
    {
        public long id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }

        public string photoUrl { get; set; }

        public string jobTitle { get; set; }

        public string photoType { get; set; }

        public string background { get; set; }

        public string location { get; set; }

        public string organization { get; set; }

        public string gender { get; set; }

        public string age { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
