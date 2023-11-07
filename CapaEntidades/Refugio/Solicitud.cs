using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Solicitud
    {
        private string idSolicitud;
        private DateTime fecha;
        private string estado;
        private int idAnimal;
        private string idAdoptante;

        public Solicitud()
        {
        }

        public Solicitud(string idSolicitud, DateTime fecha, string estado, int idAnimal, string idAdoptante)
        {
            this.IdSolicitud = idSolicitud;
            this.Fecha = fecha;
            this.Estado = estado;
            this.IdAnimal = idAnimal;
            this.IdAdoptante = idAdoptante;
        }

        public string IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdAnimal { get => idAnimal; set => idAnimal = value; }
        public string IdAdoptante { get => idAdoptante; set => idAdoptante = value; }
    }
}
