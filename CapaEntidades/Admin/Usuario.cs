using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Usuario
    {
        private string idUsuario;
        private string user;
        private string pass;

        public Usuario()
        {
        }

        public Usuario(string idUsuario, string user, string pass)
        {
            this.IdUsuario = idUsuario;
            this.User = user;
            this.Pass = pass;
        }

        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
