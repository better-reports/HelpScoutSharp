using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListTagsResponse
    {
        public class Embedded
        {
            public Tag[] tags { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
