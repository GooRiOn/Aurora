using Aurora.Web.Auth;
using Aurora.Web.Auth.Interfaces;
using Aurora.Web.Services;
using Aurora.Web.Services.Interfaces;
using Autofac;

namespace Aurora.Web.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DomainProxy.DependencyInjection.Registration());
            builder.RegisterType<OAuthService>().As<IOAuthService>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<HttpService>().As<IHttpService>();
        }
    }
}
