﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TipoVehiculo
    {
        public string TVCodigo { get; set; }
        public string Descripcion { get; set; }
        public string Tarifa { get; set; }

        public TipoVehiculo(string tvCodigo, string descripcion, string tarifa)
        {
            TVCodigo = tvCodigo;
            Descripcion = descripcion;
            Tarifa = tarifa;
        }
        public TipoVehiculo()
        {
     
        }
    }
}
