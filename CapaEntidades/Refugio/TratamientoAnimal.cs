using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class TratamientoAnimal
    {
        private string idTratamientoAnimal;
        private string causa;
        private DateTime fecha;
        private string comentario;
        private string tratamiento;
        private int idAnimal;

        public TratamientoAnimal()
        {
        }

        public TratamientoAnimal(string idTratamientoAnimal, string causa, DateTime fecha, string comentario, string tratamiento, int idAnimal)
        {
            this.IdTratamientoAnimal = idTratamientoAnimal;
            this.Causa = causa;
            this.Fecha = fecha;
            this.Comentario = comentario;
            this.Tratamiento = tratamiento;
            this.IdAnimal = idAnimal;
        }

        public string IdTratamientoAnimal { get => idTratamientoAnimal; set => idTratamientoAnimal = value; }
        public string Causa { get => causa; set => causa = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
        public int IdAnimal { get => idAnimal; set => idAnimal = value; }
    }
}
