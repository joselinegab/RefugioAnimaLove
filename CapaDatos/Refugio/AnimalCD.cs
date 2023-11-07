using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Refugio
{
    public class AnimalCD
    {
        public static List<cp_BuscarAnimalResult> Buscar(int val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_BuscarAnimal(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos de Animal", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<cp_ListarAnimalResult> ListarAnimal()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAnimal().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }
        public static List<cp_ListarAnimalesXEstadoResult> ListarAnimalXEstado(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAnimalesXEstado(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al Listar", ex);
            }
            finally { DB = null; }
        }

        public static void InsertarAnimal(Animal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_InsertarAnimal(op.IdAnimal, op.Nombre, op.Sexo, op.FechaNacimiento, op.Edad, op.Tamanio, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.FechaLlegada,
                        op.Foto, op.Especie, op.EstadoAnimal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al insertar Animal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EditarAnimal(Animal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_ActualizarAnimal(op.IdAnimal, op.Nombre, op.Sexo, op.FechaNacimiento, op.Edad, op.Tamanio, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.FechaLlegada,
                        op.Foto, op.Especie, op.EstadoAnimal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Actualizar Animal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static void EliminarAnimal(Animal op)
        {
            BDAnimaloveDataContext BD = null;
            try
            {
                using (BD = new BDAnimaloveDataContext())
                {
                    BD.cp_EliminarAnimal(op.IdAnimal);
                    BD.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas Al Eliminar Animal", ex);
            }
            finally
            {
                BD = null;
            }
        }
        public static List<cp_ListarAnimal_FiltroResult> ListarAnimalFiltro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAnimal_Filtro(val).ToList();
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
