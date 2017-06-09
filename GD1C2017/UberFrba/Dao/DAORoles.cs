using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;
using System.Data;
using UberFrba.Utils;
using System.Windows.Forms;

namespace UberFrba.Dao
{
    class DAORoles
    {
        private DataBaseConnector connector;

        public DAORoles() {
            this.connector = DataBaseConnector.getInstance();
        }

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

        public DataTable buscarRol(String nombreRol)
        {
            if (nombreRol != "")
            {
                return connector.select_query(getSelectRolQuery(nombreRol));
            }
            else
            {
                return buscarTodosLosRoles();
            }
        }

        public DataTable buscarTodosLosRoles()
        {
            return connector.select_query(getAllRolQuery());
        }

        private String getAllRolQuery()
        {
            return "select rol.Id, rol.Descripcion, rol.Habilitado from FSOCIETY.Roles rol ";
        }

        private String getSelectRolQuery(String nombre)
        {
            return getAllRolQuery() + "where rol.Descripcion like '%" + nombre + "%'";
        }

        private String GetAllFunctionalitiesQuery()
        {
            return "SELECT distinct(func.Descripcion) as 'Funcionalidades', '0' as 'relacion' FROM FSOCIETY.Funcionalidades func, FSOCIETY.RolFuncionalidades rolfunc, FSOCIETY.Roles rol ";
        }
        
        public DataTable getAllFuncionalitiesByRol(int idRol)
        {
            String query = "SELECT distinct(func.Descripcion)as 'Funcionalidades', (select '1' from FSOCIETY.RolFuncionalidades rf where rf.IdFuncionalidad = func.Id and rf.IdRol = '" + idRol + "') as 'relacion' FROM FSOCIETY.Funcionalidades func, FSOCIETY.RolFuncionalidades rolfunc, FSOCIETY.Roles rol";
            return connector.select_query(query);
        }

        public DataTable getAllFuncionalities()
        {
            return connector.select_query(GetAllFunctionalitiesQuery());
        }

        internal bool update(List<String> add, int idRol, String rolDesc, bool habilitado)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@id", idRol);
            dic.Add("@nombre", rolDesc);
            dic.Add("@habilitado",habilitado);

            this.deleteActualFunctionalities(idRol);
            this.insertNewFunctionalities(add, idRol);

            connector.executeProcedureWithParameters("FSOCIETY.sp_update_roles", dic);

            return true;
        }

        internal bool insert(List<String> add, String rol, bool habilitado)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@nombre", rol);
            dic.Add("@habilitado", habilitado);

            connector.executeProcedureWithParameters("FSOCIETY.sp_insert_rol", dic);
            int idRol = this.getRolIdByDescription(rol);
            this.insertNewFunctionalities(add, idRol);
            
            return true;
        }

        public int getRolIdByDescription(String rol)
        {
            DataTable result = connector.select_query("select Id from FSOCIETY.Roles where Descripcion = '" + rol + "'");
            DataRow row = result.Rows[0];
            return (Int32)row["Id"];
        }

        private void deleteActualFunctionalities(int idRol)
        {
                Dictionary<String, Object> dicSacadas = new Dictionary<String, Object>();
                dicSacadas.Add("@idrol", idRol);
                connector.executeProcedureWithParameters("FSOCIETY.sp_delete_all_funcionalidades", dicSacadas);
        }

        private void insertNewFunctionalities(List<String> add, int idRol)
        {
            int count = add.Count; 

            for (int index = 0; index < count; index++)
            {
                Dictionary<String, Object> dicAgregadas = new Dictionary<String, Object>();
                dicAgregadas.Add("@idrol", idRol);
                DataTable result = connector.select_query(this.getfunctionalityByDescQuery(add[index]));
                dicAgregadas.Add("@idfun", result.Rows[0]["Id"].ToString());
                connector.executeProcedureWithParameters("FSOCIETY.sp_insert_funcionalidad", dicAgregadas);
            }
        }

        private String getfunctionalityByDescQuery(string funcionalidad)
        {
            return "Select Id from FSOCIETY.Funcionalidades where Descripcion = '" + funcionalidad + "'";
        }

        public int getAnotherRolIdById(int idrol, String nombre)
        {
            String query = getAllRolQuery() + "where rol.Descripcion = '" + nombre + "' and rol.Id <> '" + idrol + "'";
            DataTable result = connector.select_query(query);
            
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return (Int32)row["Id"];
            }
            else return 0;           
        }
    }
}