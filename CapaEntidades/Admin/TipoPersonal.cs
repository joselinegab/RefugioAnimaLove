using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class TipoPersonal
    {
        private string tipo;
        private string descripcion;

        public TipoPersonal()
        {
        }

        public TipoPersonal(string tipo, string descripcion)
        {
            this.Tipo = tipo;
            this.Descripcion = descripcion;
        }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
