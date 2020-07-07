using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Caliburn.Micro.Autofac;
using IA.BooksInventory.UI.ViewModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IA.BooksInventory.UI
{
    public sealed class AppBootstrapper : AutofacBootstrapper<ShellViewModel>
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        public IMediator GetMediator()
        {
            return (IMediator)GetInstance(typeof(IMediator), null);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return typeof(ShellViewModel).Assembly;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);


            builder.RegisterModule<Application.AutofacModule>();
            builder.RegisterModule<Persistence.AutofacModule>();

            var services = new ServiceCollection();
            services
                .AddMediatR(typeof(Application.AutofacModule).GetTypeInfo().Assembly)
                .AddAutoMapper(typeof(Application.AutofacModule).GetTypeInfo().Assembly);
            builder.Populate(services);
        }
    }
}
