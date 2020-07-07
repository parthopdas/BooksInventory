using System.Net.NetworkInformation;
using System.Windows.Controls;
using Caliburn.Micro;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class ContentConductorViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly HomeViewModel _homeViewModel;

        public ContentConductorViewModel(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            ActivateItem(_homeViewModel);
        }
    }
}
