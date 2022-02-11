using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TicketSystem.Classes
{
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>Converts a Boolean value to a <see cref="T:System.Windows.Visibility" /> enumeration value.</summary>
        /// <param name="value">The Boolean value to convert. This value can be a standard Boolean value or a nullable Boolean value.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = false;
            if (value == null || value is string)
                return Visibility.Collapsed;
            if (value is bool)
                flag = (bool) value;
            else if (value is bool?)
            {
                bool? nullable = (bool?) value;
                flag = nullable.HasValue && nullable.Value;
            }
            return (object) (Visibility) (flag ? 0 : 2);
        }

        /// <summary>Converts a <see cref="T:System.Windows.Visibility" /> enumeration value to a Boolean value.</summary>
        /// <param name="value">A <see cref="T:System.Windows.Visibility" /> enumeration value. </param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility)
                return (object) ((Visibility) value == Visibility.Visible);
            if (value == null || value is string)
                return false;
            return (object) false;
        }
    }
}
