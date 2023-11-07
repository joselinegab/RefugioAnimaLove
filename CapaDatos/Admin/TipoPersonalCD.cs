using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Admin
{
    public class TipoPersonalCD
    {
        public static List<cp_BuscarTipoPersonalResult> BuscarIdTipoPersonal(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarTipoPersonal(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de TipoPersonal", ex);
            }
            finally
            {
                DB = null;
            }
        }

      
        public static void InsertarTipoPersonal(TipoPersonal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarTipoPersonal(op.Tipo, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar TipoPersonal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void ModificarTipoPersonal(TipoPersonal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarTipoPersonal(op.Tipo, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar TipoPersonal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarTipoPersonal(TipoPersonal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarTipoPersonal(op.Tipo);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar TipoPersonal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarTipoPersonal_FiltroResult> ListarTipoPersonalFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarTipoPersonal_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }
        public static List<cp_ListarTipoPersonalResult> ListarTipoPersonal()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarTipoPersonal().ToList();
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
