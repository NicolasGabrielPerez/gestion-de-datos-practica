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
using System;
using System.Collections.Generic;

namespace UberFrba.Dao
{
    class DAOChofer
    {
        private DataBaseConnector connector;

        public DAOChofer()
        {
            this.connector = DataBaseConnector.getInstance();
        }

        private String getAllChoferQuery()
        {
            return "select per.Nombre, per.Apellido, per.DNI, ch.Telefono, ch.Email, per.[Fecha de Nacimiento], per.Direccion, ch.Habilitado from FSOCIETY.Personas per, FSOCIETY.Chofer ch, FSOCIETY.Usuarios us where per.Id = us.IdPersona and us.Id = ch.Id";
        }

        private String getSelectClientQuery(String filtro  , String dato)
        {
            return getAllChoferQuery() + " and " + filtro +
                                       " like '%" + dato + "%'";
        }

        internal DataTable getChoferById(int id)
        {
            String query = getAllChoferQuery() + "and ch.Id = '" + id + "'";
            return connector.select_query(query);
        }


        public int modificarChofer(Chofer chofer)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@telefono", chofer.telefono);
            dic.Add("@mail", chofer.email);
            dic.Add("@idChofer", chofer.id);
            dic.Add("@habilitado", chofer.habilitado);

            connector.executeProcedureWithParameters("FSOCIETY.sp_modificar_chofer", dic);//todo sp

            return 0;
        }

        public int crearChofer(Chofer chofer)
        {
            Dictionary<String, Object> dic = new Dictionary<String, Object>();
            dic.Add("@telefono", chofer.telefono);
            dic.Add("@mail", chofer.email);
            dic.Add("@idChofer", chofer.id);
            dic.Add("@habilitado", chofer.habilitado);

            connector.executeProcedureWithParameters("FSOCIETY.sp_crear_chofer", dic);
            //todod sp
            return 0;
        }


        public DataTable buscarChofer(string filtro, string dato)
        {
            if (dato != "" || filtro != "")
            {
                return connector.select_query(getSelectClientQuery(filtro, dato));
            }
            else
            {
                return buscarTodosLosChoferes();
            }}

                public DataTable buscarTodosLosChoferes() {
            return connector.select_query(getAllChoferQuery());
        }



                internal int getMailById(Chofer chofer)
                {
                    DataBaseConnector db;
                    db = DataBaseConnector.getInstance();
                    DataTable dt = db.select_query("Select TOP 1 Email from FSOCIETY.Chofer where Email= '"
                                                     + chofer.email + "and Id <> " + chofer.id + "'");
                    
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0].Field<int>(1);
                    else return 0;
                }

                public int valorverdad { get; set; }
    }
    }

