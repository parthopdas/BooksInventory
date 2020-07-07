using System.Windows;
using Caliburn.Micro.Autofac;
using IA.BooksInventory.App.ViewModels;

namespace IA.BooksInventory.App
{
    public sealed class Bootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
