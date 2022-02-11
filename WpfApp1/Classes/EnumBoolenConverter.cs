using System;
using System.Globalization;
using System.Windows.Data;
using TicketSystem.Classes.Enums;

namespace TicketSystem.Classes
{
    public class EnumBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimerTypeEnum)value).Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? (int)parameter : Binding.DoNothing;
        }
    }
}
