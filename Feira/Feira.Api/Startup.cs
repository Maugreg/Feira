using Autofac;
using Autofac.Extensions.DependencyInjection;
using Feira.Api.Filters;
using Feira.Api.Infrastructure.AutofacModules;
using Feira.Api.Infrastructure.Extensions;
using Feira.Domain.Models;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Feira.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public bool TestEnabled { get; protected set; }
        public IConfiguration Configuration { get; protected set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment hosting)
        {

#if DEBUG
            var builder = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath)
                                        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
#else
            var builder = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath)
                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
#endif

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region Mapping das keys do appsettings.json

            services.Configure<Settings>(Configuration.GetSection("Settings"));
            var settings = Configuration.GetSection("Settings").Get<Settings>();

            #endregion

            #region HealthCheck
            services.AddHealthChecks(settings);
            #endregion

            services.AddMvc(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });


            #region Adicionar Log na aplicação 
            SerilogProvider.CreateLogger(typeof(Startup).Namespace, settings);

            Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace)
                .Information("Log adicionado na aplicação.");

            services.AddSingleton(Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace));
            #endregion

            services.AddSingleton<Domain.Interfaces.IConfiguration>(settings);

            Log.ForContext(SerilogProvider.Application, typeof(Startup).Namespace)
            .Information("Adicionado injeção de dependencia na aplicação.");


        services.AddSwaggerGen(config =>
            {

                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Feira",
                    Version = "v1"
                });

                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = $"{"Feira.Api"}.xml";

                config.IncludeXmlComments(Path.Combine(basePath, fileName));
            });

            var container = new ContainerBuilder();
            container.Populate(services);

            //Injeção dos modulos 
            container.RegisterModule(new ApplicationModule());
            container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures =
                new[] { "pt-BR", "pt", "en-US", "en", "es-ES", "es" }
                    .Select(x => new CultureInfo(x)).ToList();

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture(supportedCultures[0])
            };

            app.UseRequestLocalization(requestLocalizationOptions);
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecksUI();
            });

            app.UseHealthChecks("/healthchecks", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }

    public class StartupTests : Startup
    {
        public StartupTests(IConfiguration configuration, IWebHostEnvironment hosting)
            : base(configuration, hosting)
        {
            TestEnabled = true;

            var builder = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath)
                                        .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
    }
}
