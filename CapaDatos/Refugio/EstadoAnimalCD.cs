using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Refugio
{
    public class EstadoAnimalCD
    {
        public static List<cp_BuscarEstadoAnimalResult> Buscar(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarEstadoAnimal(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de EstadoAnimal", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarEstadoAnimalResult> ListarEstadoAnimal()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarEstadoAnimal().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarEstadoAnimal(EstadoAnimal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarEstadoAnimal(op.Estado, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar EstadoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarEstadoAnimal(EstadoAnimal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarEstadoAnimal(op.Estado, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar EstadoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarEstadoAnimal(EstadoAnimal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarEstadoAnimal(op.Estado);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar EstadoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarEstadoAnimal_FiltroResult> ListarEstadoAnimalFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarEstadoAnimal_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }
    }
}
