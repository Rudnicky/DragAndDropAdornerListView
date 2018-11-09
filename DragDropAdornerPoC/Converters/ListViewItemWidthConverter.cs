using System;
using System.Globalization;
using System.Windows.Data;

namespace DragDropAdornerPoC.Converters
{
    public class ListViewItemWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var input = (double)value;
                var output = input - 15.0;

                return output;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
