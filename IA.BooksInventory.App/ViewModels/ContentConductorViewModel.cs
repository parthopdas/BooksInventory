using System.Net.NetworkInformation;
using System.Windows.Controls;
using Caliburn.Micro;

namespace IA.BooksInventory.App.ViewModels
{
    public sealed class ContentConductorViewModel : Conductor<Screen>.Collection.OneActive
    {
        public MenuViewModel Menu { get; }

        private readonly HomeViewModel _homeViewModel;

        public ContentConductorViewModel(MenuViewModel menuViewModel, HomeViewModel homeViewModel)
        {
            Menu = menuViewModel;
            _homeViewModel = homeViewModel;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            ActivateItem(_homeViewModel);
        }
    }
}
