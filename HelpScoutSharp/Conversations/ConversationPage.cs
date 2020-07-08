using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HelpScoutSharp
{
    public class ConversationPage : IPage<Conversation>
    {
        public class Embedded
        {
            public Conversation[] conversations { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }

        public Conversation[] entities => _embedded.conversations;
    }
}
