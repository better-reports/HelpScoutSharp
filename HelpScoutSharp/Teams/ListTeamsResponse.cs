using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListTeamsResponse
    {
        public class Embedded
        {
            public Team[] teams { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
