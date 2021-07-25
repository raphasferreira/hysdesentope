
using GestaoHIS.Infrastructure.Repository;
using GestaoHYS.Core.Repositories;
using GestaoHYS.Core.Services;
using GestaoHYS.Core.Services.Interfaces;
using GestaoHYS.Core.WebServices;
using GestaoHYS.Infrastructure.DataProviders.Repository;
using GestaoHYS.Infrastructure.DataProviders.WebServices;
using GestaoHYS.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GestaoHIS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });



            

            var cnnString = Configuration.GetConnectionString("MySqlDbConnection");
            services.AddDbContext<GestaoHISContext>(x => x.UseMySQL(cnnString));
            //services.AddScoped<IGestaoHISRepository, GestaoHISRepository>();

            RegisterService(services);

            var provider = services.BuildServiceProvider();
            var configurationSystemReposiroty = provider.GetService<IConfigurationSystemRepository>();
            var configurationSystem = configurationSystemReposiroty.FindAll().Result.FirstOrDefault();

            var key = Encoding.ASCII.GetBytes(configurationSystem.ClientSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            services.AddTokenGenerator(configurationSystem);

            var urlBase = $"{configurationSystem.BaseAppUrl}/api/{configurationSystem.AccountKey}/{configurationSystem.SubscriptionKey}";
            //HttpClients
            RegisterHttpClients.Register(services, urlBase);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                              .WithOrigins("http://localhost:4200")
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials();
                });
  
            });
            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Autenticar GestaoHYS com token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }


        public static void RegisterService(IServiceCollection services)
        {
            //Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IParceiroService, ParceiroService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<ICurrenciesService, CurrenciesService>();
            services.AddScoped<ICulturesService, CulturesService>();
            services.AddScoped<IPerfilUsuarioService, PerfilUsuarioService>();
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();
            services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();
            services.AddScoped<IPaymentTermsService, PaymentTermsService>();
            services.AddScoped<IDeliveryTermsService, DeliveryTermsService>();
            services.AddScoped<IPartyWithholdingTaxSchemasService, PartyWithholdingTaxSchemasService>();
            services.AddScoped<IPriceListsService, PriceListsService>();
            services.AddScoped<IPartyTaxSchemasService, PartyTaxSchemasService>();
            services.AddScoped<IPartyWithholdingTaxSchemasService, PartyWithholdingTaxSchemasService>();
            services.AddScoped<ISalesItemService, SalesItemService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IAssortmentsService, AssortmentsService>();
            services.AddScoped< IBrandModelsService, BrandModelsService> ();
            services.AddScoped< IBrandsService, BrandsService>();
            services.AddScoped< ISeriesService, SeriesService>();
            services.AddScoped<IInvoiceTypesService, InvoiceTypesService>();
            services.AddScoped<IWarehousesService, WarehousesService>();
            services.AddScoped<IItemTaxSchemasService, ItemTaxSchemasService>();
            services.AddScoped<IItemWithholdingTaxSchemasService, ItemWithholdingTaxSchemasService>();

            //WebServices
            services.AddScoped<ICustomerWebService, CustomerWebService>();
            services.AddScoped<ICountriesWebService, CountriesWebService>();
            services.AddScoped<ICurrenciesWebService, CurrenciesWebService>();
            services.AddScoped<ICulturesWebService, CulturesWebService>();
            services.AddScoped<ICustomerGroupWebService, CustomerGroupWebService>();
            services.AddScoped<IPaymentMethodsWebService, PaymentMethodsWebService>();
            services.AddScoped<IPaymentTermsWebService, PaymentTermsWebService>();
            services.AddScoped<IDeliveryTermsWebService, DeliveryTermsWebService>();
            services.AddScoped<IPartyWithholdingTaxSchemasWebService, PartyWithholdingTaxSchemasWebService>();
            services.AddScoped<IPriceListsWebService, PriceListsWebService>();
            services.AddScoped<IPartyTaxSchemasWebService, PartyTaxSchemasWebService>();
            services.AddScoped<IPartyWithholdingTaxSchemasWebService, PartyWithholdingTaxSchemasWebService>();
            services.AddScoped<ISalesItemWebService, SalesItemWebService>();
            services.AddScoped<IUnitWebService, UnitWebService>();
            services.AddScoped<IAssortmentsWebService, AssortmentsWebService>();
            services.AddScoped<IBrandModelsWebService, BrandModelsWebService>();
            services.AddScoped<IBrandsWebService, BrandsWebService>();
            services.AddScoped<ISeriesWebService, SeriesWebService>();
            services.AddScoped<IInvoiceTypesWebService, InvoiceTypesWebService>();
            services.AddScoped<IWarehousesWebService, WarehousesWebService>();
            services.AddScoped<IItemTaxSchemasWebService, ItemTaxSchemasWebService>();
            services.AddScoped<IItemWithholdingTaxSchemasWebService, ItemWithholdingTaxSchemasWebService>();

            //Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
            services.AddScoped<IConfigurationSystemRepository, ConfigurationSystemRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IParceiroRepository, ParceiroRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ISalesItemRepository, SalesItemRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                });
                app.UseHsts();
            }

            app.Use((context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                return next.Invoke();
            });

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

           
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api GestãoHYS");
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";
            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
