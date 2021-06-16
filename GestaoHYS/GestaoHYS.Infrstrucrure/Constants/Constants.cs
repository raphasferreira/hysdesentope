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
        /// The Jasmin base application URL.
        /// </summary>
        public const string baseAppUrl = "https://my.jasminsoftware.com";


        public const string AccountKey = "228150";

        public const string SubscriptionKey = "228150-0001";
        public const string clientId = "7895462";
        public const string clientSecret = "b4037ce8-f117-469f-b208-e9c7ee0a0f92";
       
        /// <summary>
        /// The default culture
        /// </summary>
        /// <remarks>Available cultures are "PT-pt, EN-us, ES-es".</remarks>
        public const string DefaultCulture = "PT-pt";

        /// <summary>
        /// Authentication related constants.
        /// </summary>
        public static class Identity
        {
            internal const string BaseUriKey = "https://identity.primaverabss.com/";
            internal const string TokenUriKey = "connect/token";
            internal const string ApplicationScopes = "application"; // default scopes
        }

        /// <summary>
        /// Console arguments related constants.
        /// </summary>
        internal static class Session
        {
            internal const string ClientId = "/ClientId:";
            internal const string ClientSecret = "/ClientSecret:";
            internal const string AccountKey = "/AccountKey:";
            internal const string SubscriptionKey = "/SubscriptionKey:";
        }

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
