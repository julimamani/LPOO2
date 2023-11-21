using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        public string TicketNro
        {
            get;
            set;

        }

        public DateTime FechaHoraEnt
        {
            get;
            set;
        }

        public DateTime? FechaHoraSal
        {
            get;
            set;
        }

        public int ClienteDNI
        {
            get;
            set;
        }

        public int TVCodigo
        {
            get;
            set;
        }

        public string Patente
        {
            get;
            set;
        }

        public int SectorCodigo
        {
            get;
            set;
        }

        public double Duracion
        {
            get;
            set;
        }

        public decimal Tarifa
        {
            get;
            set;
        }

        public decimal Total
        {
            get;
            set;
        }
    }
}
