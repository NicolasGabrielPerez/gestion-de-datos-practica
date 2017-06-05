using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Mapping
{
    class Chofer
    {
        public Int32 id;
        public string telefono;
        public string email;
        public string habilitado { get; set; }

        public Chofer(Int32 ide, string telefo, string mail, string avtivo) {
            this.email = mail;
            this.telefono = telefo;
            this.habilitado = avtivo;
            this.id = ide;
        }


    }
}
