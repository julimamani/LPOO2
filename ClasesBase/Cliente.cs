using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Cliente
    {
        public int ClienteDNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Cliente(int clienteDNI, string apellido, string nombre, string telefono)
        {
            ClienteDNI = clienteDNI;
            Apellido = apellido;
            Nombre = nombre;
            Telefono = telefono;
        }

        public Cliente()
        {

        }
    }
}
