using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HelpScoutSharp
{
    public class CustomerPropertiesResult
    {
        public class Embedded
        {
            [JsonPropertyName("customer-properties")]
            public CustomerProperty[] customer_properties { get; set; }
        }

        public Embedded _embedded { get; set; }
    }
}
