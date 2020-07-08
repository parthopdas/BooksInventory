using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Autofac;

namespace IA.BooksInventory.Common
{
    public static class AutofacExtensions
    {
        public static void RegisterMatchingTypesAsImplementedInterfaces(this ContainerBuilder builder, Assembly containingAssembly, params string[] classNameMatchers)
        {
            builder
                .RegisterAssemblyTypes(containingAssembly)
                .Where(t => classNameMatchers.Any(m => Regex.IsMatch(t.Name, m)))
                .AsImplementedInterfaces();
        }
    }
}
