using System;
using System.Collections.Generic;
using System.Text;

namespace HelpScoutSharp
{
    public enum RateLimitBreachBehavior
    {
        /// <summary>
        /// Throw an exception. This is the default
        /// </summary>
        Throw,

        /// <summary>
        /// Wait until the rate limit is refreshed and retry (once only)
        /// </summary>
        WaitAndRetryOnce
    }
}
