using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;

namespace IA.BooksInventory.UI.Common
{
    [ValueConversion(typeof(double), typeof(Brush))]
    public class PriceBackgroundBrushConverter : IValueConverter
    {
        private const int MaxPrice = 100;

        private static PriceBackgroundBrushConverter _instance;
        public static PriceBackgroundBrushConverter Instance => _instance ?? (_instance = new PriceBackgroundBrushConverter());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var price = (double)value;

            var alpha = price > MaxPrice ? 255 : (price / MaxPrice) * 255;

            var color = Color.FromArgb((byte)alpha, 255, 0, 0);
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
