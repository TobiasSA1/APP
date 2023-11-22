using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{

    public abstract class Tareas
    {
        public string Nombre { get; set; }
        public TipoTarea Tipo { get; set; }
        public TimeSpan Hora { get; set; }
        public Repeticion Repetir { get; set; }
        public EstadoTarea Estado { get; set; }
        public string Descripcion { get; set; }
        public virtual DateTime Fecha { get; set; }

        public Tareas(string nombre, TipoTarea tipo, TimeSpan hora, Repeticion repetir, string descripcion, EstadoTarea estado)
        {
            SetNombre(nombre);
            SetTipo(tipo);
            SetHora(hora);
            SetRepetir(repetir);
            SetDescripcion(descripcion);
            SetEstado(estado);
        }

        public void ModificarTarea(Tareas nuevaTarea)
        {
            SetNombre(nuevaTarea.Nombre);
            SetTipo(nuevaTarea.Tipo);
            SetHora(nuevaTarea.Hora);
            SetRepetir(nuevaTarea.Repetir);
            SetEstado(nuevaTarea.Estado);
            SetDescripcion(nuevaTarea.Descripcion);
        }

        public void SetNombre(string nombre)
        {
            ValidarTextoNoVacio(nombre, "nombre de la tarea");
            this.Nombre = nombre;
        }

        private void SetTipo(TipoTarea tipo)
        {
            this.Tipo = tipo;
        }

        public void SetHora(TimeSpan hora)
        {
            if (hora < TimeSpan.Zero || hora >= TimeSpan.FromDays(1))
            {
                throw new ArgumentException("La hora debe estar en el rango de 00:00 a 23:59.", nameof(hora));
            }

            this.Hora = hora;
        }

        private void SetRepetir(Repeticion repetir)
        {
            this.Repetir = repetir;
        }

        private void SetDescripcion(string descripcion)
        {
            this.Descripcion = descripcion;
        }

        private void SetEstado(EstadoTarea estado)
        {
            this.Estado = estado;
        }

        private static void ValidarTextoNoVacio(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException($"El {nombreCampo} no puede estar vacío o contener solo espacios en blanco.", nameof(texto));
            }
        }

        public string EstadoToString()
        {

            return this.Estado.ToString();
        }

        public override string ToString()
        {

            return $"(Tarea) - {this.Nombre}";
        }

        public string HoraToString()
        {
            return Hora.ToString(@"hh\:mm");
        }

    }
}
