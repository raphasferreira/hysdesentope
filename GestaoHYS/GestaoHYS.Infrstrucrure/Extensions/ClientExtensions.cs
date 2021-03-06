using GestaoHIS.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GestaoHIS.Infrastructure.Extensions
{
    internal static class ClientExtensions
    {
        // Auth with bearer token
        public static void SetDefaultRequestHeaders(this HttpClient client, string cultureKey)
        {
            client.DefaultRequestHeaders.Add(Constants.RequestHeaders.AcceptLanguageHeaderKey, cultureKey);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.RequestHeaders.MediaTypeWithQualityHeaderKey));
        }
    }
}
