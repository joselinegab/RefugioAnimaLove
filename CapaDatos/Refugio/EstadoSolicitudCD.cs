using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Refugio
{
    public class EstadoSolicitudCD
    {
        public static List<cp_BuscarEstadoSolicitudResult> Buscar(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarEstadoSolicitud(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de EstadoSolicitud", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarEstadoSolicitudResult> ListarEstadoSolicitud()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarEstadoSolicitud().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarEstadoSolicitud(EstadoSolicitud op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarEstadoSolicitud(op.EstadoSoli, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar EstadoSolicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarEstadoSolicitud(EstadoSolicitud op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarEstadoSolicitud(op.EstadoSoli, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar EstadoSolicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarEstadoSolicitud(EstadoSolicitud op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarEstadoSolicitud(op.EstadoSoli);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar EstadoSolicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarEstadoSolicitud_FiltroResult> ListarEstadoSolicitudFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarEstadoSolicitud_Filtro(val).ToList();
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
