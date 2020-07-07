using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;
using IA.BooksInventory.UI.Messages;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class MenuViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public MenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public async Task Open()
        {
            var books = await Mediator.Send(new GetAllBooksQuery { CsvFile = @"c:\xxx.csv" });

            await _eventAggregator.PublishOnUIThreadAsync(new RefreshBooks { Books = books });
        }

        public void Exit()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }

        public void ClearOutOfStockItems()
        {
            MessageBox.Show("Clear out of stock items");
        }
    }
}
