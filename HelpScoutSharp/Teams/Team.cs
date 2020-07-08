using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class Team : IHasId
    {
        public long id { get; set; }

        public string name { get; set; }

        public string initials { get; set; }

        public string mention { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public string timezone { get; set; }

        public string photoUrl { get; set; }
    }
}
