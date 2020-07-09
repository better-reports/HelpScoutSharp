using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class CustomField : IHasId
    {
        public class DropDownOption : IHasId
        {
            public long id { get; set; }

            public int order { get; set; }

            public string label { get; set; }
        }

        public long id { get; set; }

        public string name { get; set; }

        public bool required { get; set; }

        public int order { get; set; }

        public string type { get; set; }

        public DropDownOption[] options { get; set; }
    }
}
