using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface ITareaManager
    {
        /// <summary>
        /// Agrega una tarea.
        /// </summary>
        /// <param name="tarea">La tarea a agregar.</param>
        /// <exception cref="Exception">Puede lanzar una excepción genérica si ocurre un error.</exception>
        void AgregarTarea(Tareas tarea);

        /// <summary>
        /// Modifica una tarea existente.
        /// </summary>
        /// <param name="tarea">La tarea con las modificaciones.</param>
        /// <exception cref="Exception">Puede lanzar una excepción genérica si ocurre un error.</exception>
        void ModificarTarea(Tareas tarea);

        /// <summary>
        /// Elimina una tarea.
        /// </summary>
        /// <param name="tarea">La tarea a eliminar.</param>
        /// <exception cref="Exception">Puede lanzar una excepción genérica si ocurre un error.</exception>
        void EliminarTarea(Tareas tarea);
    }
}
