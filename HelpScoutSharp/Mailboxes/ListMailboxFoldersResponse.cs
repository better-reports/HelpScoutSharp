using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListMailboxFoldersResponse
    {
        public class Embedded
        {
            public MailboxFolder[] folders { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
