using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Admin
{
    public class UsuarioCD
    {
        public static List<cp_BuscarUsuarioResult> BuscarIdUsuario(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarUsuario(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de Usuario", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarUsuarioResult> ListarUsuario()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarUsuario().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarUsuario(Usuario op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarUsuario(op.IdUsuario, op.User, op.Pass);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar Usuario", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarUsuario(Usuario op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarUsuario(op.IdUsuario, op.User, op.Pass);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar Usuario", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarUsuario(Usuario op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarUsuario(op.IdUsuario);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Usuario", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarUsuario_FiltroResult> ListarUsuarioFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarUsuario_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        //public static void VerificarLogin(UsuarioLogin op)
        //{
        //    BDAnimaloveDataContext DB = null;
        //    try
        //    {
        //        using (DB = new BDAnimaloveDataContext())
        //        {
        //            DB.cp_VerificarLogin(op.User, op.Pass);
        //            DB.SubmitChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DatosExcepciones("Problemas al Listar", ex);
        //    }
        //    finally { DB = null; }
        //}
    }
}
