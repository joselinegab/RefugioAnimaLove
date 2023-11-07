using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Refugio
{
    public class TratamientoAnimalCD
    {
        public static List<cp_BuscarTratamientoAnimalResult> Buscar(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarTratamientoAnimal(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de TratamientoAnimal", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarTratamientoAnimalResult> ListarTratamientoAnimal()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarTratamientoAnimal().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarTratamientoAnimal(TratamientoAnimal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarTratamientoAnimal(op.IdTratamientoAnimal, op.Causa, op.Fecha, op.Comentario, op.Tratamiento, op.IdAnimal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar TratamientoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarTratamientoAnimal(TratamientoAnimal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarTratamientoAnimal(op.IdTratamientoAnimal, op.Causa, op.Fecha, op.Comentario, op.Tratamiento, op.IdAnimal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar TratamientoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarTratamientoAnimal(TratamientoAnimal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarTratamientoAnimal(op.IdTratamientoAnimal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar TratamientoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarTratamientoAnimalXIdAnimal(int val)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarTratamientoAnimal(val.ToString());
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar TratamientoAnimal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarTratamientoAnimal_FiltroResult> ListarTratamientoAnimalFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarTratamientoAnimal_Filtro(val).ToList();
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
