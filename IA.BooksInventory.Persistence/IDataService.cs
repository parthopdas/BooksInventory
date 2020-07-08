using System.Collections.Generic;
using System.Threading.Tasks;
using IA.BooksInventory.Domain.Entities;

namespace IA.BooksInventory.Persistence
{
    public interface IDataService
    {
        Task<IEnumerable<Book>> GetAllBooks(string csvFile);

        Task ClearOutOfStockBooks();
    }
}
