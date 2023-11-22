using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Entidades;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entidades
{
    public class TareasManager : ITareaManager
    {
        public List<Tareas> Tareas { get; }

        public TareasManager()
        {
            this.Tareas = new List<Tareas>();
        }


        // Método para serializar la lista de tareas a JSON
        public void SerializarTareas(string filePath)
        {
            string jsonString = JsonSerializer.Serialize(Tareas);
            File.WriteAllText(filePath, jsonString);
        }

        // Método para deserializar la lista de tareas desde JSON
        public void DeserializarTareas(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                List<Tareas> tareasDeserializadas = JsonSerializer.Deserialize<List<Tareas>>(jsonString);

                // Reemplazar la lista existente con la lista deserializada
                Tareas.Clear();
                Tareas.AddRange(tareasDeserializadas);
            }
        }

        public void AgregarTarea(Tareas tarea)
        {
            this.Tareas.Add(tarea);
        }

        public void ModificarTarea(Tareas tarea)
        {
            var tareaExistente = BuscarTareaPorNombre(tarea.Nombre);

            if (tareaExistente != null)
            {
                tareaExistente.ModificarTarea(tarea);
            }
        }

        private Tareas BuscarTareaPorNombre(string nombre)
        {
            return this.Tareas.FirstOrDefault(t => t.Nombre == nombre);
        }

        public void EliminarTarea(Tareas tarea)
        {
            // Encuentra la tarea en la lista y elimínala.
            var tareaExistente = this.Tareas.FirstOrDefault(t => t.Nombre == tarea.Nombre);

            if (tareaExistente != null)
            {
                Tareas.Remove(tareaExistente);
            }
        }

        public void MarcarCompleto(Tareas tarea)
        {

            if (tarea.Estado == EstadoTarea.Completo)
            {
                MarcarPendiente(tarea);

            }
            else
            {
                tarea.Estado = EstadoTarea.Completo;
            }
        }


        public void MarcarPendiente(Tareas tarea)
        {
            tarea.Estado = EstadoTarea.Pendiente;
        }

        public void MarcarIncompleto(Tareas tarea)
        {
            if (tarea.Estado != EstadoTarea.Completo)
            {
                tarea.Estado = (EsHoy(tarea) && tarea.Hora <= DateTime.Now.TimeOfDay) ? EstadoTarea.Incompleto : EstadoTarea.Pendiente;
            }
        }

        public bool EsHoy(Tareas tarea)
        {
            if (tarea is TareaRutinaria rutinaria && rutinaria.diasSemanales.Contains(DateTime.Today.DayOfWeek))
            {
                return true;
            }
            var fechaActual = DateTime.Today;
            return tarea.Fecha.Date == fechaActual.Date;
        }

        public bool EsRecurrente(Tareas tarea)
        {
            return tarea.Repetir != Repeticion.Ninguna;
        }

        public bool EsRecurrenteEnDia(Tareas tarea)
        {
            if (!EsRecurrente(tarea))
            {
                if (EsHoy(tarea))
                {
                    return true;
                }
            }
            switch (tarea.Repetir)
            {
                case Repeticion.Diaria:
                    return true;

                case Repeticion.Dias:
                    return tarea is TareaRutinaria rutinaria && rutinaria.diasSemanales.Contains(DateTime.Today.DayOfWeek);

                case Repeticion.EnFechaEspecifica:

                    //Validar por primer campo de Fecha Especifica.

                    return tarea.Fecha.Date == DateTime.Today.Date;

                default:
                    return false;
            }
        }

        public string ObtenerFechaFormateada(Tareas tarea)
        {
            switch (tarea.Repetir)
            {
                case Repeticion.Ninguna:
                    return tarea.Fecha.ToString("dd/MM/yyyy");

                case Repeticion.Diaria:
                    return "Todos los dias.";

                case Repeticion.Dias:
                    if (tarea is TareaRutinaria rutinaria)
                    {
                        var dias = rutinaria.MostrarDiasSemana();
                        return string.Join(", ", dias);
                    }
                    return string.Empty;

                case Repeticion.EnFechaEspecifica:
                    return tarea.Fecha.ToString("dd/MM/yyyy");

                default:
                    return string.Empty;
            }
        }

    }
}
