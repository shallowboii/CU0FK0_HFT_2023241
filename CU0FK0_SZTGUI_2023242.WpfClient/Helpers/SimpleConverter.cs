using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CU0FK0_SZTGUI_2023242.WpfClient.Helpers
{
    [ValueConversion(typeof(string),(typeof(double)))]
    class SimpleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double returnedValue;

            if (double.TryParse((string)value, out returnedValue))
            {
                return returnedValue;
            }

            throw new Exception("The text is not a number");
        }
    }
}
