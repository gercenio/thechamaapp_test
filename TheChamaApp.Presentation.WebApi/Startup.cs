using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Infra.IoC;



namespace TheChamaApp.Presentation.WebApi
{
    public class Startup
    {

        #region # Properties
        private Container container = new Container();
        public IConfiguration Configuration { get; }
        #endregion

        #region # Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region # Methods

        public void ConfigureServices(IServiceCollection services)
        {

            IntegrateSimpleInjector(services);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;
                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;
                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseMvc();

            // initial config
            InitializeContainer(container);

            container.Verify();



            /*
            //Adding Model class to OData
            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EntitySet<Domain.Entities.Stock>(nameof(Stock));
            builder.EntitySet<Domain.Entities.CreditManager>(nameof(CreditManager));
            builder.EntitySet<Domain.Entities.InvoiceHeader>(nameof(InvoiceHeader));
            builder.EntitySet<Domain.Entities.InvoiceItensBody>(nameof(InvoiceItensBody));
            #region # CUSTOM ROUTER

            // New code:
            builder.Function("GetInvoiceHeaderEcommerceByCustomerId")
                .Returns<Domain.Entities.InvoiceHeader>()
                .Parameter<string>("ParId");

            // New code:
            builder.Function("GetInvoiceHeaderTelemarketingByCustomerId")
                .Returns<Domain.Entities.InvoiceHeader>()
                .Parameter<string>("ParId");

            // New code:
            builder.Function("GetInvoiceHeaderStoreByCustomerId")
                .Returns<Domain.Entities.InvoiceHeader>()
                .Parameter<string>("ParId");

            #endregion


            //Enabling OData routing.
            /*app.UseMvc(routebuilder =>
            {
                routebuilder.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
                routebuilder.EnableDependencyInjection();
                routebuilder.GetDefaultODataOptions();
                routebuilder.GetDefaultQuerySettings();

            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tenda Atacado WebApi V1");
            });*/
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }

        #endregion
    }

    #region # Internal Class

    public class SigningConfigurations
    {

        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }

    #endregion
}
