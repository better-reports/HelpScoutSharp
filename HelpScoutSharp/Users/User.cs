using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class User : IHasId
    {
        public long id { get; set; }

        public long companyId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public string role { get; set; }

        public string timezone { get; set; }

        public string type { get; set; }

        public string photoUrl { get; set; }

        public string initials { get; set; }

        public string mention { get; set; }

        public string jobTitle { get; set; }

        public string phone { get; set; }

        public string[] alternateEmails { get; set; }
    }
}
