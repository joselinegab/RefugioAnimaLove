using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Refugio
{
    public class SolicitudCD
    {
        public static List<cp_BuscarSolicitudResult> Buscar(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarSolicitud(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de Solicitud", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarSolicitudResult> ListarSolicitud()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarSolicitud().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarSolicitud(Solicitud op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarSolicitud(op.IdSolicitud, op.Fecha, op.Estado, op.IdAnimal, op.IdAdoptante);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar Solicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarSolicitud(Solicitud op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarSolicitud(op.IdSolicitud, op.Fecha, op.Estado, op.IdAnimal, op.IdAdoptante);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar Solicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        //public static void EditarSolicitudXId(string val)
        //{
        //    BDAnimaloveDataContext BD = null;
        //    try
        //    {
        //        using (BD = new BDAnimaloveDataContext())
        //        {
        //            BD.cp_EliminarSolicitud(val);
        //            BD.SubmitChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DatosExcepciones("Problemas Al Eliminar Solicitud", ex);
        //    }
        //    finally
        //    {
        //        BD = null;
        //    }
        //}
        public static void EliminarSolicitud(Solicitud op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarSolicitud(op.IdSolicitud);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Solicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarSolicitudXId(string val)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarSolicitud(val);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Solicitud", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarSolicitud_FiltroResult> ListarSolicitudFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarSolicitud_Filtro(val).ToList();
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
