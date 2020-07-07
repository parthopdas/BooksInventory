using System.Collections.Generic;
using MediatR;

namespace IA.BooksInventory.Application.Books.Queries.GetAllBooks
{
    public sealed class GetAllBooksQuery : IRequest<ICollection<BookVM>>
    {
        public string CsvFile { get; set; }
    }
}
