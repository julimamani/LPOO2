using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class TipoVehiculo
    {
        public int TVCodigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Tarifa { get; set; }

        public TipoVehiculo(int tvCodigo, string descripcion, decimal tarifa)
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
