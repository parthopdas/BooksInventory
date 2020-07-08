using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace IA.BooksInventory.UI.Common
{
    public class BooleanConverter<T> : IValueConverter
    {
        protected BooleanConverter(T trueValue, T falseValue)
        {
            True = trueValue;
            False = falseValue;
        }

        public T True { get; set; }

        public T False { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool val && val ? True : False;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T val && EqualityComparer<T>.Default.Equals(val, True);
        }
    }
}
