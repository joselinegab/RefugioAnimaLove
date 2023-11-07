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
    public class UsuarioLN
    {
        public Usuario GetIdUsuario(string val)
        {
            Usuario cl = null;
            try
            {
                List<cp_BuscarUsuarioResult> aux = UsuarioCD.BuscarIdUsuario(val);
                foreach (cp_BuscarUsuarioResult cat in aux)
                {
                    cl = new Usuario(cat.IdUsuario, cat.Usuario, cat.Contrasenia);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos del usuario por id", ex);
            }
            return cl;
        }

        //public List<Usuario> ViewUsuario()
        //{
        //    List<Usuario> Lista = new List<Usuario>();
        //    try
        //    {
        //        List<Usuario> aux = UsuarioCD.ListarUsuario();


        //        foreach (Usuario cat in aux)
        //        {
        //            op = new Usuario(cat.IdUser, cat.User, cat.Pass);
        //            Lista.Add(op);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new LogicaExcepciones("Error a Mostrar datos Usuario", ex);
        //    }

        //    return Lista;
        //}

        //public bool Verificar(UsuarioLogin op)
        //{
        //    try
        //    {
        //        UsuarioCD.VerificarLogin(op);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new LogicaExcepciones("Error al verificar el usuario y contraseña", ex);
        //    }
        //}

        public bool CreateUsuario(Usuario op)
        {
            try
            {
                UsuarioCD.InsertarUsuario(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insert Usuario", ex);
            }
        }
        public bool UpdateUsuario(Usuario op)
        {
            try
            {
                UsuarioCD.EditarUsuario(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Usuario", ex);
            }
        }
        public bool DeleteUsuario(Usuario op)
        {
            try
            {
                UsuarioCD.EliminarUsuario(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Usuario", ex);
            }
        }

        public List<Usuario> ViewUsuario()
        {
            Usuario op;
            List<Usuario> Lista = new List<Usuario>();
            try
            {
                List<cp_ListarUsuarioResult> aux = UsuarioCD.ListarUsuario();
                foreach (cp_ListarUsuarioResult cat in aux)
                {
                    op = new Usuario(cat.IdUsuario, cat.Usuario, cat.Contrasenia);
                    Lista.Add(op);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Usuario", ex);
            }
            return Lista;

        }
        //public List<UsuarioLogin> ViewUsuarioPerso()
        //{
        //    UsuarioLogin op;
        //    List<UsuarioLogin> Lista = new List<UsuarioLogin>();
        //    try
        //    {
        //        List<cp_ListarUsuarioResult> aux = UsuarioCD.ListarUsuario();
        //        foreach (cp_ListarUsuarioResult cat in aux)
        //        {
        //            op = new UsuarioLogin(cat.Usuario, cat.Contrasena);
        //            Lista.Add(op);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new DatosExcepciones("Error al mostrar datos filtrados de Usuario", ex);
        //    }
        //    return Lista;

        //}

        public List<Usuario> ViewUsuarioFiltro(string val)
        {
            Usuario op;
            List<Usuario> Lista = new List<Usuario>();
            try
            {
                List<cp_ListarUsuario_FiltroResult> aux = UsuarioCD.ListarUsuarioFiltro(val);
                foreach (cp_ListarUsuario_FiltroResult cat in aux)
                {
                    op = new Usuario(cat.IdUsuario, cat.Usuario, cat.Contrasenia);
                    Lista.Add(op);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Usuario", ex);
            }
            return Lista;

        }
    }
}
