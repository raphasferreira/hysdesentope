using GestaoHIS.Infrastructure;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoHYS.Infrastructure.Extensions
{
    public static class OAuth2Extensions
    {
        public static async void AddTokenGenerator(this IServiceCollection services, ConfigurationSystem configurationSystem)
        {
            
            services.AddDistributedMemoryCache();
            services.AddAccessTokenManagement(options =>
            {
                options.Client.Clients.Add("auth", new ClientCredentialsTokenRequest
                {
                    Address = configurationSystem.BaseAccessTokenUriKey + configurationSystem.TokenUriKey,
                    ClientId = configurationSystem.ClientId,
                    ClientSecret = configurationSystem.ClientSecret,
                    Scope = "application",
                    GrantType = "client_credentials",
                    ClientCredentialStyle = ClientCredentialStyle.PostBody
                });
            });

            services.AddClientAccessTokenClient("Customer", "auth");
            services.AddClientAccessTokenClient("Countries", "auth");
            services.AddClientAccessTokenClient("Currencies", "auth");
            services.AddClientAccessTokenClient("Cultures", "auth");
            services.AddClientAccessTokenClient("CustomerGroup", "auth");
            services.AddClientAccessTokenClient("PaymentMethods", "auth");
            services.AddClientAccessTokenClient("PaymentTerms", "auth");
            services.AddClientAccessTokenClient("DeliveryTerms", "auth");
            services.AddClientAccessTokenClient("PartyTaxSchemas", "auth");
            

        }

    }
}
