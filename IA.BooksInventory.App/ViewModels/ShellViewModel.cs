using Caliburn.Micro;

namespace IA.BooksInventory.App.ViewModels
{
    public sealed class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly ContentConductorViewModel _contentConductorViewModel;

        public ShellViewModel(ContentConductorViewModel contentConductorViewModel)
        {
            _contentConductorViewModel = contentConductorViewModel;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            ActivateItem(_contentConductorViewModel);
        }
    }
}
