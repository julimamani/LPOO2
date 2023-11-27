using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Sector
    {
        public int sectorCodigo { get; set; }
        public int  zonaCodigo { get; set; }
        public string identificador { get; set; }
        public bool habilitado { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaHoraUltima { get; set; }

        public Sector() { }

        public Sector(int zona, string id, bool habilitadoSector, string des, DateTime fecha)
        {
            zonaCodigo = zona;
            identificador = id;
            habilitado = habilitadoSector;
            descripcion = des;
            fechaHoraUltima = fecha;
        }

    }
}
