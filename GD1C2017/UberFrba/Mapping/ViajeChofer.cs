using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class ViajeChofer : ViajePersona
    {   
        private ViajeAuto auto;

        public ViajeChofer(DataRow row) : base(row) {
            
            this.auto = new ViajeAuto(row);
        }

        public ViajeAuto Auto {
            get { return this.auto; }
            set { this.auto = value; }
        }

    }
}
