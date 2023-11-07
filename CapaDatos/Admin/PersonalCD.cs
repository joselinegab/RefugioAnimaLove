using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Admin
{
    public class PersonalCD
    {
        public static List<cp_BuscarPersonalResult> BuscarIdPersonal(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarPersonal(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de Personal", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarPersonalResult> ListarPersonal()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarPersonal().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarPersonal(Personal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarPersonal(op.IdPersonal, op.Identificacion, op.Nombres, op.Apellidos, (char)op.Sexo, op.FechaNacimiento.Date, (int)op.Edad,op.Ciudad, op.Direccion,
                        op.Celular, op.Email, op.Tipo);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar Personal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarPersonal(Personal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarPersonal(op.IdPersonal, op.Identificacion, op.Nombres, op.Apellidos, (char)op.Sexo, op.FechaNacimiento.Date, (int)op.Edad, op.Ciudad, op.Direccion,
                        op.Celular, op.Email, op.Tipo);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar Personal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarPersonal(Personal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarPersonal(op.IdPersonal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Personal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarPersonal_FiltroResult> ListarPersonalFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarPersonal_Filtro(val).ToList();
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
