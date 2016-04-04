using System;
using Aurora.DomainProxy.AppBuild;
using Aurora.Infrastructure.DependencyInjection;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Web.Auth;
using Aurora.Web.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Aurora.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
              
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }
        public IContainer Container { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            AspNetRegistration.Register(services);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            var builder = new ContainerBuilder();

            builder.RegisterModule(new Registration());
            builder.Populate(services);

            var container = builder.Build();
            var customDependencyBuilder = new ContainerBuilder();

            customDependencyBuilder.RegisterInstance<ICustomDependencyResolver>(new CustomDependencyResolver(container));
            customDependencyBuilder.Update(container);

            Container = container;

            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TokenAuthOptions tokenAuthOptions)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();
            app.OnDomainProxyBuild(Container);
            app.RegisterBearerAuthentication(tokenAuthOptions);
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();
           
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
