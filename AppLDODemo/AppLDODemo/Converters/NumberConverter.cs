using System;
using System.Globalization;
using System.Windows.Data;


namespace AppLDODemo.Converters
{
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            long input = System.Convert.ToInt64(((string)value).Replace(" ", ""));

            var formatter = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            formatter.NumberGroupSeparator = " ";

            string formatted = input.ToString("#,0", formatter);

            return formatted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((string)value).Replace(" ", "");
        }
    }
}
