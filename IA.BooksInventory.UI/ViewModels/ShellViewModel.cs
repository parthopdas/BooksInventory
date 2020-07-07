using Caliburn.Micro;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;
using MediatR;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly IMediator _mediator;
        private readonly ContentConductorViewModel _contentConductorViewModel;

        public MenuViewModel Menu { get; }

        public ShellViewModel(
            IMediator mediator,
            MenuViewModel menuViewModel,
            ContentConductorViewModel contentConductorViewModel)
        {
            _mediator = mediator;

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
