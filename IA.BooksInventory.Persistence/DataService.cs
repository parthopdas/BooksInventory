using System;
using System.Linq;
using System.Threading.Tasks;
using IA.BooksInventory.Domain.Entities;

namespace IA.BooksInventory.Persistence
{
    public sealed class DataService : IDataService
    {
        public async Task<IQueryable<Book>> GetAllBooks(string csvFile)
        {
            var books = new Book[]
            {
                new Book
                {
                    Title = $"Test book from {csvFile}",
                }
            };

            return await Task.FromResult(books.AsQueryable());
        }

        public Task RemoveOutOfStockBooks()
        {
            throw new NotImplementedException();
        }
    }
}
