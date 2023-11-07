using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Clases_personalizadas
{
    public class AnimalTratamiento
    {
        private string idTratamientoAnimal;
        private string causa;
        private DateTime fecha;
        private string comentario;
        private string tratamiento;

        private int idAnimal;
        private string nombre;
        private char sexo;
        private string edad;
        private string peso;
        private string esterilizado;

        public AnimalTratamiento()
        {
        }

        public AnimalTratamiento(string idTratamientoAnimal, string causa, DateTime fecha, string comentario, string tratamiento, int idAnimal,
            string nombre, char sexo, string edad,
            string peso, string esterilizado)
        {
            this.IdTratamientoAnimal = idTratamientoAnimal;
            this.Causa = causa;
            this.Fecha = fecha;
            this.Comentario = comentario;
            this.Tratamiento = tratamiento;
            this.IdAnimal = idAnimal;
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Edad = edad;
            this.Peso = peso;
            this.Esterilizado = esterilizado;
        }
        public string IdTratamientoAnimal { get => idTratamientoAnimal; set => idTratamientoAnimal = value; }
        public string Causa { get => causa; set => causa = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
        public int IdAnimal { get => idAnimal; set => idAnimal = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Esterilizado { get => esterilizado; set => esterilizado = value; }

        public static int EdadCalcu(DateTime fechaNacimiento)
        {
            string fechaActual = DateTime.Today.Year.ToString();
            int ed1 = fechaNacimiento.Year;
            int edad1 = DateTime.Today.Year;
            int ed = (edad1 - (ed1));

            return ed;
        }
    }
}
