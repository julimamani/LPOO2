using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    class Rol
    {
        private int rol_codigo;
        private string rol_descripcion;

        public Rol(int codigo,string descripcion){
            rol_codigo = codigo;
            rol_descripcion = descripcion;
        }

        public Rol() { 
        
        }

        public int codigo
        {
            get { return rol_codigo; }
            set { rol_codigo = value; }
        }
        public string descripcion
        {
            get { return rol_descripcion; }
            set { rol_descripcion = value; }
        }
       
    }
}
