using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;
using System.Data;

namespace UberFrba.Mapping
{
    class Usuario
    {
        private Int32 id;
        private String username = "";
        private String pass = "";
        private Int32 idPersona;
        private Int32 reintentos;
        private Rol rol;

        public Usuario() { 
        }

        public Usuario(Int32 id, String username, String pass, Int32 idPersona) {
            this.id = id;
            this.username = username;
            this.pass = pass;
            this.idPersona = idPersona;
            this.reintentos = 0;
        }

        public Usuario(DataRowCollection rows) {
            foreach (DataRow r in rows)
            {
                this.username = Convert.ToString(r["Username"]);
                this.id = Convert.ToInt32(r["id"]);
                this.pass = Convert.ToString(r["Password"]);
                this.idPersona = Convert.ToInt32(r["idPersona"]);
                this.reintentos = Convert.ToInt32(r["Reintentos"]);
            }
        }

        public Boolean passwordEquals(String pass) {
            return this.pass.ToUpper().Equals(pass);
        }

        public Int32 getId() {
            return this.id;
        }

        public String getUsername() {
            return this.username;
        }

        public String getPassword() {
            return this.pass;
        }

        public Int32 getIdPersona() {
            return this.idPersona;
        }

        public Rol getRol() {
            return this.rol;
        }

        public void setRol(Rol rol) {
            this.rol = rol;
        }
        
        public void setIntentos(Int32 i) {
            this.reintentos = i;
        }

        public Int32 getIntentos() {
            return this.reintentos;
        }

        public Boolean isBloqued() {
            return reintentos.Equals(3);
        }

        public void incrementarReintentos() {
            if (reintentos < 3) {
                reintentos = reintentos + 1;
            }
        }

        public void resetearReintentos() {
            this.reintentos = 0;
        }
    }
}
