using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListUsersOptions : ListOptions
    {
        public string email { get; set; }

        public long? mailbox { get; set; }
    }
}
