using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class Rol
    {
        private Int32 id;
        private String description;

        public Rol(Int32 id, String description) {
            this.id = id;
            this.description = description;
        }

        public Rol(DataRow row) {
            this.id = Convert.ToInt32(row["id"]);
            this.description = Convert.ToString(row["Descripcion"]);
        }

        public Int32 getId() {
            return id;
        }

        public String getDescription() {
            return description;
        }

        public override string ToString()
        {
            return this.description;
        }

    }


}
