using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Refugio
{
    public class EspecieCD
    {
        public static List<cp_BuscarEspecieResult> Buscar(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarEspecie(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de Especie", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarEspecieResult> ListarEspecie()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarEspecie().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarEspecie(Especie op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarEspecie(op.Nombre, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar Especie", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarEspecie(Especie op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarEspecie(op.Nombre, op.Descripcion);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar Especie", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarEspecie(Especie op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarEspecie(op.Nombre);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Especie", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarEspecie_FiltroResult> ListarEspecieFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarEspecie_Filtro(val).ToList();
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
