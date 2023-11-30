using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

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
