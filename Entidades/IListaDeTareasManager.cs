using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IListaDeTareasManager
    {
        /// <summary>
        /// Agrega una lista de tareas.
        /// </summary>
        /// <param name="lista">La lista de tareas a agregar.</param>
        /// <exception cref="Exception">Puede lanzar una excepción genérica si ocurre un error.</exception>
        void AgregarListaDeTareas(ListaDeTareas lista);

        /// <summary>
        /// Modifica el nombre de la lista de tareas
        /// </summary>
        /// <param name="listaExistente">La Lista a modificar</param>
        /// <param name="nuevoNombre">Es el nombre a cambiar</param>
        void ModificarListaDeTareas(ListaDeTareas listaExistente, string nuevoNombre);

        /// <summary>
        /// Elimina una lista de tareas.
        /// </summary>
        /// <param name="lista">La lista de tareas a eliminar.</param>
        /// <exception cref="Exception">Puede lanzar una excepción genérica si ocurre un error.</exception>
        void EliminarListaDeTareas(ListaDeTareas lista);

        /// <summary>
        /// Verifica si la lista de tareas está contenida en el administrador.
        /// </summary>
        /// <param name="lista">La lista de tareas a verificar.</param>
        /// <returns>True si la lista de tareas está contenida; de lo contrario, false.</returns>
        /// <exception cref="Exception">Puede lanzar una excepción genérica si ocurre un error.</exception>
        bool ContieneListaDeTareas(ListaDeTareas lista);
    }
}
