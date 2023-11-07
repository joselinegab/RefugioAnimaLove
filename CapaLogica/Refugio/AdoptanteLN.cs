using CapaDatos;
using CapaDatos.CD;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Refugio
{
    public class AdoptanteLN
    {
        public Adoptante GetIdAdoptante(string val)
        {
            Adoptante cl = null;
            try
            {
                List<cp_BuscarAdoptanteResult> aux = AdoptanteCD.BuscarIdAdoptante(val);
                foreach (cp_BuscarAdoptanteResult op in aux)
                {
                    cl = new Adoptante(op.IdAdoptante, op.Identificacion, op.Nombres, op.Apellidos, (char)op.Sexo, op.FechaNacimiento.Value, (int)op.Edad,op.Ciudad,op.Direccion,op.Celular,op.Email);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateAdoptante(Adoptante op)
        {
            try
            {
                AdoptanteCD.InsertarAdoptante(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Adoptante", ex);
            }
        }
        public bool UpdateAdoptante(Adoptante op)
        {
            try
            {
                AdoptanteCD.EditarAdoptante(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Adoptante", ex);
            }
        }
        public bool DeleteAdoptante(Adoptante op)
        {
            try
            {
                AdoptanteCD.EliminarAdoptante(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Adoptante", ex);
            }
        }
        public List<Adoptante> ViewAdoptante()
        {
            Adoptante cl;
            List<Adoptante> Lista = new List<Adoptante>();
            try
            {
                List<cp_ListarAdoptanteResult> aux = AdoptanteCD.ListarAdoptante();
                foreach (cp_ListarAdoptanteResult op in aux)
                {
                    cl = new Adoptante(op.IdAdoptante, op.Identificacion, op.Nombres, op.Apellidos, (char)op.Sexo, op.FechaNacimiento.Value, (int)op.Edad, op.Ciudad, op.Direccion, op.Celular, op.Email);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Adoptante", ex);
            }
            return Lista;

        }
        public List<Adoptante> ViewAdoptanteFiltro(string val)
        {
            Adoptante cl;
            List<Adoptante> Lista = new List<Adoptante>();
            try
            {
                List<cp_ListarAdoptante_FiltroResult> aux = AdoptanteCD.ListarAdoptanteFiltro(val);
                foreach (cp_ListarAdoptante_FiltroResult op in aux)
                {
                    cl = new Adoptante(op.IdAdoptante, op.Identificacion, op.Nombres, op.Apellidos, (char)op.Sexo, op.FechaNacimiento.Value, (int)op.Edad, op.Ciudad, op.Direccion, op.Celular, op.Email);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Adoptante", ex);
            }
            return Lista;

        }
    }
}
