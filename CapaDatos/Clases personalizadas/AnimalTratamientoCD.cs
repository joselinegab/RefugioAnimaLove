using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Clases_personalizadas
{
    public class AnimalTratamientoCD
    {
        public static List<cp_ListarAnimalTratamiento_FiltroResult> ListarAnimalTratamiento_Filtro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAnimalTratamiento_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos en AnimalTratamiento", ex);
            }
            finally { DB = null; }
        }
        public static List<cp_ListarAnimalTratamiento_FiltroXIdAnimalResult> ListarAnimalTratamiento_FiltroXIdAnimal(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAnimalTratamiento_FiltroXIdAnimal(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos en AnimalTratamiento", ex);
            }
            finally { DB = null; }
        }
        public static List<cp_ListarAnimalTratamientoResult> ListarAnimalTratamiento()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarAnimalTratamiento().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos en AnimalTratamiento", ex);
            }
            finally { DB = null; }
        }
    }
}
