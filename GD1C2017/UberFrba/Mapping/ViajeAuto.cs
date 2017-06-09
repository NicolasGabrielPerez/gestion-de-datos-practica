using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class ViajeAuto
    {
        private Int32 id;
        private String patente;
        private String marca;
        private String modelo;

        public ViajeAuto(DataRow row)
        {
            this.patente = Convert.ToString(row["Patente"]);
            this.marca = Convert.ToString(row["Marca"]);
            this.modelo = Convert.ToString(row["Modelo"]);
        }

        public Int32 Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Patente {
            get { return this.patente; }
            set { this.patente = value; }
        }

        public String Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }

        public String Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
    }
}
