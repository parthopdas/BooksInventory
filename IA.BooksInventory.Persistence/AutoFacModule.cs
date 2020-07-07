using Autofac;
using IA.BooksInventory.Common;

namespace IA.BooksInventory.Persistence
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMatchingTypesAsImplementedInterfaces(typeof(AutofacModule).Assembly, new[] { ".+Command$", ".+Query$", ".+Service$" });
        }
    }
}
