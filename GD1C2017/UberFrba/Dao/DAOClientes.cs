using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Mapping;
using System.Data;
using UberFrba.Utils;
using System.Data.SqlClient;
using WindowsFormsApplication1;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UberFrba.Dao;
using UberFrba.Abm_Cliente;


namespace UberFrba.Dao
{
    class DAOClientes
    {
        private DataBaseConnector connector;


        public DAOClientes() {
            this.connector = DataBaseConnector.getInstance();
        }
       

        public DataTable buscarCliente(String nombre, String apellido, String dni) {
            if (nombre != "" || apellido != "" || dni != "")
            {
                return connector.select_query(getSelectClientQuery(nombre,apellido,dni));
            }
            else {
                return buscarTodosLosClientes();
            }
                        
        }

        public DataTable buscarTodosLosClientes() {
            return connector.select_query(getAllClientQuery());
        }

        public int crearPersona(Persona persona) 
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@nombre",persona.nombre);
            dic.Add("@apellido", persona.apellido);
            dic.Add("@dni", persona.dni);
            dic.Add("@direccion", persona.direccion);
            dic.Add("@fecha_nacimiento", persona.nacimiento);
            dic.Add("@id", persona.idPerson);

            connector.executeProcedureWithParameters("FSOCIETY.sp_crear_persona", dic);
            
            return this.getIdPersona(persona);
        }

        public int getIdPersona(Persona persona)
        {
            DataBaseConnector db;
            db = DataBaseConnector.getInstance();
            DataTable dt = db.select_query("Select Id from FSOCIETY.Personas where Nombre = '" + persona.nombre + "' and Apellido = '" + persona.apellido + "' and DNI = '" + persona.dni + "' and Direccion = '" + persona.direccion + "'");

            int idpersona = (int)dt.Rows[0][0];
            return idpersona;
        }

        public int crearUsuario(int idPersona)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@id", idPersona);
            connector.executeProcedureWithParameters("FSOCIETY.sp_create_user", dic);

            return 0;
        }

        public int crearCliente(Cliente cliente)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@telefono", cliente.telefono);
            dic.Add("@mail", cliente.mail);
            dic.Add("@codigoPostal", cliente.zipcode);
            dic.Add("@idCliente", cliente.idCliente);
            dic.Add("@habilitado", cliente.habilitado);

            connector.executeProcedureWithParameters("FSOCIETY.sp_crear_cliente", dic);
            
            return 0;
        }

       public int getIdcliente(Cliente cliente)
        {
            DataBaseConnector db;
            db = DataBaseConnector.getInstance();
            DataTable dt = db.select_query("Select Id from FSOCIETY.Cliente where Telefono = '" + cliente.telefono
                                            + "' and Email = '" + cliente.mail + "' and Codigo_Postal = '" + cliente.zipcode + "'");
            
            return dt.Rows[1].Field<int>(1);
        }

       public int modificarPersona(Persona persona)
       {
           Dictionary<String, Object> dic = new Dictionary<String, Object>();
           dic.Add("@nombre", persona.nombre);
           dic.Add("@apellido", persona.apellido);
           dic.Add("@dni", persona.dni);
           dic.Add("@direccion", persona.direccion);
           dic.Add("@fecha_nacimiento", persona.nacimiento);
           dic.Add("@id", persona.idPerson);

           connector.executeProcedureWithParameters("FSOCIETY.sp_modificar_persona", dic);
                      
           return 0;
       }

       public int modificarCliente(Cliente cliente)
       { 
           Dictionary<String, Object> dic = new Dictionary<String, Object>();
           dic.Add("@telefono", cliente.telefono);
           dic.Add("@mail", cliente.mail);
           dic.Add("@codigoPostal", cliente.zipcode);
           dic.Add("@idCliente", cliente.idCliente);
           dic.Add("@habilitado", cliente.habilitado);

           connector.executeProcedureWithParameters("FSOCIETY.sp_modificar_cliente", dic);
    
           return 0;
       }

       public int getDNIById(Persona persona)
       {
           DataBaseConnector db;
           db = DataBaseConnector.getInstance();
           DataTable dt = db.select_query("Select DNI from FSOCIETY.Personas where DNI = '" 
                                            + persona.dni + "and Id <> " + persona.idPerson + "'");

           if (dt.Rows.Count > 0)
               return dt.Rows[0].Field<int>(1);
           else return 0;
       }

       public int getMailById(Cliente cliente)
       {
           DataBaseConnector db;
           db = DataBaseConnector.getInstance();
           DataTable dt = db.select_query("Select TOP 1 Email from FSOCIETY.Cliente where Email= '"
                                            + cliente.mail + "and Id <> " + cliente.idCliente + "'");

           if (dt.Rows.Count > 0)
               return dt.Rows[0].Field<int>(1);
           else return 0;
       }

       private String getAllClientQuery() {
           return "select per.Nombre, per.Apellido, per.DNI, cli.Telefono, cli.Email, per.[Fecha de Nacimiento], per.Direccion, cli.Codigo_Postal, cli.Habilitado from FSOCIETY.Personas per, FSOCIETY.Cliente cli, FSOCIETY.Usuarios us where per.Id = us.IdPersona and us.Id = cli.Id";
       }

       private String getSelectClientQuery(String nombre, String apellido, String dni) {
           return getAllClientQuery() + " and Nombre like '%" + nombre + 
                                      "%' and Apellido like '%" + apellido + 
                                      "%' and DNI like '%" + dni + "%'";
       }

       internal DataTable getClientById(int id)
       {
          String query = getAllClientQuery() + "and cli.Id = '" + id + "'";
          return connector.select_query(query);
       }
    }
}