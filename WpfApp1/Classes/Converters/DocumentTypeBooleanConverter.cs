using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using TicketSystem.Classes.Enums;

namespace TicketSystem.Classes.Converters
{
    public class DocumentTypeBooleanConverter : IValueConverter
    {       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((MagazineDocumentTypeEnum)value).Equals(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (short)parameter;
            return ((bool)value) ? (short)parameter : 0;
        }
    }
}
