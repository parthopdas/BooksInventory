using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;
using IA.BooksInventory.Domain.Enums;
using IA.BooksInventory.UI.Messages;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class HomeViewModel : Screen, IHandle<RefreshBooks>
    {
        private ICollection<BookVM> _books;
        private BookVM _selectedItem;

        public HomeViewModel()
        {
            if (Execute.InDesignMode)
            {
                LoadDesignData();
            }
        }

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
        }

        public ICollection<BookVM> Books
        {
            get => _books;
            set => Set(ref _books, value);
        }

        public BookVM SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }


        public void Handle(RefreshBooks refreshBooks)
        {
            Books = refreshBooks.Books;
        }

        public void ShowDescription()
        {
            if (SelectedItem == null)
            {
                return;
            }

            MessageBox.Show($"Title: {SelectedItem.Title}\nDescription: {SelectedItem.Description}", "Book description", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LoadDesignData()
        {
            Books = new[]
            {
                new BookVM
                {
                    Title = "Gravity's Rainbow",
                    Author = "Thomas Pynchon",
                    Year = 1973,
                    Price = 19.99,
                    InStock = true,
                    Binding = Binding.Paperback,
                    Description = "Winner of the 1973 National Book Award, Gravity's Rainbow is a postmodern epic, a work as exhaustively significant to the second half of the 20th century as Joyce's Ulysses was to the first. Its sprawling, encyclopedic narrative, and penetrating analysis of the impact of technology on society make it an intellectual tour de force.",
                },
                new BookVM
                {
                    Title = "Ignition!: An informal history of liquid rocket propellants",
                    Author = "John Drury Clark",
                    Year = 1972,
                    Price = 34.99,
                    InStock = false,
                    Binding = Binding.Unknown,
                    Description = "Ignition! is the inside story of the Cold War era search for a rocket propellant that could be trusted to take man into space. A favorite of Tesla and SpaceX founder Elon Musk, listeners will want to tune into this \"really good book on rocket[s],\" available for the first time in audio.",
                },
            };

        }
    }
}
