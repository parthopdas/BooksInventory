using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using IA.BooksInventory.Domain.Entities;
using IA.BooksInventory.Domain.Enums;
using Xunit;

namespace IA.BooksInventory.Persistence.Tests
{
    public class DataServiceTests
    {
        public static string[] SampleCsvContents = new[]
        {
            "Title; Author; Year; Price; In Stock; Binding; Description",
            "Gravity's Rainbow;Thomas Pynchon;1973;19,99;yes;Paperback;Winner of the 1973 National Book Award, Gravity's Rainbow is a postmodern epic, a work as exhaustively significant to the second half of the 20th century as Joyce's Ulysses was to the first. Its sprawling, encyclopedic narrative, and penetrating analysis of the impact of technology on society make it an intellectual tour de force.",
            "Ignition!: An informal history of liquid rocket propellants;John Drury Clark;1972;34,99;no;Unknown;\"Ignition! is the inside story of the Cold War era search for a rocket propellant that could be trusted to take man into space.A favorite of Tesla and SpaceX founder Elon Musk, listeners will want to tune into this \"\"really good book on rocket[s], \"\" available for the first time in audio.\"\"",
        };

        public static Book[] SampleBooks = new[]
        {
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
            new Book
            {
                Title = "Ignition!: An informal history of liquid rocket propellants",
                Author = "John Drury Clark",
                Year = 1972,
                Price = 34.99,
                InStock = false,
                Binding = Binding.Unknown,
                Description = "\"Ignition! is the inside story of the Cold War era search for a rocket propellant that could be trusted to take man into space.A favorite of Tesla and SpaceX founder Elon Musk, listeners will want to tune into this \"\"really good book on rocket[s], \"\" available for the first time in audio.\"\"",
            },
        };

        [Fact]
        public async Task TestGetAllBooks()
        {
            var db = new DataService(_ => SampleCsvContents);

            var books = await db.GetAllBooks("fileName");

            books.Should().BeEquivalentTo(
                SampleBooks,
                option => option.Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 1e-4)).WhenTypeIs<double>());

        }

        [Fact]
        public async Task TestClearOutOfStockItems()
        {
            var db = new DataService(_ => SampleCsvContents);

            await db.GetAllBooks("fileName");
            await db.ClearOutOfStockBooks();
            var books = await db.GetAllBooks("fileName");

            books.Should().BeEquivalentTo(
                SampleBooks.Where(b => b.InStock),
                option => option.Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 1e-4)).WhenTypeIs<double>());

        }

        [Fact]
        public async Task TestGetAllAfterClearOutOfStock()
        {
            var db = new DataService(_ => SampleCsvContents);

            await db.GetAllBooks("fileName");
            await db.ClearOutOfStockBooks();
            await db.GetAllBooks("fileName");
            var books = await db.GetAllBooks("fileName");

            books.Should().BeEquivalentTo(
                SampleBooks,
                option => option.Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 1e-4)).WhenTypeIs<double>());

        }
    }
}
