using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UberFrba.Mapping
{
    class ViajePersona
    {   
        private Int32 id;
        private String name;
        private String lastname;
        private String doc;
        private String phone;
        private String email;
        private DateTime birthday;
        private String prettyName;


        public ViajePersona(DataRow row)
        {
            this.id = Convert.ToInt32(row["Id"]);
            this.name = Convert.ToString(row["Nombre"]);
            this.lastname = Convert.ToString(row["Apellido"]);
            this.doc = Convert.ToString(row["DNI"]);
            this.phone = Convert.ToString(row["Telefono"]);
            this.email = Convert.ToString(row["Email"]);
            this.birthday = Convert.ToDateTime(row["Fecha"]);
            this.prettyName = this.name.ToUpper() + " " + this.lastname.ToUpper();
        }

        public Int32 getId() {
            return this.id;
        }

        public String getName() {
            return this.name;
        }

        public String getLastname() {
            return this.lastname;
        }

        public String getDoc()
        {
            return this.doc;
        }

        public String getPhone()
        {
            return this.phone;
        }

        public String getEmail()
        {
            return this.email;
        }

        public DateTime getDate()
        {
            return this.birthday;
        }

        public String getPrettyName() {
            return this.prettyName;
        }

        public override string ToString()
        {
            return this.prettyName;
        }
    }
}
