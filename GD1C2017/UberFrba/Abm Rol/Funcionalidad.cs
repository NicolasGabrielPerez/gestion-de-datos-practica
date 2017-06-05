using System;

namespace WindowsFormsApplication1.ABM_Rol
{
    class Funcionalidad : IEquatable<Funcionalidad>
    {
        public int codigo { get; private set; }
        public string descripcion { get; private set; }

        public Funcionalidad(int code, string description)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public bool Equals(Funcionalidad other)
        {
            return this.codigo == other.codigo;
        }

        public override string ToString()
        {
            return this.descripcion;
        }
    }
}