using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class Funcionalidades
    {
        private Int32 id;
        private String description;
        private String formName;
        private String parent;

        public Funcionalidades(Int32 id, String description,String form, String parent) {
            this.id = id;
            this.description = description;
            this.formName = form;
            this.parent = parent;
        }

        public Funcionalidades(DataRow row)
        {
            this.id = Convert.ToInt32(row["id"]);
            this.description = Convert.ToString(row["Descripcion"]);
            this.formName = Convert.ToString(row["FormName"]);
            this.parent = Convert.ToString(row["Padre"]);
        }


        public Int32 getId() {
            return this.id;
        }

        public String getDescription() {
            return this.description;
        }

        public String getParent() {
            return this.parent;
        }

        public String getFormName()
        {
            return this.formName;
        }

    }
}
