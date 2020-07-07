using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace IA.BooksInventory.App.ViewModels
{
    public sealed class MenuViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void Open()
        {
            MessageBox.Show("Open");
        }

        public void Exit()
        {
            Application.Current.MainWindow.Close();
        }

        public void ClearOutOfStockItems()
        {
            MessageBox.Show("Clear out of stock items");
        }
    }
}
