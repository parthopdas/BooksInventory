using System;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;
using IA.BooksInventory.UI.Messages;
using Microsoft.Win32;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class MenuViewModel : BaseViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly Func<string> _filePicker;

        public MenuViewModel(IEventAggregator eventAggregator)
            : this(eventAggregator, GetFileFromUser)
        {
        }

        public MenuViewModel(IEventAggregator eventAggregator, Func<string> filePicker)
        {
            _eventAggregator = eventAggregator;
            _filePicker = filePicker;
        }

        public async Task Open()
        {
            var file = _filePicker();
            if (file != null)
            {
                var books = await Mediator.Send(new GetAllBooksQuery { CsvFile = file });

                await _eventAggregator.PublishOnUIThreadAsync(new RefreshBooks { Books = books });
            }
        }

        public void Exit()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }

        public void ClearOutOfStockItems()
        {
            MessageBox.Show("Clear out of stock items");
        }

        private static string GetFileFromUser()
        {
            var dlg = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "Csv documents (.csv)|*.csv"
            };

            var result = dlg.ShowDialog();

            return result.GetValueOrDefault() ? dlg.FileName : null;
        }
    }
}
