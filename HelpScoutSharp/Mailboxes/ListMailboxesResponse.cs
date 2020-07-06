using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListMailboxesResponse
    {
        public class Embedded
        {
            public Mailbox[] mailboxes { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
