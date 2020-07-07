using Autofac;
using IA.BooksInventory.Common;

namespace IA.BooksInventory.Application
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMatchingTypesAsImplementedInterfaces(typeof(AutofacModule).Assembly, new[] { ".+Command$", ".+Query$", ".+Service$" });
        }
    }
}
