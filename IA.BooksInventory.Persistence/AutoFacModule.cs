using Autofac;

namespace IA.BooksInventory.Persistence
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DataService()).As<IDataService>();
        }
    }
}
