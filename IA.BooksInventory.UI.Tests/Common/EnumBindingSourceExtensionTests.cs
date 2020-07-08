using System;
using FluentAssertions;
using IA.BooksInventory.UI.Common;
using Xunit;

namespace IA.BooksInventory.UI.Tests.Common
{
    public class EnumBindingSourceExtensionTests
    {
        [Fact]
        public void CheckProvideValue()
        {
            var ebse = new EnumBindingSourceExtension
            {
                EnumType = typeof(StringSplitOptions),
            };

            var values = ebse.ProvideValue(null);

            values.Should().BeEquivalentTo(new[] { StringSplitOptions.RemoveEmptyEntries, StringSplitOptions.None });
        }
    }
}
