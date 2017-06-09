using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;
using System.Data;
using UberFrba.Mapping;
using UberFrba.Abm_Cliente;

namespace UberFrba.Dao
{
    class DAOUsers
    {
        private DataBaseConnector db;

        public DAOUsers() {
            this.db = DataBaseConnector.getInstance();
        }

        public Usuario getUser(String username)
        {       
               DataTable dt = db.select_query("Select Id,Username,Password,IdPersona,Reintentos from FSOCIETY.Usuarios where Username = '" + username + "'");

                if (dt.Rows.Count == 1)
                {
                    return new Usuario(dt.Rows);
                }
                else
                {
                    if (dt.Rows.Count > 1)
                    {
                        throw new Exception("Se produjo un problema al intentar iniciar sesion por favor concatese con el administrador");

                    }
                    else
                    {
                        throw new Exception("El usuario ingresado es inexistente");
                    }
                }
        }

        public void incrementRetries(Usuario user) {
            user.incrementarReintentos();
            updateUserRetries(user);    
        }

        public void resetRetries(Usuario user) {
            user.resetearReintentos();
            updateUserRetries(user);
        }

        private void updateUserRetries(Usuario user){
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@reintentos", user.getIntentos().ToString());
            dic.Add("idUsuario", user.getId().ToString());
            db.executeQueryWithParameters("update FSOCIETY.Usuarios set Reintentos = @reintentos where id = @idUsuario",dic);
        }
    }
}
