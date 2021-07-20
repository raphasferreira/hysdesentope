using GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Sales;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using GestaoHIS.Infrastructure;
using GestaoHYS.Infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using GestaoHYS.Infrastructure.DataProviders.WebServices.Interfaces.Platform;

namespace GestaoHYS.Infrastructure.DataProviders.WebServices
{
    public static class RegisterHttpClients
    {
        public static void Register(this IServiceCollection services, string urlBase)
        {
            //services.AddRefitClient<ICustomersClient>()
            //    .ConfigureHttpClient(
            //        c => c.BaseAddress = new Uri(urlBase));


            services.Register<ICustomersClient>("Customer", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<ICountriesClient>("Countries", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });


            services.Register<ICurrenciesClient>("Currencies", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<ICulturesClient>("Cultures", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<ICustomerGroupClient>("CustomerGroup", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IPaymentMethodsClient>("PaymentMethods", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IPaymentTermsClient>("PaymentTerms", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IDeliveryTermsClient>("DeliveryTerms", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IPartyTaxSchemasClient>("PartyTaxSchemas", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });


            services.Register<IPartyWithholdingTaxSchemasClient>("PartyWithholdingTaxSchemas", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IPriceListsClient>("PriceLists", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<ISalesItemClient>("SalesItem", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IUnitClient>("Unit", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IAssortmentsClient>("Assortments", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IBrandsClient>("Brands", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

            services.Register<IBrandModelsClient>("BrandModels", urlBase, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }

                })
            });

        }

        private static IHttpClientBuilder Register<T>(this IServiceCollection services,string name, string baseAddress, RefitSettings refitSettings)
            where T : class
        {
            return services.AddHttpClient<T>(name, client => client.BaseAddress = new Uri(baseAddress))
                
                .AddTypedClient<T>((c, ServiceProvider) =>
                {
                    var httpContextAccessor = ServiceProvider.GetService<IHttpContextAccessor>();
                    return RestService.For<T>(c, refitSettings);
                });
        }
    }
}
