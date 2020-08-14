using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class CustomerProperty
    {
        public class CustomerPropertyDropDownOption
        {
            public string id { get; set; }

            public string label { get; set; }
        }

        public string type { get; set; }

        public string slug { get; set; }

        public string name { get; set; }

        public CustomerPropertyDropDownOption[] options { get; set; }
    }
}
