using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices;
using Autofac;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace Aurora.Tests.ConventionTests
{
    public class AsynchronousMethodsNaming
    {
        [Fact]
        public void each_asynchronous_method_in_Domain_namespace_contains_async_sufix()
        {
            var domainAssembly = PlatformServices.Default.LibraryManager.GetLibraries().SelectMany(l => l.Assemblies.Select(an =>
            {
                try
                {
                    return Assembly.Load(an);
                }
                catch (ReflectionTypeLoadException)
                {
                    return null;
                }
            })).FirstOrDefault(a => a != null && a.FullName.Contains("Aurora.Domain"));


            var domainClasses = domainAssembly.GetTypes();

            var async_methods_without_async_suffix = domainClasses
                .SelectMany(c => c.GetMethods())
                .Where(m => m.ReturnType.IsAssignableFrom(typeof (Task<>)) && !m.Name.Contains("Async"));

            var domainInterfaces = domainAssembly.GetTypes().SelectMany(t => t.GetInterfaces());

            var async_methods_declarations_without_async_suffix = domainInterfaces
                .SelectMany(t => t.GetMethods())
                .Where(m => m.ReturnType.IsAssignableFrom(typeof(Task<>)) && !m.Name.Contains("Async"));


            Assert.Empty(async_methods_without_async_suffix);
            Assert.Empty(async_methods_declarations_without_async_suffix);
        }

    }
}
