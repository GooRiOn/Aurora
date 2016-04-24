using System;
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
            var domain_assembly = TestHelper.GetAssembly(AssemblyNames.Domain);


            var domain_types = domain_assembly.GetTypes();
            var async_methods_without_async_suffix = domain_types.GetAsyncMethods();

            Assert.Empty(async_methods_without_async_suffix);
        }


        [Fact]
        public void each_asynchronous_method_in_DomainProxy_namespace_contains_async_suffix()
        {
            var domain_proxy_assembly = TestHelper.GetAssembly(AssemblyNames.DomainProxy);


            var domain_proxy_types = domain_proxy_assembly.GetTypes();
            var async_methods_without_async_suffix = domain_proxy_types.GetAsyncMethods();

            Assert.Empty(async_methods_without_async_suffix);
        }

        [Fact]
        public void each_asynchronous_method_in_Web_namespace_contains_async_suffix()
        {
            var web_assembly = TestHelper.GetAssembly(AssemblyNames.Web);

            var web_types = web_assembly.GetTypes();
            var async_methods_without_async_suffix = web_types.GetAsyncMethods().Where(m => !m.Name.Contains("ViewBag"));

            foreach (var methodInfo in async_methods_without_async_suffix)
                Console.WriteLine(methodInfo.Name);
            

            Assert.Empty(async_methods_without_async_suffix);
        }


    }
}
