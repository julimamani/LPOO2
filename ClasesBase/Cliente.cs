using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente:IDataErrorInfo
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

        // Metodos del IdataErrorInfo
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "Apellido")
                {
                    if (String.IsNullOrEmpty(Apellido))
                        result = "Ingrese Apellido";
                }
                else
                {
                    if (columnName == "Nombre")
                    {
                        if (String.IsNullOrEmpty(Nombre))
                        {
                            result = "Ingrese Nombre";
                        }
                    }
                    else
                    {
                        if (columnName == "Telefono")
                        {
                            if (String.IsNullOrEmpty(Telefono) || Telefono.Length < 10)
                            {
                                result = "No se permite campo vacio o menos a 10 digitos";
                            }
                        }
                        else
                        {
                            if (columnName == "ClienteDNI")
                            {
                                if (ClienteDNI == 8)
                                {
                                    result = "No se permite campo vacio o menos a 8 digitos";
                                }
                            }
                        }
                    }
                }

                return result;
            }
        }
    }
}
