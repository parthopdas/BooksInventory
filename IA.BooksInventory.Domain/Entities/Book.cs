using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using IA.BooksInventory.Domain.Enums;

namespace IA.BooksInventory.Domain.Entities
{
    [DebuggerDisplay("{Id}: {Title}")]
    public sealed class Book : BaseEntity
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public int Year { get; set; }

        public Binding Binding { get; set; }

        public bool InStock { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }
    }
}
