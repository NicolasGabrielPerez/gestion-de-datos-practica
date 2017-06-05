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

namespace UberFrba.Dao
{
    class DAOAutomovil
    {
        public DataTable getAllCars()
        {
            DataBaseConnector db = DataBaseConnector.getInstance();
            return db.select_query("SELECT AUTOS.Patente,MODELOS.Description,TURNOS.Descripcion,PERSONAS.Apellido,PERSONAS.Nombre FROM FSOCIETY.Autos AUTOS LEFT JOIN FSOCIETY.Modelos MODELOS ON AUTOS.IdModelo = MODELOS.Id LEFT JOIN FSOCIETY.Turnos TURNOS ON AUTOS.IdTurno = TURNOS.Id LEFT JOIN FSOCIETY.Personas PERSONAS ON AUTOS.IdChofer = PERSONAS.Id"); 
        }



    }
}
