using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;
using System.Data;
using UberFrba.Utils;

namespace UberFrba.Dao
{
    class DAORoles
    {

        public List<Rol> getRolesByUserId(Int32 userId)
        {

                List<Rol> roles = new List<Rol>();
                DataBaseConnector db = DataBaseConnector.getInstance();
                DataTable dt = db.select_query("Select r.id,r.Descripcion from FSOCIETY.Roles as r join FSOCIETY.UsuariosRoles as ur on r.Id = ur.IdRol where r.Habilitado = 1 and ur.IdUsuario = '" + userId + "'");

                foreach (DataRow row in dt.Rows)
                {
                    roles.Add(new Rol(row));
                }

                return roles;
           

            
        }

    }
}
