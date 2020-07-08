using System;
using System.IO;
using System.Reflection;

namespace IA.BooksInventory.Common
{
    public static class AssemblyExtensions
    {
        public static string GetLocation(this Assembly @this)
        {
            return Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(@this.CodeBase).Path));
        }
    }
}
