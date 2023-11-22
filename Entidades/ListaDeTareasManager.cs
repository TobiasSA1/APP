using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entidades
{
    public class ListaDeTareasManager : IListaDeTareasManager
    {
        public List<ListaDeTareas> ListasDeTareas { get; }

        public ListaDeTareasManager()
        {
            ListasDeTareas = new List<ListaDeTareas>();
        }


        public void SerializarListas(string filePath)
        {
            string jsonString = JsonSerializer.Serialize(ListasDeTareas);
            File.WriteAllText(filePath, jsonString);
        }

        // Método para deserializar la lista de listas de tareas desde JSON
        public void DeserializarListas(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                List<ListaDeTareas> listasDeserializadas = JsonSerializer.Deserialize<List<ListaDeTareas>>(jsonString);

                // Reemplazar la lista existente con la lista deserializada
                ListasDeTareas.Clear();
                ListasDeTareas.AddRange(listasDeserializadas);
            }
        }

        public void AgregarListaDeTareas(ListaDeTareas lista)
        {
            try
            {
                ListasDeTareas.Add(lista);
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al agregar una lista de tareas.", ex);
            }
        }
        public void ModificarListaDeTareas(ListaDeTareas listaExistente, string nuevoNombre)
        {
            try
            {
                if (ListasDeTareas.Contains(listaExistente))
                {
                    // Modificar el nombre de la lista existente
                    listaExistente.SetNombre(nuevoNombre);
                }
                else
                {
                    throw new ArgumentException("La lista especificada no pertenece a la ListaDeTareasManager.", nameof(listaExistente));
                }
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al modificar una lista de tareas.", ex);
            }
        }
        public void EliminarTareaDeLista(ListaDeTareas lista, Tareas tarea)
        {
            try
            {
                if (ListasDeTareas.Contains(lista))
                {
                    lista.EliminarTarea(tarea);
                }
                else
                {
                    throw new ArgumentException("La lista especificada no pertenece a la ListaDeTareasManager.", nameof(lista));
                }
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al eliminar una tarea de la lista de tareas.", ex);
            }
        }

        public void EliminarListaDeTareas(ListaDeTareas lista)
        {
            try
            {
                ListasDeTareas.Remove(lista);
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al eliminar una lista de tareas.", ex);
            }
        }

        public bool ContieneListaDeTareas(ListaDeTareas lista)
        {
            try
            {
                return ListasDeTareas.Contains(lista);
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al verificar si la lista de tareas contiene una lista específica.", ex);
            }
        }

        public string ObtenerFechaFormateada(ListaDeTareas listaDeTareas)
        {
            try
            {
                switch (listaDeTareas.Repetir)
                {
                    case Repeticion.Ninguna:
                        return string.Join(", ", listaDeTareas.Tareas.Select(t => ObtenerFechaFormateadaTarea(t)));

                    case Repeticion.Diaria:
                        return "Todos los días.";

                    case Repeticion.Dias:
                        if (listaDeTareas.Tareas.Any(t => t is TareaRutinaria rutinaria))
                        {
                            foreach (var tarea in listaDeTareas.Tareas)
                            {
                                var dias = "";

                                if (tarea is TareaRutinaria rutinariaTarea)
                                {
                                    var diasTarea = rutinariaTarea.MostrarDiasSemana();
                                    dias += diasTarea;
                                }
                                return dias.TrimEnd(',', ' '); ;
                            }
                        }
                        return string.Empty;

                    case Repeticion.EnFechaEspecifica:
                        return string.Join(", ", listaDeTareas.Tareas.Select(t => ObtenerFechaFormateadaTarea(t)));

                    default:
                        return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al obtener la fecha formateada de la lista de tareas.", ex);
            }
        }

        private static string ObtenerFechaFormateadaTarea(Tareas tarea)
        {
            try
            {
                return tarea.Fecha.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al obtener la fecha formateada de la tarea.", ex);
            }
        }
    }
}
