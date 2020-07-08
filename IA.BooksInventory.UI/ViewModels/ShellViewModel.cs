using Caliburn.Micro;
using MediatR;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly ContentConductorViewModel _contentConductorViewModel;

        public MenuViewModel Menu { get; }

        public ShellViewModel(
            MenuViewModel menuViewModel,
            ContentConductorViewModel contentConductorViewModel)
        {
            Menu = menuViewModel;
            _contentConductorViewModel = contentConductorViewModel;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            ActivateItem(_contentConductorViewModel);
        }
    }
}
