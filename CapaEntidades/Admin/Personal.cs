using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Personal
    {
        private string idPersonal;
        private string identificacion;
        private string nombres;
        private string apellidos;
        private char sexo;
        private DateTime fechaNacimiento;
        private int edad;
        private string ciudad;
        private string direccion;
        private string celular;
        private string email;
        private string tipo;

        public Personal()
        {
        }

        public Personal(string idPersonal, string identificacion, string nombres, string apellidos, char sexo,
            DateTime fechaNacimiento, int edad, string ciudad, string direccion, string celular, string email, string tipo)
        {
            this.IdPersonal = idPersonal;
            this.Identificacion = identificacion;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.Celular = celular;
            this.Email = email;
            this.Tipo = tipo;
        }

        public string IdPersonal { get => idPersonal; set => idPersonal = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }
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
