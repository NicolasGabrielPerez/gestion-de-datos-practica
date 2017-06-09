using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Mapping
{
    class Viajes
    {
        private ViajePersona chofer;
        private ViajePersona cliente;
        private DateTime inicio;
        private DateTime fin;
        private Int32 km;

        public Viajes(ViajePersona c, ViajePersona cl, DateTime i, DateTime f, Int32 km)
        {
            this.chofer = c;
            this.cliente = cl;
            this.inicio = i;
            this.fin = f;
            this.km = km;
        }

        public Viajes()
        {
            
        }

        public ViajePersona Chofer
        {
            get { return this.chofer; }
            set { this.chofer = value; }
        }

        public ViajePersona Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        public DateTime Inicio
        {
            get { return this.inicio; }
            set { this.inicio = value; }
        }

        public DateTime Fin
        {
            get { return this.fin; }
            set { this.fin = value; }
        }

        public Int32 KM
        {
            get { return this.km; }
            set { this.km = value; }
        }
    }
}
