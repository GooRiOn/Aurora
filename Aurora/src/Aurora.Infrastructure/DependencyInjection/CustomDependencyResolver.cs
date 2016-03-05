using System;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Autofac;

namespace Aurora.Infrastructure.DependencyInjection
{
    public class CustomDependencyResolver : ICustomDependencyResolver
    {
        private readonly IContainer _container;

        public CustomDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public TResolved Resolve<TResolved>()
        {
            return _container.Resolve<TResolved>();
        }

        public TResolved Resolve<TResolved, TOverride>(string parameterName, TOverride @override)
        {
            return _container.Resolve<TResolved>(new NamedParameter(parameterName,@override));
            
        }

        public TResolved Resolve<TResolved, TOverride0, TOverride1>(string parameterName1, string parameterName2, TOverride0 @override0, TOverride1 @override1)
        {
            return _container.Resolve<TResolved>(new NamedParameter(parameterName1, @override1), new NamedParameter(parameterName2, @override1));
        }
    }
}
