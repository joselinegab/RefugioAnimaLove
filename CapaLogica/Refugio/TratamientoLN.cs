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
    public class TratamientoLN
    {
        public Tratamiento GetIdTratamiento(string val)
        {
            Tratamiento cl = null;
            try
            {
                List<cp_BuscarTratamientoResult> aux = TratamientoCD.Buscar(val);
                foreach (cp_BuscarTratamientoResult op in aux)
                {
                    cl = new Tratamiento(op.Tratamiento,op.Descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateTratamiento(Tratamiento op)
        {
            try
            {
                TratamientoCD.InsertarTratamiento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Tratamiento", ex);
            }
        }
        public bool UpdateTratamiento(Tratamiento op)
        {
            try
            {
                TratamientoCD.EditarTratamiento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Tratamiento", ex);
            }
        }
        public bool DeleteTratamiento(Tratamiento op)
        {
            try
            {
                TratamientoCD.EliminarTratamiento(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Tratamiento", ex);
            }
        }
        public List<Tratamiento> ViewTratamiento()
        {
            Tratamiento cl;
            List<Tratamiento> Lista = new List<Tratamiento>();
            try
            {
                List<cp_ListarTratamientoResult> aux = TratamientoCD.ListarTratamiento();
                foreach (cp_ListarTratamientoResult op in aux)
                {
                    cl = new Tratamiento(op.Tratamiento, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Tratamiento", ex);
            }
            return Lista;

        }
        public List<Tratamiento> ViewTratamientoFiltro(string val)
        {
            Tratamiento cl;
            List<Tratamiento> Lista = new List<Tratamiento>();
            try
            {
                List<cp_ListarTratamiento_FiltroResult> aux = TratamientoCD.ListarTratamientoFiltro(val);
                foreach (cp_ListarTratamiento_FiltroResult op in aux)
                {
                    cl = new Tratamiento(op.Tratamiento, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Tratamiento", ex);
            }
            return Lista;

        }
    }
}

