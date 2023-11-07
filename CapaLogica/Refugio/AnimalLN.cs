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
    public class AnimalLN
    {
        public Animal GetIdAnimal(int val)
        {
            Animal cl = null;
            try
            {
                List<cp_BuscarAnimalResult> aux = AnimalCD.Buscar(val);
                foreach (cp_BuscarAnimalResult op in aux)
                {
                    cl = new Animal(op.IdAnimal, op.Nombre, (char)op.Sexo, op.FechaNacimiento.Value, op.Edad, op.Tamanio, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.FechaLlegada.Value,
                        (byte[])op.Foto.ToArray(), op.Especie, op.EstadoAnimal);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al Obtener los datos de la habitación por id", ex);
            }
            return cl;
        }


        public bool CreateAnimal(Animal op)
        {
            try
            {
                AnimalCD.InsertarAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al insertar Animal", ex);
            }
        }
        public bool UpdateAnimal(Animal op)
        {
            try
            {
                AnimalCD.EditarAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al modificar Animal", ex);
            }
        }
        public bool DeleteAnimal(Animal op)
        {
            try
            {
                AnimalCD.EliminarAnimal(op);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExcepciones("Error al eliminar Animal", ex);
            }
        }
        public List<Animal> ViewAnimal()
        {
            Animal cl;
            List<Animal> Lista = new List<Animal>();
            try
            {
                List<cp_ListarAnimalResult> aux = AnimalCD.ListarAnimal();
                foreach (cp_ListarAnimalResult op in aux)
                {
                    cl = new Animal(op.IdAnimal, op.Nombre, (char)op.Sexo, op.FechaNacimiento.Value,op.Edad, op.Tamanio, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.FechaLlegada.Value,
                        (byte[])op.Foto.ToArray(), op.Especie, op.EstadoAnimal);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Animal", ex);
            }
            return Lista;

        }
        public List<Animal> ViewAnimalFiltro(string val)
        {
            Animal cl;
            List<Animal> Lista = new List<Animal>();
            try
            {
                List<cp_ListarAnimal_FiltroResult> aux = AnimalCD.ListarAnimalFiltro(val);
                foreach (cp_ListarAnimal_FiltroResult op in aux)
                {
                    cl = new Animal(op.IdAnimal, op.Nombre, (char)op.Sexo, op.FechaNacimiento.Value, op.Edad, op.Tamanio, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.FechaLlegada.Value,
                        (byte[])op.Foto.ToArray(), op.Especie, op.EstadoAnimal);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Animal", ex);
            }
            return Lista;

        }
        public List<Animal> ViewAnimalFiltroXEstado(string val)
        {
            Animal cl;
            List<Animal> Lista = new List<Animal>();
            try
            {
                List<cp_ListarAnimalesXEstadoResult> aux = AnimalCD.ListarAnimalXEstado(val);
                foreach (cp_ListarAnimalesXEstadoResult op in aux)
                {
                    cl = new Animal(op.IdAnimal, op.Nombre, (char)op.Sexo, op.FechaNacimiento.Value, op.Edad, op.Tamanio, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad, op.Vacunas, op.FechaLlegada.Value,
                        (byte[])op.Foto.ToArray(), op.Especie, op.EstadoAnimal);
                    Lista.Add(cl);
                }

            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al mostrar datos filtrados de Animal", ex);
            }
            return Lista;

        }
    }
}
