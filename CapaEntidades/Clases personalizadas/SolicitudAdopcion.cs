using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Clases_personalizadas
{
    public class SolicitudAdopcion
    {
        private string idSolicitud;
        private DateTime fecha;

        private string idAdoptante;
        private string identificacion;
        private string nombres;
        private string apellidos;
        private int edadAdop;
        private string ciudad;
        private string direccion;
        private string celular;
        private string email;

        private int idAnimal;
        private string nombre;
        private byte[] foto;
        private string edad;
        private char sexo;
        private string peso;
        private string enfermo;
        private string esterilizado;
        private string enfermedad;
        private string vacunas;

        private string estado;

        public SolicitudAdopcion()
        {
        }

        public SolicitudAdopcion(string idSolicitud, DateTime fecha, string identificacion, string nombres, string apellidos,
             int edadAdop, string ciudad, string direccion, string celular, string email, string nombre, byte[] foto, string edad,
            char sexo, string peso, string enfermo, string esterilizado, string enfermedad, string vacunas, string estado, string idAdoptante, int idAnimal)
        {
            this.IdSolicitud = idSolicitud;
            this.Fecha = fecha;
            this.Identificacion = identificacion;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.EdadAdop = edadAdop;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.Celular = celular;
            this.Email = email;
            this.Nombre = nombre;
            this.Foto = foto;
            this.Edad = edad;
            this.Sexo = sexo;
            this.Peso = peso;
            this.Enfermo = enfermo;
            this.Esterilizado = esterilizado;
            this.Enfermedad = enfermedad;
            this.Vacunas = vacunas;
            this.Estado = estado;
            this.IdAdoptante = idAdoptante;
            this.IdAnimal = idAnimal;


        }

        public string IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string IdAdoptante { get => idAdoptante; set => idAdoptante = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int EdadAdop { get => edadAdop; set => edadAdop = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
        public int IdAnimal { get => idAnimal; set => idAnimal = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public string Edad { get => edad; set => edad = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Enfermo { get => enfermo; set => enfermo = value; }
        public string Esterilizado { get => esterilizado; set => esterilizado = value; }
        public string Enfermedad { get => enfermedad; set => enfermedad = value; }
        public string Vacunas { get => vacunas; set => vacunas = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
