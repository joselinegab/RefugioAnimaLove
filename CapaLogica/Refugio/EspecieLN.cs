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
    public class EspecieLN
    {
        public Especie GetIdEspecie(string val)
        {
            Especie cl = null;
            try
            {
                List<cp_BuscarEspecieResult> aux = EspecieCD.Buscar(val);
                foreach (cp_BuscarEspecieResult op in aux)
                {
                    cl = new Especie(op.Especie,op.Descripcion);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateEspecie(Especie op)
        {
            try
            {
                EspecieCD.InsertarEspecie(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Especie", ex);
            }
        }
        public bool UpdateEspecie(Especie op)
        {
            try
            {
                EspecieCD.EditarEspecie(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Especie", ex);
            }
        }
        public bool DeleteEspecie(Especie op)
        {
            try
            {
                EspecieCD.EliminarEspecie(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Especie", ex);
            }
        }
        public List<Especie> ViewEspecie()
        {
            Especie cl;
            List<Especie> Lista = new List<Especie>();
            try
            {
                List<cp_ListarEspecieResult> aux = EspecieCD.ListarEspecie();
                foreach (cp_ListarEspecieResult op in aux)
                {
                    cl = new Especie(op.Especie, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Especie", ex);
            }
            return Lista;

        }
        public List<Especie> ViewEspecieFiltro(string val)
        {
            Especie cl;
            List<Especie> Lista = new List<Especie>();
            try
            {
                List<cp_ListarEspecie_FiltroResult> aux = EspecieCD.ListarEspecieFiltro(val);
                foreach (cp_ListarEspecie_FiltroResult op in aux)
                {
                    cl = new Especie(op.Especie, op.Descripcion);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Especie", ex);
            }
            return Lista;

        }
    }
}
