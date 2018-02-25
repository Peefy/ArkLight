using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using ArkLight.Util;

namespace ArkLight.Example.Converters
{
    public class NumberToRmbStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = value as string;
            try
            {
                return RmbUtil.CmycurD(number);
            }
            catch 
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
