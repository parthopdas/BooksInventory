using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IA.BooksInventory.Domain.Entities;

namespace IA.BooksInventory.Persistence
{
    public sealed class DataService : IDataService
    {
        private static Func<string, IEnumerable<string>> FileReader = File.ReadAllLines;
        private Func<string, IEnumerable<string>> _fileReader;
        private bool _clearOutOfStock;

        public DataService()
            : this(FileReader)
        {
        }

        public DataService(Func<string, IEnumerable<string>> fileReader)
        {
            _fileReader = fileReader;
        }

        public async Task<IEnumerable<Book>> GetAllBooks(string csvFile)
        {
            var books =
                _fileReader(csvFile)
                    .Skip(1)
                    .Select(ModelExtensions.ToBook)
                    .Where(b => !_clearOutOfStock || b.InStock)
                    .ToList();

            _clearOutOfStock = false;

            return await Task.FromResult(books);
        }

        public Task ClearOutOfStockBooks()
        {
            _clearOutOfStock = true;

            return Task.CompletedTask;
        }
    }
}
