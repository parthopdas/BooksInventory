using System.Collections.Generic;
using FluentAssertions;
using IA.BooksInventory.Domain.Entities;
using IA.BooksInventory.Domain.Enums;
using Xunit;

namespace IA.BooksInventory.Persistence.Tests
{
    public class ModelExtensionsTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CheckConversion(string str, Book expected)
        {
            var book = str.ToBook();

            book.Should().BeEquivalentTo(expected, option => option.Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 1e-6)).WhenTypeIs<double>());
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    "Gravity's Rainbow;Thomas Pynchon;1973;19,99;yes;Paperback;Winner of the 1973 National Book Award, Gravity's Rainbow is a postmodern epic, a work as exhaustively significant to the second half of the 20th century as Joyce's Ulysses was to the first. Its sprawling, encyclopedic narrative, and penetrating analysis of the impact of technology on society make it an intellectual tour de force.",
                    new Book
                    {
                        Title = "Gravity's Rainbow",
                        Author = "Thomas Pynchon",
                        Year = 1973,
                        Price = 19.99,
                        InStock = true,
                        Binding = Binding.Paperback,
                        Description = "Winner of the 1973 National Book Award, Gravity's Rainbow is a postmodern epic, a work as exhaustively significant to the second half of the 20th century as Joyce's Ulysses was to the first. Its sprawling, encyclopedic narrative, and penetrating analysis of the impact of technology on society make it an intellectual tour de force.",
                    },
                },
            };
    }
}
