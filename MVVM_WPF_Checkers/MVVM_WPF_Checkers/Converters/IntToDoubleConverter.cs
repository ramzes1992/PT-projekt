using System;
using System.Windows.Data;

namespace MVVM_WPF_Checkers.Converters
{
    public class IntToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value!= null)
            {
                return System.Convert.ToDouble(value);  
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value != null)
            {
                return System.Convert.ToInt32(value);
            }

            return 0;
        }
    }
}
