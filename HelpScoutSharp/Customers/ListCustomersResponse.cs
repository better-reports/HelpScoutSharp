﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public class ListCustomersResponse
    {
        public class Embedded
        {
            public Customer[] customers { get; set; }
        }

        public Embedded _embedded { get; set; }

        public Page page { get; set; }
    }
}
