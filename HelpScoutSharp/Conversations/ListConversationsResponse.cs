using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListConversationsResponse
    {
        public class Embedded
        {
            public Conversation[] conversations { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
