using CapaDatos;
using CapaDatos.Admin;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Admin
{
    public class TipoPersonalLN
    {
        public TipoPersonal GetIdTipoPersonal(string val)
        {
            TipoPersonal cl = null;
            try
            {
                List<cp_BuscarTipoPersonalResult> aux = TipoPersonalCD.BuscarIdTipoPersonal(val);
                foreach (cp_BuscarTipoPersonalResult p in aux)
                {
                    cl = new TipoPersonal(p.Tipo,p.Descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateTipoPersonal(TipoPersonal op)
        {
            try
            {
                TipoPersonalCD.InsertarTipoPersonal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert TipoPersonal", ex);
            }
        }
        public bool UpdateTipoPersonal(TipoPersonal op)
        {
            try
            {
                TipoPersonalCD.ModificarTipoPersonal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar TipoPersonal", ex);
            }
        }
        public bool DeleteTipoPersonal(TipoPersonal op)
        {
            try
            {
                TipoPersonalCD.EliminarTipoPersonal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar TipoPersonal", ex);
            }
        }
        public List<TipoPersonal> ViewTipoPersonal()
        {
            TipoPersonal op;
            List<TipoPersonal> Lista = new List<TipoPersonal>();
            try
            {
                List<cp_ListarTipoPersonalResult> aux = TipoPersonalCD.ListarTipoPersonal();
                foreach (cp_ListarTipoPersonalResult p in aux)
                {
                    op = new TipoPersonal(p.Tipo, p.Descripcion);
                    Lista.Add(op);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de TipoPersonal", ex);
            }
            return Lista;
        }
        
        public List<TipoPersonal> ViewTipoPersonalFiltro(string val)
        {
            TipoPersonal op;
            List<TipoPersonal> Lista = new List<TipoPersonal>();
            try
            {
                List<cp_ListarTipoPersonal_FiltroResult> aux = TipoPersonalCD.ListarTipoPersonalFiltro(val);
                foreach (cp_ListarTipoPersonal_FiltroResult p in aux)
                {
                    op = new TipoPersonal(p.Tipo, p.Descripcion);
                    Lista.Add(op);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de TipoPersonal", ex);
            }
            return Lista;

        }
    }
}
