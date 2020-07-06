using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListMailboxCustomFieldsResponse
    {
        public class Embedded
        {
            public MailboxCustomField[] fields { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
