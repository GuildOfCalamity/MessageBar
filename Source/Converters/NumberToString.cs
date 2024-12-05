using System;
using System.Globalization;
using System.Windows.Data;

namespace MessageBarDemo.Converters;

public class NumberToString : IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse(value?.ToString(), out double val))
        {
            if (parameter != null)
                return $"{parameter} speed is set to {(val == 0 ? "indefinite" : $"{val:N0} ms")}";
            else
                return $"Speed is set to {(val == 0 ? "indefinite" : $"{val:N0} ms")}";
        }
        return $"{value}";
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var strValue = value as string;
        if (strValue != null)
        {
            double result;
            var converted = double.TryParse(strValue, out result);
            if (converted)
                return result;
        }
        return null;
    }
}