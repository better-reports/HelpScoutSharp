using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp.Tests
{
    /// <summary>
    /// If running in Visual Studio, make sure to restart Visual Studio after setting environment variables
    /// </summary>
    public class TestHelper
    {
        public static string ApplicationId = Environment.GetEnvironmentVariable("HELP_SCOUT_SHARP_APP_ID");

        public static string ApplicationSecret = Environment.GetEnvironmentVariable("HELP_SCOUT_SHARP_APP_SECRET");
    }
}
