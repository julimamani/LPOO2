using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class SectorOcupado
    {
        public string Zona { get; set; }
        public string Sector { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
        public string ApellidoNombreCliente { get; set; }
        public string TipoVehiculo { get; set; }
        public string Patente { get; set; }
        public TimeSpan TiempoTranscurrido { get; set; }
    }
}
