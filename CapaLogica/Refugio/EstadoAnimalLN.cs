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
    public class EstadoAnimalLN
    {
        public EstadoAnimal GetIdEstadoAnimal(string val)
        {
            EstadoAnimal cl = null;
            try
            {
                List<cp_BuscarEstadoAnimalResult> aux = EstadoAnimalCD.Buscar(val);
                foreach (cp_BuscarEstadoAnimalResult op in aux)
                {
                    cl = new EstadoAnimal(op.EstadoAnimal, op.Descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateEstadoAnimal(EstadoAnimal op)
        {
            try
            {
                EstadoAnimalCD.InsertarEstadoAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar EstadoAnimal", ex);
            }
        }
        public bool UpdateEstadoAnimal(EstadoAnimal op)
        {
            try
            {
                EstadoAnimalCD.EditarEstadoAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar EstadoAnimal", ex);
            }
        }
        public bool DeleteEstadoAnimal(EstadoAnimal op)
        {
            try
            {
                EstadoAnimalCD.EliminarEstadoAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar EstadoAnimal", ex);
            }
        }
        public List<EstadoAnimal> ViewEstadoAnimal()
        {
            EstadoAnimal cl;
            List<EstadoAnimal> Lista = new List<EstadoAnimal>();
            try
            {
                List<cp_ListarEstadoAnimalResult> aux = EstadoAnimalCD.ListarEstadoAnimal();
                foreach (cp_ListarEstadoAnimalResult op in aux)
                {
                    cl = new EstadoAnimal(op.EstadoAnimal, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de EstadoAnimal", ex);
            }
            return Lista;

        }
        public List<EstadoAnimal> ViewEstadoAnimalFiltro(string val)
        {
            EstadoAnimal cl;
            List<EstadoAnimal> Lista = new List<EstadoAnimal>();
            try
            {
                List<cp_ListarEstadoAnimal_FiltroResult> aux = EstadoAnimalCD.ListarEstadoAnimalFiltro(val);
                foreach (cp_ListarEstadoAnimal_FiltroResult op in aux)
                {
                    cl = new EstadoAnimal(op.EstadoAnimal, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de EstadoAnimal", ex);
            }
            return Lista;

        }
    }
}
