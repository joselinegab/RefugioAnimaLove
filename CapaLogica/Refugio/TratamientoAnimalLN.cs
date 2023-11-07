using CapaDatos;
using CapaDatos.Refugio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Refugio
{
    public class TratamientoAnimalLN
    {
        public TratamientoAnimal GetIdTratamientoAnimal(string val)
        {
            TratamientoAnimal cl = null;
            try
            {
                List<cp_BuscarTratamientoAnimalResult> aux = TratamientoAnimalCD.Buscar(val);
                foreach (cp_BuscarTratamientoAnimalResult op in aux)
                {
                    cl = new TratamientoAnimal(op.IdTratamientoAnimal,op.Causa,op.Fecha.Value,op.Comentario,op.Tratamiento,op.IdAnimal);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateTratamientoAnimal(TratamientoAnimal op)
        {
            try
            {
                TratamientoAnimalCD.InsertarTratamientoAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar TratamientoAnimal", ex);
            }
        }
        public bool UpdateTratamientoAnimal(TratamientoAnimal op)
        {
            try
            {
                TratamientoAnimalCD.EditarTratamientoAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar TratamientoAnimal", ex);
            }
        }
        public bool DeleteTratamientoAnimal(TratamientoAnimal op)
        {
            try
            {
                TratamientoAnimalCD.EliminarTratamientoAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar TratamientoAnimal", ex);
            }
        }
        public bool DeleteTratamientoAnimalXIdAnimal(int val)
        {
            try
            {
                TratamientoAnimalCD.EliminarTratamientoAnimalXIdAnimal(val);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar TratamientoAnimal", ex);
            }
        }
        public List<TratamientoAnimal> ViewTratamientoAnimal()
        {
            TratamientoAnimal cl;
            List<TratamientoAnimal> Lista = new List<TratamientoAnimal>();
            try
            {
                List<cp_ListarTratamientoAnimalResult> aux = TratamientoAnimalCD.ListarTratamientoAnimal();
                foreach (cp_ListarTratamientoAnimalResult op in aux)
                {
                    cl = new TratamientoAnimal(op.IdTratamientoAnimal, op.Causa, op.Fecha.Value, op.Comentario, op.Tratamiento, op.IdAnimal);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de TratamientoAnimal", ex);
            }
            return Lista;

        }
        public List<TratamientoAnimal> ViewTratamientoAnimalFiltro(string val)
        {
            TratamientoAnimal cl;
            List<TratamientoAnimal> Lista = new List<TratamientoAnimal>();
            try
            {
                List<cp_ListarTratamientoAnimal_FiltroResult> aux = TratamientoAnimalCD.ListarTratamientoAnimalFiltro(val);
                foreach (cp_ListarTratamientoAnimal_FiltroResult op in aux)
                {
                    cl = new TratamientoAnimal(op.IdTratamientoAnimal, op.Causa, op.Fecha.Value, op.Comentario, op.Tratamiento, op.IdAnimal);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de TratamientoAnimal", ex);
            }
            return Lista;

        }
    }
}
