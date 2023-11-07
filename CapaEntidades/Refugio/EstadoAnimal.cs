using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EstadoAnimal
    {
        private string estado;
        private string descripcion;

        public EstadoAnimal()
        {
        }

        public EstadoAnimal(string estado, string descripcion)
        {
            this.Estado = estado;
            this.Descripcion = descripcion;
        }

        public string Estado { get => estado; set => estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
