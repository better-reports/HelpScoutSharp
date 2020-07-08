using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class TagPage : IPage<Tag>
    {
        public class Embedded
        {
            public Tag[] tags { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }

        public Tag[] entities => _embedded.tags;
    }
}
