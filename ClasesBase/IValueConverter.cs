using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Globalization; 

namespace ClasesBase
{
    interface IValueConverter
    {
        object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
