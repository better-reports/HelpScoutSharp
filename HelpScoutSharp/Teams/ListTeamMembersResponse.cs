using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListTeamMembersResponse
    {
        public class Embedded
        {
            public User[] users { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
