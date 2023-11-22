using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public class TareaRutinaria : Tareas
    {
        public HashSet<DayOfWeek> diasSemanales { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, this.GetType(), new JsonSerializerOptions { WriteIndented = true });
        }

        public static TareaRutinaria FromJson(string json)
        {
            return JsonSerializer.Deserialize<TareaRutinaria>(json);
        }

        public TareaRutinaria(string nombre, TimeSpan hora, Repeticion repetir, string descripcion, EstadoTarea estado, HashSet<DayOfWeek> dias, DateTime fecha)
            : base(nombre, TipoTarea.Rutinaria, hora, repetir, descripcion, estado)
        {
            try
            {
                // Validar que la repetición sea correcta para una tarea rutinaria
                if (repetir != Repeticion.Dias && repetir != Repeticion.Diaria && repetir != Repeticion.EnFechaEspecifica)
                {
                    throw new ArgumentException("La repetición no es válida para una tarea rutinaria.", nameof(repetir));
                }

                this.diasSemanales = dias;

                if (repetir == Repeticion.EnFechaEspecifica)
                {
                   SetFecha(fecha);

                }
                else
                {
                    this.Fecha = DateTime.MinValue;
                }
            }
            catch (ArgumentException ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente

                throw new ArgumentException("Error al crear una tarea rutinaria.", ex);
            }
        }

        public void SetFecha(DateTime fecha)
        {
            try
            {
                if (fecha < DateTime.Today)
                {
                    throw new ArgumentException("La fecha no puede ser anterior a la fecha actual.", nameof(fecha));
                }

                this.Fecha = fecha;
            }
            catch (ArgumentException ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new ArgumentException("Error al establecer la fecha de la tarea irregular.", ex);
            }
        }

        public void AgregarDiasSemana(HashSet<DayOfWeek> dias)
        {
            try
            {
                // Validar que la repetición sea correcta para agregar días
                if (base.Repetir != Repeticion.Dias)
                {
                    throw new InvalidOperationException("Solo se pueden agregar días para tareas con repetición semanal.");
                }

                this.diasSemanales.UnionWith(dias);
            }
            catch (InvalidOperationException ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new InvalidOperationException("Error al agregar días a la tarea rutinaria.", ex);
            }
        }

        public string MostrarDiasSemana()
        {
            try
            {
                if (base.Repetir == Repeticion.Ninguna)
                {
                    return string.Empty;
                }

                if (base.Repetir == Repeticion.Diaria)
                {
                    return "Diaria";
                }

                // Días de la semana en inglés
                DayOfWeek[] diasEnIngles = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
                // Días de la semana en español
                string[] diasEnEspanol = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

                // Obtiene los días directamente de la propiedad
                HashSet<DayOfWeek> diasHashSet = this.diasSemanales;

                // Traducción y formateo de días
                var diasTraducidos = diasEnIngles.Where(dia => diasHashSet.Contains(dia))
                                                 .Select(dia => TraducirDia(dia, diasEnIngles, diasEnEspanol));

                return string.Join(", ", diasTraducidos);
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al mostrar los días de la semana de la tarea rutinaria.", ex);
            }
        }

        private static string TraducirDia(DayOfWeek dia, DayOfWeek[] diasEnIngles, string[] diasEnEspanol)
        {
            try
            {
                int indice = Array.IndexOf(diasEnIngles, dia);

                if (indice >= 0 && indice < diasEnEspanol.Length)
                {
                    return diasEnEspanol[indice];
                }

                // Si no se encuentra en la lista de traducción, se devuelve el día original
                return dia.ToString();
            }
            catch (Exception ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new Exception("Error al traducir el día de la tarea rutinaria.", ex);
            }
        }
    }
}
