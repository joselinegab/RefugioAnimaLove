using System;
using System.Drawing;
using System.Data;
using System.Linq;

namespace CapaEntidades
{
    public class Animal
    {
        private int idAnimal;
        private string nombre;
        private char sexo;
        private DateTime fechaNacimiento;
        private string edad;
        private string tamanio;
        private string peso;
        private string enfermo;
        private string esterilizado;
        private string enfermedad;
        private string vacunas;
        private DateTime fechaLlegada;
        private byte[] foto;
        private string especie;
        private string estadoAnimal;

        public Animal()
        {
        }

        public Animal(int idAnimal, string nombre, char sexo, DateTime fechaNacimiento, string edad, string tamanio, string peso, string enfermo,
            string esterilizado, string enfermedad, string vacunas, DateTime fechaLlegada, byte[] foto, string especie, string estadoAnimal)
        {
            this.IdAnimal = idAnimal;
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
            this.Tamanio = tamanio;
            this.Peso = peso;
            this.Enfermo = enfermo;
            this.Esterilizado = esterilizado;
            this.Enfermedad = enfermedad;
            this.Vacunas = vacunas;
            this.FechaLlegada = fechaLlegada;
            this.Foto = foto;
            this.Especie = especie;
            this.EstadoAnimal = estadoAnimal;
        }

        public int IdAnimal { get => idAnimal; set => idAnimal = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Tamanio { get => tamanio; set => tamanio = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Enfermo { get => enfermo; set => enfermo = value; }
        public string Esterilizado { get => esterilizado; set => esterilizado = value; }
        public string Enfermedad { get => enfermedad; set => enfermedad = value; }
        public string Vacunas { get => vacunas; set => vacunas = value; }
        public DateTime FechaLlegada { get => fechaLlegada; set => fechaLlegada = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public string Especie { get => especie; set => especie = value; }
        public string EstadoAnimal { get => estadoAnimal; set => estadoAnimal = value; }

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
