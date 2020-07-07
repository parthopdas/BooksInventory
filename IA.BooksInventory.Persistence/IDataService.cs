using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IA.BooksInventory.Domain.Entities;

namespace IA.BooksInventory.Persistence
{
    public interface IDataService
    {
        Task<IQueryable<Book>> GetAllBooks(string csvFile);

        Task RemoveOutOfStockBooks();
    }
}
