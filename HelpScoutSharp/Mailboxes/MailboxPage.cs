using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class MailboxPage : IPage<Mailbox>
    {
        public class Embedded
        {
            public Mailbox[] mailboxes { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }

        public Mailbox[] entities => _embedded.mailboxes;
    }
}
