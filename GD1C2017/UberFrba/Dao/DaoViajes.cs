using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Utils;
using System.Data;
using UberFrba.Mapping;

namespace UberFrba.Dao
{
    class DaoViajes
    {
        private DataBaseConnector db;


        public DaoViajes() {

            this.db = DataBaseConnector.getInstance();
            
        }

        public List<ViajeChofer> getAllDrivers()
        {
            DataTable dt = db.select_query("select distinct a.Patente, ma.Description as Marca, m.Description as Modelo, c.Id,p.Nombre,p.Apellido,p.DNI,c.Telefono, c.Email,p.[Fecha de Nacimiento] as Fecha from FSOCIETY.Chofer as c join FSOCIETY.Usuarios as u on c.Id = u.Id join FSOCIETY.Personas as p on p.Id = u.IdPersona join FSOCIETY.Autos a on a.IdChofer = c.Id join FSOCIETY.Modelos m on m.Id = a.IdModelo join FSOCIETY.Marcas ma on ma.Id = m.IdMarca where c.Habilitado = 1");
            List<ViajeChofer> list = new List<ViajeChofer>();
            foreach(DataRow r in dt.Rows ){
                list.Add(new ViajeChofer(r));
            }
            return list;
        }

        public List<ViajePersona> getAllClients() {
            DataTable dt = db.select_query("select c.Id,p.Nombre,p.Apellido,p.DNI,c.Telefono, c.Email,p.[Fecha de Nacimiento] as Fecha from FSOCIETY.Cliente as c join FSOCIETY.Usuarios as u on c.Id = u.Id join FSOCIETY.Personas as p on p.Id = u.IdPersona where c.Habilitado = 1");
            List<ViajePersona> list = new List<ViajePersona>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ViajePersona(r));
            }
            return list;
        }

        public void insertTravel(Viajes viaje) {

            Dictionary<String, Object> dic = new Dictionary<string, object>();
            dic.Add("@idchofer",viaje.Chofer.getId());
            dic.Add("@idcliente", viaje.Cliente.getId());
            dic.Add("@CantKm",viaje.KM);
            dic.Add("@inicio",  DateUtils.stringFromDate(viaje.Inicio));
            dic.Add("@fin",  DateUtils.stringFromDate(viaje.Fin));

            db.executeQueryWithParameters("insert into FSOCIETY.Viaje(IdChofer,IdCliente,CantKm,FechaHoraInicio,FechaHoraFin) values(@idchofer,@idcliente,@cantkm,CONVERT(datetime,@inicio,120),CONVERT(datetime,@fin,120))", dic);

        }

        public void verifyTravelExisted(Viajes viaje) {
            String date = DateUtils.stringFromDate(viaje.Inicio);
            DataTable dt = db.select_query("select Id from FSOCIETY.Viaje where IdCliente = " + viaje.Cliente.getId() + " and FechaHoraInicio <= CONVERT(datetime,'"+date+"',120) and FechaHoraFin >= CONVERT(datetime,'"+date+"',120)");
            if (dt.Rows.Count > 0) {
                throw new Exception("Viaje duplicado");
            }
        }

        public void InsertTravelIfNotExited(Viajes viaje) {
            verifyTravelExisted(viaje);
            insertTravel(viaje);
        }

    }
}
