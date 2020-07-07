using IA.BooksInventory.Domain.Enums;

namespace IA.BooksInventory.Application.Books.Queries.GetAllBooks
{
    public sealed class BookVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int Year { get; set; }

        public Binding Binding { get; set; }

        public bool InStock { get; set; }

        public string Description { get; set; }
    }
}
