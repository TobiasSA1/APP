using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    public class TareaIrregular : Tareas
    {
        public override DateTime Fecha { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, this.GetType(), new JsonSerializerOptions { WriteIndented = true });
        }

        public static TareaIrregular FromJson(string json)
        {
            return JsonSerializer.Deserialize<TareaIrregular>(json);
        }

        public TareaIrregular(string nombre, TimeSpan hora, string descripcion, EstadoTarea estado, DateTime fecha)
            : base(nombre, TipoTarea.Irregular, hora, Repeticion.Ninguna, descripcion, estado)
        {
            try
            {
                SetFecha(fecha);
            }
            catch (ArgumentException ex)
            {
                // Puedes agregar un manejador de excepciones específico o simplemente lanzar la excepción nuevamente
                throw new ArgumentException("Error al crear una tarea irregular.", ex);
            }
        }

        private void SetFecha(DateTime fecha)
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
    }
}
