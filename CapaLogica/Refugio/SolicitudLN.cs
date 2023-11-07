using CapaDatos;
using CapaDatos.Refugio;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Refugio
{
    public class SolicitudLN
    {
        public Solicitud GetIdSolicitud(string val)
        {
            Solicitud cl = null;
            try
            {
                List<cp_BuscarSolicitudResult> aux = SolicitudCD.Buscar(val);
                foreach (cp_BuscarSolicitudResult op in aux)
                {
                    cl = new Solicitud(op.IdSolicitud,op.Fecha.Value,op.Estado,(int)op.IdAnimal,op.IdAdoptante);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateSolicitud(Solicitud op)
        {
            try
            {
                SolicitudCD.InsertarSolicitud(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Solicitud", ex);
            }
        }
        public bool UpdateSolicitud(Solicitud op)
        {
            try
            {
                SolicitudCD.EditarSolicitud(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Solicitud", ex);
            }
        }
        public bool DeleteSolicitudXId(string val)
        {
            try
            {
                SolicitudCD.EliminarSolicitudXId(val);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Solicitud", ex);
            }
        }
        public bool DeleteSolicitud(Solicitud op)
        {
            try
            {
                SolicitudCD.EliminarSolicitud(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Solicitud", ex);
            }
        }
        public List<Solicitud> ViewSolicitud()
        {
            Solicitud cl;
            List<Solicitud> Lista = new List<Solicitud>();
            try
            {
                List<cp_ListarSolicitudResult> aux = SolicitudCD.ListarSolicitud();
                foreach (cp_ListarSolicitudResult op in aux)
                {
                    cl = new Solicitud(op.IdSolicitud, op.Fecha.Value, op.Estado,(int) op.IdAnimal, op.IdAdoptante);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Solicitud", ex);
            }
            return Lista;

        }
        public List<Solicitud> ViewSolicitudFiltro(string val)
        {
            Solicitud cl;
            List<Solicitud> Lista = new List<Solicitud>();
            try
            {
                List<cp_ListarSolicitud_FiltroResult> aux = SolicitudCD.ListarSolicitudFiltro(val);
                foreach (cp_ListarSolicitud_FiltroResult op in aux)
                {
                    cl = new Solicitud(op.IdSolicitud, op.Fecha.Value, op.Estado, (int)op.IdAnimal, op.IdAdoptante);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Solicitud", ex);
            }
            return Lista;

        }
    }
}

