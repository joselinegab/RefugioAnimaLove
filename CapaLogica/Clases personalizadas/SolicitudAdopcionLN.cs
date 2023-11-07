using CapaDatos;
using CapaDatos.Clases_personalizadas;
using CapaEntidades.Clases_personalizadas;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CapaLogica.Clases_personalizadas
{
    public class SolicitudAdopcionLN
    {
        public List<SolicitudAdopcion> ViewSolicitudAdopcion()
        {
            SolicitudAdopcion cl;
            List<SolicitudAdopcion> Lista = new List<SolicitudAdopcion>();
            try
            {
                List<cp_ListarSolicitudAdopcionResult> aux = SolicitudAdopcionCD.ListarSolicitudAdop();
                foreach (cp_ListarSolicitudAdopcionResult op in aux)
                {
                    cl = new SolicitudAdopcion(op.IdSolicitud,op.Fecha.Value,op.Identificacion,op.Nombres,op.Apellidos,(int)op.EdadA,op.Ciudad,op.Direccion,
                        op.Celular,op.Email,op.Nombre,(byte[])op.Foto.ToArray(),op.Edad,(char)op.Sexo,op.Peso,op.Enfermo,op.Esterilizado,op.Enfermedad,op.Vacunas,op.Estado,
                        op.IdAdoptante,op.IdAnimal);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de SolicitudAdopcion", ex);
            }
            return Lista;

        }
        public List<SolicitudAdopcion> ViewSolicitudAdopcionFiltro(string valor)
        {
            List<SolicitudAdopcion> Lista = new List<SolicitudAdopcion>();
            SolicitudAdopcion obp = null;
            try
            {

                List<cp_ListarSolicitudAdopcion_FiltroResult> auxLista = SolicitudAdopcionCD.ListarSolicitudAdop_Filtro(valor);
                foreach (cp_ListarSolicitudAdopcion_FiltroResult op in auxLista)
                {
                    obp = new SolicitudAdopcion(op.IdSolicitud, op.Fecha.Value, op.Identificacion, op.Nombres, op.Apellidos, (int)op.EdadA, op.Ciudad, op.Direccion,
                        op.Celular, op.Email, op.Nombre, (byte[])op.Foto.ToArray(), op.Edad, (char)op.Sexo, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.Estado,
                        op.IdAdoptante, op.IdAnimal);
                    Lista.Add(obp);
                }
                return Lista;

            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Producto Categoria filtro");
            }

        }
        public List<SolicitudAdopcion> ViewSolicitudAdopcionFiltroXAdoptante(string valor)
        {
            List<SolicitudAdopcion> Lista = new List<SolicitudAdopcion>();
            SolicitudAdopcion obp = null;
            try
            {

                List<cp_ListarSolicitudAdopcion_FiltroXIdAdoptanteResult> auxLista = SolicitudAdopcionCD.ListarSolicitudAdopXIdAdop(valor);
                foreach (cp_ListarSolicitudAdopcion_FiltroXIdAdoptanteResult op in auxLista)
                {
                    obp = new SolicitudAdopcion(op.IdSolicitud, op.Fecha.Value, op.Identificacion, op.Nombres, op.Apellidos, (int)op.EdadA, op.Ciudad, op.Direccion,
                        op.Celular, op.Email, op.Nombre, (byte[])op.Foto.ToArray(), op.Edad, (char)op.Sexo, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.Estado,
                        op.IdAdoptante, op.IdAnimal);
                    Lista.Add(obp);
                }
                return Lista;

            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error Mostrar en la logica a Producto Categoria filtro");
            }

        }
    }
}
