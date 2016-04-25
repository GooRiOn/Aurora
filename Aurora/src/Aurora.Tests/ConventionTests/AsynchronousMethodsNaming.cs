using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Aurora.Tests.ConventionTests
{
    public class AsynchronousMethodsNaming
    {
        [Fact]
        public void each_asynchronous_method_in_Domain_namespace_contains_async_suffix()
        {
            var async_methods_without_async_suffix = Execute(AssemblyNames.Domain);

            Assert.Empty(async_methods_without_async_suffix);
        }


        [Fact]
        public void each_asynchronous_method_in_DomainProxy_namespace_contains_async_suffix()
        {
            var async_methods_without_async_suffix = Execute(AssemblyNames.DomainProxy);

            Assert.Empty(async_methods_without_async_suffix);
        }

        [Fact]
        public void each_asynchronous_method_in_Web_namespace_contains_async_suffix()
        {
            var async_methods_without_async_suffix = Execute(AssemblyNames.Web).Where(m => !m.Name.Contains("ViewBag"));

            Assert.Empty(async_methods_without_async_suffix);
        }

        private static IEnumerable<MethodInfo> Execute(string @namespace)
        {
            var domain_assembly = TestHelper.GetAssembly(@namespace);


            var domain_types = domain_assembly.GetTypes();
            var async_methods_without_async_suffix = domain_types.GetAsyncMethods();

            return async_methods_without_async_suffix;
        }
    }
}
