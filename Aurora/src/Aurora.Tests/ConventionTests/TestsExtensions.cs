using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Aurora.Tests.ConventionTests
{
    public static class TestsExtensions
    {
        public static IEnumerable<MethodInfo> GetAsyncMethods(this Type[] that)
        {
            return that.SelectMany(c => c.GetMethods())
                .Where(m => m.ReturnType.IsAssignableFrom(typeof(Task<>)) && !m.Name.EndsWith("Async"));
        }
    }
}
