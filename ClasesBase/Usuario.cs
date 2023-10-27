using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario : IValueConverter
    {
        public string UserName;
        public string Password;
        public string Apellido;
        public string Nombre;
        public string Rol;

        public Usuario(string username, string pass, string apellido, string nombre, string rol) {
            UserName = username;
            Password = pass;
            Apellido = apellido;
            Nombre = nombre;
            Rol = rol;
        }

        public Usuario()
        {
     
        }


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
