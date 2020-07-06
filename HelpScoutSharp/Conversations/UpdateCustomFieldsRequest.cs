using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class UpdateCustomFieldsRequest
    {
        public class CustomFieldValue
        {
            public long id { get; set; }

            public string value { get; set; }
        }

        public CustomFieldValue[] fields { get; set; }
    }
}
