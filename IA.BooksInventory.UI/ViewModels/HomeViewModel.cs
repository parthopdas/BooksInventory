using System.Collections.Generic;
using Caliburn.Micro;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;
using IA.BooksInventory.UI.Messages;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class HomeViewModel : Screen, IHandle<RefreshBooks>
    {
        private ICollection<BookVM> _books;

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public ICollection<BookVM> Books
        {
            get => _books;
            set => Set(ref _books, value);
        }

        public void Handle(RefreshBooks refreshBooks)
        {
            Books = refreshBooks.Books;
        }
    }
}
