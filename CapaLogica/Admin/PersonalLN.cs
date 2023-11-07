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
    public class PersonalLN
    {
        public Personal GetIdPersonal(string val)
        {
            Personal cl = null;
            try
            {
                List<cp_BuscarPersonalResult> aux = PersonalCD.BuscarIdPersonal(val);
                foreach (cp_BuscarPersonalResult p in aux)
                {
                    cl = new Personal(p.IdPersonal,p.Identificacion,p.Nombres,p.Apellidos,((char)p.Sexo),p.FechaNacimiento.Value,((int)p.Edad),p.Ciudad,p.Direccion,p.Telefono,p.Email,p.Tipo);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos del personal por id", ex);
            }
            return cl;
        }

      
        public bool CreatePersonal(Personal op)
        {
            try
            {
                PersonalCD.InsertarPersonal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Personal", ex);
            }
        }
        public bool UpdatePersonal(Personal op)
        {
            try
            {
                PersonalCD.EditarPersonal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Personal", ex);
            }
        }
        public bool DeletePersonal(Personal op)
        {
            try
            {
                PersonalCD.EliminarPersonal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Personal", ex);
            }
        }
        public List<Personal> ViewPersonal()
        {
            Personal op;
            List<Personal> Lista = new List<Personal>();
            try
            {
                List<cp_ListarPersonalResult> aux = PersonalCD.ListarPersonal();
                foreach (cp_ListarPersonalResult p in aux)
                {
                    op = new Personal(p.IdPersonal, p.Identificacion, p.Nombres, p.Apellidos, ((char)p.Sexo), p.FechaNacimiento.Value, ((int)p.Edad), p.Ciudad, p.Direccion, p.Telefono, p.Email, p.Tipo);
                    Lista.Add(op);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Personal", ex);
            }
            return Lista;

        }
        public List<Personal> ViewPersonalFiltro(string val)
        {
            Personal op;
            List<Personal> Lista = new List<Personal>();
            try
            {
                List<cp_ListarPersonal_FiltroResult> aux = PersonalCD.ListarPersonalFiltro(val);
                foreach (cp_ListarPersonal_FiltroResult p in aux)
                {
                    op = new Personal(p.IdPersonal, p.Identificacion, p.Nombres, p.Apellidos, ((char)p.Sexo), p.FechaNacimiento.Value, ((int)p.Edad), p.Ciudad, p.Direccion, p.Telefono, p.Email,p.Tipo);
                    Lista.Add(op);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Personal", ex);
            }
            return Lista;

        }
    }
}
