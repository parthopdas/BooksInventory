using System.Collections.Generic;
using IA.BooksInventory.Application.Books.Queries.GetAllBooks;

namespace IA.BooksInventory.UI.Messages
{
    public sealed class RefreshBooks
    {
        public ICollection<BookVM> Books { get; internal set; }
    }
}
