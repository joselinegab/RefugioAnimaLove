using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EstadoSolicitud
    {
        private string estadoSoli;
        private string descripcion;

        public EstadoSolicitud()
        {
        }

        public EstadoSolicitud(string estadoSoli, string descripcion)
        {
            this.EstadoSoli = estadoSoli;
            this.Descripcion = descripcion;
        }

        public string EstadoSoli { get => estadoSoli; set => estadoSoli = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
