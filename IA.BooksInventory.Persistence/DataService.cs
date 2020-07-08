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
        public async Task<IEnumerable<Book>> GetAllBooks(string csvFile)
        {
            var books = File.ReadAllLines(csvFile).Skip(1).Select(ModelExtensions.ToBook);

            return await Task.FromResult(books);
        }

        public Task RemoveOutOfStockBooks()
        {
            throw new NotImplementedException();
        }
    }
}
