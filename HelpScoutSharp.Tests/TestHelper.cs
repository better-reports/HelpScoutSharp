using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp.Tests
{
    public class TestHelper
    {
        public static string ApplicationId = Environment.GetEnvironmentVariable("HELP_SCOUT_SHARP_APP_ID");

        public static string ApplicationSecret = Environment.GetEnvironmentVariable("HELP_SCOUT_SHARP_APP_SECRET");
    }
}
