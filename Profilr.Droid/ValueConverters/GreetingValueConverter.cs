using System;
using System.Globalization;
using MvvmCross.Converters;

namespace Profilr.Droid.ValueConverters
{
    public class GreetingValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Hello World, it is now {value.ToLocalTime().ToString()}";
        }
    }
}
