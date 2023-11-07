using CapaDatos;
using CapaDatos.Clases_personalizadas;
using CapaEntidades.Clases_personalizadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Clases_personalizadas
{
    public class AnimalTratamientoLN
    {
        public List<AnimalTratamiento> ViewAnimalTratamiento()
        {
            AnimalTratamiento cl;
            List<AnimalTratamiento> Lista = new List<AnimalTratamiento>();
            try
            {
                List<cp_ListarAnimalTratamientoResult> aux = AnimalTratamientoCD.ListarAnimalTratamiento();
                foreach (cp_ListarAnimalTratamientoResult op in aux)
                {
                    cl = new AnimalTratamiento(op.IdTratamientoAnimal, op.Causa, op.Fecha.Value, op.Comentario, op.Tratamiento, op.IdAnimal, op.Nombre, (char)op.Sexo, op.Edad,
                        op.Peso, op.Esterilizado);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de AnimalTratamiento", ex);
            }
            return Lista;

        }
        public List<AnimalTratamiento> ViewAnimalTratamientoFiltro(string val)
        {
            AnimalTratamiento cl;
            List<AnimalTratamiento> Lista = new List<AnimalTratamiento>();
            try
            {
                List<cp_ListarAnimalTratamiento_FiltroResult> aux = AnimalTratamientoCD.ListarAnimalTratamiento_Filtro(val);
                foreach (cp_ListarAnimalTratamiento_FiltroResult op in aux)
                {
                    cl = new AnimalTratamiento(op.IdTratamientoAnimal, op.Causa, op.Fecha.Value, op.Comentario, op.Tratamiento, op.IdAnimal, op.Nombre, (char)op.Sexo, op.Edad,
                        op.Peso, op.Esterilizado);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de AnimalTratamiento", ex);
            }
            return Lista;

        }
        public List<AnimalTratamiento> ViewAT_FiltroXIdAnimal(string val)
        {
            AnimalTratamiento cl;
            List<AnimalTratamiento> Lista = new List<AnimalTratamiento>();
            try
            {
                List<cp_ListarAnimalTratamiento_FiltroXIdAnimalResult> aux = AnimalTratamientoCD.ListarAnimalTratamiento_FiltroXIdAnimal(val);
                foreach (cp_ListarAnimalTratamiento_FiltroXIdAnimalResult op in aux)
                {
                    cl = new AnimalTratamiento(op.IdTratamientoAnimal, op.Causa, op.Fecha.Value, op.Comentario, op.Tratamiento, op.IdAnimal, op.Nombre, (char)op.Sexo, op.Edad,
                        op.Peso,op.Esterilizado);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de AnimalTratamiento", ex);
            }
            return Lista;

        }
    }
}
