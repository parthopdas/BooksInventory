using System;
using System.Reflection;
using System.Threading.Tasks;
using Caliburn.Micro;
using IA.BooksInventory.Application.Books.Commands.ClearOutOfStock;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;
using IA.BooksInventory.UI.Messages;
using IA.BooksInventory.Common;
using Microsoft.Win32;

namespace IA.BooksInventory.UI.ViewModels
{
    public sealed class MenuViewModel : BaseViewModel
    {
        private bool _canClearOutOfStockItems;
        private string _currentCsvFile;

        private readonly IEventAggregator _eventAggregator;
        private readonly Func<string> _filePicker;
        private string CurrentCsvFile
        {
            get => _currentCsvFile;
            set
            {
                _currentCsvFile = value;
                CanClearOutOfStockItems = !string.IsNullOrEmpty(_currentCsvFile);
            }
        }

        public bool CanClearOutOfStockItems
        {
            get => _canClearOutOfStockItems;
            set => Set(ref _canClearOutOfStockItems, value);
        }

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
            CurrentCsvFile = _filePicker();
            if (CurrentCsvFile != null)
            {
                var books = await Mediator.Send(new GetAllBooksQuery { CsvFile = CurrentCsvFile });

                await _eventAggregator.PublishOnUIThreadAsync(new RefreshBooks { Books = books });
            }
        }

        public void Exit()
        {
            System.Windows.Application.Current.MainWindow.Close();
        }

        public async Task ClearOutOfStockItems()
        {
            await Mediator.Send(new ClearOutOfStockCommand());
            var books = await Mediator.Send(new GetAllBooksQuery { CsvFile = CurrentCsvFile });

            await _eventAggregator.PublishOnUIThreadAsync(new RefreshBooks { Books = books });
        }

        private static string GetFileFromUser()
        {
            var dlg = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "Csv documents (.csv)|*.csv",
                InitialDirectory = Assembly.GetExecutingAssembly().GetLocation(),
            };

            var result = dlg.ShowDialog();

            return result.GetValueOrDefault() ? dlg.FileName : null;
        }
    }
}
