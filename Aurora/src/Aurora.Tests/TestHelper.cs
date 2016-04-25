using System.Linq;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Aurora.Tests
{
    public class TestHelper
    {
        public static Assembly GetAssembly(string name)
        {
            return PlatformServices.Default.LibraryManager.GetLibraries().SelectMany(l => l.Assemblies.Select(an =>
            {
                try
                {
                    return Assembly.Load(an);
                }
                catch (ReflectionTypeLoadException)
                {
                    return null;
                }
            })).FirstOrDefault(a => a != null && a.FullName.Contains(name));
        }
    }
}
