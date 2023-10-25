using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
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
       
    }
}
