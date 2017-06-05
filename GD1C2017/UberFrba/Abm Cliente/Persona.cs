
using System;
namespace UberFrba.Abm_Cliente
{
    class Persona
    {
        public string nombre;
        public string apellido;
        public int dni;
        public string direccion;
        public int idPerson;
        public System.DateTime nacimiento { get; set; }
        
        public Persona(string p1, string p2, string p3, string direccion, System.DateTime dateTime, int idPersona)
        {
            // TODO: Complete member initialization
            this.nombre = p1;
            this.apellido = p2;
            this.dni = Convert.ToInt32(p3);
            this.direccion = direccion;
            this.nacimiento = dateTime;
            this.idPerson = idPersona;
        }
       
        public void setIdPersona(int id) 
        {
            this.idPerson = id;
        }
    }
}
