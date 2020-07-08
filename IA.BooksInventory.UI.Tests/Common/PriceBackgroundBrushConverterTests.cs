using System.Collections.Generic;
using FluentAssertions;
using IA.BooksInventory.UI.Common;
using Xunit;

namespace IA.BooksInventory.UI.Tests.Common
{
    public class PriceBackgroundBrushConverterTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CheckConversion(double price, string brushColor)
        {
            var converter = new PriceBackgroundBrushConverter();

            var brush = converter.Convert(price, null, null, null);

            brush.ToString().Should().Be(brushColor);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 0, "#00FF0000", },
                new object[] { 50, "#7FFF0000", },
                new object[] { 200, "#FFFF0000", },
            };
    }
}
