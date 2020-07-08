using System;
using System.Globalization;
using IA.BooksInventory.Domain.Entities;
using IA.BooksInventory.Domain.Enums;

namespace IA.BooksInventory.Persistence
{
    public static class ModelExtensions
    {
        private static char[] CsvFieldSeperator = new[] { ';' };

        public static Book ToBook(this string str)
        {
            var fields = str.Split(CsvFieldSeperator, StringSplitOptions.None);

            return new Book
            {
                Title = fields[0],
                Author = fields[1],
                Year = int.Parse(fields[2], NumberStyles.Integer, CultureInfo.InvariantCulture),
                Price = float.Parse(fields[3].Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture),
                InStock = string.Equals(fields[4], "yes", StringComparison.Ordinal),
                Binding = (Binding)Enum.Parse(typeof(Binding), fields[5]),
                Description = fields[6],
            };
        }
    }
}
