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
    public class EstadoSolicitudLN
    {
        public EstadoSolicitud GetIdEstadoSolicitud(string val)
        {
            EstadoSolicitud cl = null;
            try
            {
                List<cp_BuscarEstadoSolicitudResult> aux = EstadoSolicitudCD.Buscar(val);
                foreach (cp_BuscarEstadoSolicitudResult op in aux)
                {
                    cl = new EstadoSolicitud(op.Estado, op.Descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateEstadoSolicitud(EstadoSolicitud op)
        {
            try
            {
                EstadoSolicitudCD.InsertarEstadoSolicitud(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar EstadoSolicitud", ex);
            }
        }
        public bool UpdateEstadoSolicitud(EstadoSolicitud op)
        {
            try
            {
                EstadoSolicitudCD.EditarEstadoSolicitud(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar EstadoSolicitud", ex);
            }
        }
        public bool DeleteEstadoSolicitud(EstadoSolicitud op)
        {
            try
            {
                EstadoSolicitudCD.EliminarEstadoSolicitud(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar EstadoSolicitud", ex);
            }
        }
        public List<EstadoSolicitud> ViewEstadoSolicitud()
        {
            EstadoSolicitud cl;
            List<EstadoSolicitud> Lista = new List<EstadoSolicitud>();
            try
            {
                List<cp_ListarEstadoSolicitudResult> aux = EstadoSolicitudCD.ListarEstadoSolicitud();
                foreach (cp_ListarEstadoSolicitudResult op in aux)
                {
                    cl = new EstadoSolicitud(op.Estado, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de EstadoSolicitud", ex);
            }
            return Lista;

        }
        public List<EstadoSolicitud> ViewEstadoSolicitudFiltro(string val)
        {
            EstadoSolicitud cl;
            List<EstadoSolicitud> Lista = new List<EstadoSolicitud>();
            try
            {
                List<cp_ListarEstadoSolicitud_FiltroResult> aux = EstadoSolicitudCD.ListarEstadoSolicitudFiltro(val);
                foreach (cp_ListarEstadoSolicitud_FiltroResult op in aux)
                {
                    cl = new EstadoSolicitud(op.Estado, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de EstadoSolicitud", ex);
            }
            return Lista;

        }
    }
}

