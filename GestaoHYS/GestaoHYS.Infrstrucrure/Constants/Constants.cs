using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoHIS.Infrastructure
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// Requests headers related constants.
        /// </summary>
        internal static class RequestHeaders
        {
            internal const string AcceptLanguageHeaderKey = "Accept-Language";
            internal const string MediaTypeWithQualityHeaderKey = "application/json";
            internal const string AuthenticationHeaderKey = "Bearer";

        }
    }
}
