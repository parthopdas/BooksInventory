using Caliburn.Micro;
using MediatR;

namespace IA.BooksInventory.UI
{
    public abstract class BaseViewModel : PropertyChangedBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = ((AppBootstrapper)App.Current.FindResource(nameof(AppBootstrapper))).GetMediator());
    }
}
