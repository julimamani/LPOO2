﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ClasesBase
{
    public class ConversorDeEstados : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
             if (value == null)
            {
                return new SolidColorBrush(Colors.Transparent);
            }else{
                 string min = value.ToString();
                 int minutos = int.Parse(min);
            if (minutos == 0)
                return new SolidColorBrush(Colors.Green); // Sector libre (verde)
            else if (minutos <= 30)
                return new SolidColorBrush(Colors.LightCoral); // Sector ocupado (rojo claro)
            else if (minutos <= 60)
                return new SolidColorBrush(Colors.Coral); // Sector ocupado (rojo)
            else
                return new SolidColorBrush(Colors.DarkRed); // Sector ocupado (rojo oscuro)
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}