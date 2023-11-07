using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.CD
{
    public class AdoptanteCD
    {
        public static List<cp_BuscarAdoptanteResult> BuscarIdAdoptante(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarAdoptante(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de Adoptante", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarAdoptanteResult> ListarAdoptante()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAdoptante().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarAdoptante(Adoptante op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarAdoptante(op.IdAdoptante, op.Identificacion, op.Nombres, op.Apellidos, op.Sexo, op.FechaNacimiento, op.Edad,op.Ciudad, op.Direccion, op.Celular, op.Email);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar Adoptante", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarAdoptante(Adoptante op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarAdoptante(op.IdAdoptante, op.Identificacion, op.Nombres, op.Apellidos, op.Sexo, op.FechaNacimiento, op.Edad,op.Ciudad, op.Direccion, op.Celular, op.Email);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar Adoptante", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarAdoptante(Adoptante op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarAdoptante(op.IdAdoptante);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Adoptante", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarAdoptante_FiltroResult> ListarAdoptanteFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAdoptante_Filtro(val).ToList();
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
