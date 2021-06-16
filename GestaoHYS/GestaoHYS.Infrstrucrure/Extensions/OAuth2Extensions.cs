using GestaoHIS.Infrastructure;
using IdentityModel.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoHYS.Infrastructure.Extensions
{
    public static class OAuth2Extensions
    {
        public static void AddTokenGenerator(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddAccessTokenManagement(options =>
            {
                options.Client.Clients.Add("auth", new ClientCredentialsTokenRequest
                {
                    Address = Constants.Identity.BaseUriKey +  Constants.Identity.TokenUriKey,
                    ClientId = Constants.clientId,
                    ClientSecret = Constants.clientSecret,
                    Scope = "application",
                    GrantType = "client_credentials",
                    ClientCredentialStyle = ClientCredentialStyle.PostBody
                });
            });

            services.AddClientAccessTokenClient("Customer", "auth");
        }

    }
}
