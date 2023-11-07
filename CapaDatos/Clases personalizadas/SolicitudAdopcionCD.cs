using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDatos.Clases_personalizadas
{
    public class SolicitudAdopcionCD
    {
        public static List<cp_ListarSolicitudAdopcion_FiltroResult> ListarSolicitudAdop_Filtro(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarSolicitudAdopcion_Filtro(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos en Solicitud Adopcion", ex);
            }
            finally { DB = null; }
        }

        public static List<cp_ListarSolicitudAdopcionResult> ListarSolicitudAdop()
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarSolicitudAdopcion().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos en Solicitud Adopcion", ex);
            }
            finally { DB = null; }
        }
        public static List<cp_ListarSolicitudAdopcion_FiltroXIdAdoptanteResult> ListarSolicitudAdopXIdAdop(string val)
        {
            BDAnimaloveDataContext DB = null;
            try
            {
                using (DB = new BDAnimaloveDataContext())
                {
                    return DB.cp_ListarSolicitudAdopcion_FiltroXIdAdoptante(val).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Problemas al filtrar datos en Solicitud Adopcion", ex);
            }
            finally { DB = null; }
        }
    }
}
