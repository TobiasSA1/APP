using Entidades;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Xml;
using System.Text.Json;
using static ToDoTasks.formPrincipal;
using System.Dynamic;

namespace ToDoTasks
{
    public partial class formPrincipal : Form
    {

        private System.Windows.Forms.Timer timer;

        private TareasManager tareasManager;

        private ListaDeTareasManager listaDeTareasManager;

        /// <summary>
        /// Formulario principal, inicializa las listas.
        /// </summary>
        /// 
        public formPrincipal()
        {
            InitializeComponent();

            tareasManager = new TareasManager();
            listaDeTareasManager = new ListaDeTareasManager();

            InicializarDatosDeEjemplo();
            InicializarCosasFormulario();

        }


        /// <summary>
        /// Actualizaciones de los Listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarListViewTareas();

            ActualizarlistViewTareasHoy();

        }


        /// <summary>
        /// Hardcodear datos de "LISTA TAREAS", "TAREAS" y FORMULARIO (BORRAR DSPS, PASARLO A ARCHIVOS)
        /// </summary>
        private void InicializarCosasFormulario()
        {
            ///////FORMULARIO////////
            /// List View Tareas de HOY
            listViewTareasHoy.FullRowSelect = true;
            listViewTareasHoy.View = View.Details;
            listViewTareasHoy.Columns.Add("Tarea:", 325);
            listViewTareasHoy.Columns.Add("Hora:", 200);
            listViewTareasHoy.Columns.Add("Estado:", 210);
            listViewTareasHoy.Font = new Font("Courier New", 10);
            listViewTareasHoy.GridLines = true;
            listViewTareasHoy.ForeColor = Color.FromArgb(0, 0, 255);


            ///////FORMULARIO////////
            ///List View Total tareas
            listViewTareas.FullRowSelect = true;
            listViewTareas.View = View.Details;
            listViewTareas.Columns.Add("Nombre:", 350);
            listViewTareas.Columns.Add("Frecuencia:", 225);
            listViewTareas.Columns.Add("Repeticion:", 210);
            listViewTareas.Columns.Add("Fecha:", 210);
            listViewTareas.Font = new Font("Courier New", 10);
            listViewTareas.GridLines = true;
            listViewTareas.ForeColor = Color.FromArgb(0, 0, 255);



            ///////FORMULARIO////////
            ///List View De Listas Seleccionadas
            listViewListaSeleccionada.FullRowSelect = true;
            listViewListaSeleccionada.View = View.Details;
            listViewListaSeleccionada.Columns.Add("Nombre:", 150);
            listViewListaSeleccionada.Columns.Add("Horario:", 150);
            listViewListaSeleccionada.Columns.Add("Dia/Dias:", 150);
            listViewListaSeleccionada.Font = new Font("Courier New", 10);
            listViewListaSeleccionada.GridLines = true;
            listViewListaSeleccionada.ForeColor = Color.FromArgb(0, 0, 255);
            textBoxDescripcion.Multiline = true;
            textBoxDescripcion.ReadOnly = true;

            timer = new System.Windows.Forms.Timer();

            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();

        }
        private void InicializarDatosDeEjemplo()
        {
            // Agregar listas de tareas y tareas de ejemplo.


            HashSet<DayOfWeek> dias = new HashSet<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Monday, DayOfWeek.Sunday };

            var dia = new DateTime(2023, 11, 22);

            //Lista TIPO (Irregular) con REPETICION (Ninguna)
            var listaNinguna = new ListaDeTareas("Lista Irregular (Ninguna)", TipoTarea.Irregular, Repeticion.Ninguna);

            var tareaIrregular = new TareaIrregular("Tarea irregular en lista", TimeSpan.Parse("19:30"), "Esta tarea se maneja por el DateTime Fecha que tiene. Y no posee ninguna repeticion, una vez realizada no se repite.", EstadoTarea.Pendiente, dia);
            var tareaIrregular2 = new TareaIrregular("Tarea irregular2 en lista", TimeSpan.Parse("19:30"), "Esta tarea se maneja por el DateTime Fecha que tiene. Y no posee ninguna repeticion, una vez realizada no se repite.", EstadoTarea.Pendiente, dia);

            //Tarea TIPO (Irregular) con REPETICION (Ninguna)
            var tareaSolitaria = new TareaIrregular("Tarea irregular Solitaria (Ninguna)", TimeSpan.Parse("14:30"), "Esta tarea se maneja por el DateTime Fecha que tiene. Y no posee ninguna repeticion, una vez realizada no se repite.", EstadoTarea.Pendiente, dia);

            //////////////////////////////////////////////////

            //Lista TIPO (Rutinaria) con REPETICION (Dias)
            var listaDias = new ListaDeTareas("Lista Rutinaria (Dias)", TipoTarea.Rutinaria, Repeticion.Dias);
            var tareaRutinariaDias1 = new TareaRutinaria("Tarea1 Rutinaria en lista (Dias)", TimeSpan.Parse("00:30"), Repeticion.Dias, "Esta tarea se maneja por DayOfWeek, mostrando los dias que debe repetirese", EstadoTarea.Pendiente, dias, DateTime.Now);
            var tareaRutinariaDias2 = new TareaRutinaria("Tarea2 Rutinaria en lista (Dias)", TimeSpan.Parse("11:00"), Repeticion.Dias, "Esta tarea se maneja por DayOfWeek, mostrando los dias que debe repetirese", EstadoTarea.Pendiente, dias, DateTime.Now);

            //Lista TIPO (Rutinaria) con REPETICION (En Fecha especifica), eso significa que se repetira cada Fecha del mes.
            var listaFechaEspecifica = new ListaDeTareas("Lista Rutinaria (En Fecha especifica)", TipoTarea.Rutinaria, Repeticion.EnFechaEspecifica);
            var tareaRutinariaEnFechaEspecifica1 = new TareaRutinaria("Tarea1 Rutinaria en lista (En Fecha especifica)", TimeSpan.Parse("23:30"), Repeticion.EnFechaEspecifica, "Esta es una tarea que se maneja por DateTime Fecha y se repite ese dia Cada mes.", EstadoTarea.Pendiente, dias, DateTime.Now);
            var tareaRutinariaEnFechaEspecifica2 = new TareaRutinaria("Tarea1 Rutinaria en lista (En Fecha especifica)", TimeSpan.Parse("11:30"), Repeticion.EnFechaEspecifica, "Esta es una tarea que se maneja por DateTime Fecha y se repite ese dia Cada mes.", EstadoTarea.Pendiente, dias, DateTime.Now);

            //Lista TIPO (Rutinaria) con REPETICION (Diaria)
            var listaDiaria = new ListaDeTareas("Lista Rutinaria (Diaria)", TipoTarea.Rutinaria, Repeticion.Diaria);
            var tareaRutinariaDiaria1 = new TareaRutinaria("Tarea1 Rutinaria en lista (Diaria)", TimeSpan.Parse("06:00"), Repeticion.Diaria, "Esta tarea siempre va a ser TRUE, por ser diaria", EstadoTarea.Pendiente, dias, DateTime.Now);
            var tareaRutinariaDiaria2 = new TareaRutinaria("Tarea2 Rutinaria en lista (Diaria)", TimeSpan.Parse("9:20"), Repeticion.Diaria, "Esta tarea siempre va a ser TRUE, por ser diaria", EstadoTarea.Pendiente, dias, DateTime.Now);


            //Tarea Solitaria TIPO (Rutinaria) con REPETICION (Diaria)
            var tareaRutinariaDiaria = new TareaRutinaria("Tarea Rutinaria solitaria (Diaria)", TimeSpan.Parse("22:30"), Repeticion.Diaria, "Esta es una tarea rutinaria, Diaria.", EstadoTarea.Pendiente, dias, DateTime.Now);
            //Tarea Solitaria TIPO (Rutinaria) con REPETICION (En Fecha especifica), eso significa que se repetira cada Fecha del mes.
            var tareaRutinariaEnFechaEspecifica = new TareaRutinaria("Tarea Rutinaria solitaria (En Fecha especifica)", TimeSpan.Parse("22:30"), Repeticion.EnFechaEspecifica, "Esta es una tarea, rutinaria solitaria que se realiza x mes", EstadoTarea.Pendiente, dias, DateTime.Now);
            //Tarea Solitaria TIPO (Rutinaria) con REPETICION (Dias)
            var tareaRutinariaDias = new TareaRutinaria("Tarea Rutinaria solitaria (Dias)", TimeSpan.Parse("22:30"), Repeticion.Dias, "Esta es una tarea, rutinaria que se realiza ciertos dias de la semana", EstadoTarea.Pendiente, dias, DateTime.Now);

            tareasManager.AgregarTarea(tareaRutinariaDiaria);
            tareasManager.AgregarTarea(tareaRutinariaDias);
            tareasManager.AgregarTarea(tareaRutinariaEnFechaEspecifica);
            tareasManager.AgregarTarea(tareaSolitaria);

            listaNinguna.AgregarTarea(tareaIrregular);
            listaNinguna.AgregarTarea(tareaIrregular2);

            listaDias.AgregarTarea(tareaRutinariaDias1);
            listaDias.AgregarTarea(tareaRutinariaDias2);

            listaDiaria.AgregarTarea(tareaRutinariaDiaria1);
            listaDiaria.AgregarTarea(tareaRutinariaDiaria2);

            listaFechaEspecifica.AgregarTarea(tareaRutinariaEnFechaEspecifica1);
            listaFechaEspecifica.AgregarTarea(tareaRutinariaEnFechaEspecifica2);

            listaDeTareasManager.AgregarListaDeTareas(listaDiaria);
            listaDeTareasManager.AgregarListaDeTareas(listaFechaEspecifica);
            listaDeTareasManager.AgregarListaDeTareas(listaDias);
            listaDeTareasManager.AgregarListaDeTareas(listaNinguna);

        }

        /// <summary>
        /// Editor del reloj (Buscar otra forma de actualizar)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            // Actualizar el contenido del Label con la hora actual

            labelHoraActual.Text = DateTime.Now.ToString("HH:mm:ss");
        }



        /// <summary>
        /// 
        /// </summary>
        private void ActualizarListViewTareas()
        {
            // Limpia y vuelve a llenar el ListBox de tareas.

            listViewTareas.Items.Clear();

            foreach (var lista in listaDeTareasManager.ListasDeTareas)
            {
                var item = new ListViewItem(new[] { lista.ToString(), lista.Tipo.ToString(), lista.Repetir == Repeticion.EnFechaEspecifica ? "Fecha/s en especifico" : lista.Repetir.ToString(), listaDeTareasManager.ObtenerFechaFormateada(lista) });

                listViewTareas.Items.Add(item);

                item.Tag = lista;
            }

            foreach (var tarea in tareasManager.Tareas)
            {
                var item = new ListViewItem(new[] { tarea.ToString(), tarea.Tipo.ToString(), tarea.Repetir == Repeticion.EnFechaEspecifica ? "Fecha/s en especifico" : tarea.Repetir.ToString(), tareasManager.ObtenerFechaFormateada(tarea) });
                listViewTareas.Items.Add(item);

                item.Tag = tarea;
            }
        }


        /// <summary>
        /// Actualiza el list view de las Tareas
        /// </summary>
        public void ActualizarlistViewTareasHoy()
        {
            // Limpia y vuelve a llenar el ListView de tareas de hoy (filtrado por la fecha actual).

            listViewTareasHoy.Items.Clear();

            List<object> tareasYListas = new List<object>();

            foreach (var lista in listaDeTareasManager.ListasDeTareas)
            {
                foreach (var tarea in lista.Tareas)
                {
                    if (tareasManager.EsRecurrenteEnDia(tarea))
                    {
                        tareasManager.MarcarIncompleto(tarea);
                        tareasYListas.Add(tarea);
                    }
                }
            }

            foreach (var tarea in tareasManager.Tareas)
            {
                if (tareasManager.EsRecurrenteEnDia(tarea))
                {
                    tareasManager.MarcarIncompleto(tarea);
                    tareasYListas.Add(tarea);
                }
            }

            tareasYListas = OrdenamientoPorHora(tareasYListas);

            // Limpiar y volver a llenar el ListView con la lista ordenada
            foreach (var item in tareasYListas)
            {
                var listItem = new ListViewItem();

                if (item is Tareas tarea)
                {
                    // Configurar el ListViewItem para tareas individuales
                    listItem = new ListViewItem(new[] { tarea.Nombre, tarea.HoraToString(), tarea.EstadoToString() });
                }
                else if (item is ListaDeTareas lista)
                {
                    // Configurar el ListViewItem para listas (incluso si no tienen tareas)
                    var tareaMasTemprana = lista.Tareas.OrderBy(t => t.Hora).FirstOrDefault();
                    listItem = new ListViewItem(new[] { lista.Nombre, tareaMasTemprana?.Nombre ?? "", tareaMasTemprana?.HoraToString() ?? "", tareaMasTemprana?.EstadoToString() ?? "" });
                }

                listItem.Tag = item;
                listViewTareasHoy.Items.Add(listItem);
            }

            // Después de actualizar listViewTareasHoy, también actualiza listViewTareas
            ActualizarListViewTareas();
        }

        private static List<object> OrdenamientoPorHora(List<object> listaOriginal)
        {
            List<object> listaOrdenada = new List<object>(listaOriginal);

            // Implementar el algoritmo de ordenación de burbuja
            for (int i = 0; i < listaOrdenada.Count - 1; i++)
            {
                for (int j = 0; j < listaOrdenada.Count - 1 - i; j++)
                {
                    TimeSpan horaX = (listaOrdenada[j] is Tareas tareaX) ? tareaX.Hora : TimeSpan.Zero;
                    TimeSpan horaY = (listaOrdenada[j + 1] is Tareas tareaY) ? tareaY.Hora : TimeSpan.Zero;

                    if (TimeSpan.Compare(horaX, horaY) > 0)
                    {
                        // Intercambiar elementos si están en el orden incorrecto
                        var temp = listaOrdenada[j];
                        listaOrdenada[j] = listaOrdenada[j + 1];
                        listaOrdenada[j + 1] = temp;
                    }
                }
            }

            return listaOrdenada;
        }


        /// <summary>
        /// Muestra la descripción de la TAREA seleccionada en el list view de TAREAS DE HOY
        /// </summary>
        private void MostrarDescripcionTareaSeleccionada()
        {
            textBoxDescripcion.Clear();

            if (listViewTareasHoy.SelectedItems.Count > 0)
            {
                // Obtiene el elemento seleccionado en el ListView.

                ListViewItem selectedTask = listViewTareasHoy.SelectedItems[0];

                // Verifica si el Tag del elemento seleccionado no es null y es una instancia de Tarea.
                if (selectedTask.Tag is not null && selectedTask.Tag is Tareas)
                {
                    // Obtén la tarea almacenada en el Tag del elemento ListView.
                    Tareas tareaSeleccionada = (Tareas)selectedTask.Tag;

                    // Accede a la descripción de la tarea.
                    textBoxDescripcion.Text = tareaSeleccionada.Descripcion.Replace("\\n", Environment.NewLine);
                }
            }
        }


        /// <summary>
        /// Llama a los metodos que muestran la descripcion de la Tarea seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewTareasHoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewListaSeleccionada.Items.Clear();

            MostrarDescripcionTareaSeleccionada();
        }
        private void ActualizarListViewListaSeleccionada(ListaDeTareas listaSeleccionada)

        {
            listViewListaSeleccionada.Items.Clear();

            foreach (var tarea in listaSeleccionada.Tareas)
            {

                var item = new ListViewItem(new[] { tarea.Nombre, tarea.HoraToString(), tarea.Repetir == Repeticion.Ninguna || tarea.Repetir == Repeticion.EnFechaEspecifica ? tarea.Fecha.ToString("dd/MM/yyyy") : tareasManager.ObtenerFechaFormateada(tarea) });

                //Aca se actualiza listview 
                listViewListaSeleccionada.Items.Add(item);

                item.Tag = tarea;
            }
        }

        private void ListViewTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDescripcion.Clear();
            listViewListaSeleccionada.Items.Clear();

            if (listViewTareas.SelectedItems.Count > 0)
            {
                // Obtiene el elemento seleccionado en el ListView.

                ListViewItem selectedList = listViewTareas.SelectedItems[0];

                // Verifica si el Tag del elemento seleccionado no es null y es una instancia de Tarea.
                if (selectedList.Tag is not null && selectedList.Tag is ListaDeTareas)
                {
                    // Obtén la tarea almacenada en el Tag del elemento ListView.
                    ListaDeTareas listaSeleccionada = (ListaDeTareas)selectedList.Tag;

                    ActualizarListViewListaSeleccionada(listaSeleccionada);
                }

            }
        }


        private void btnEstadoIncompleto_Click(object sender, EventArgs e)
        {
            if (listViewTareasHoy.SelectedItems.Count > 0)
            {
                // Obtiene el elemento seleccionado en el ListView.

                ListViewItem selectedTask = listViewTareasHoy.SelectedItems[0];

                // Verifica si el Tag del elemento seleccionado no es null y es una instancia de Tarea.
                if (selectedTask.Tag is not null && selectedTask.Tag is Tareas)
                {
                    // Obtén la tarea almacenada en el Tag del elemento ListView.
                    Tareas tareaSeleccionada = (Tareas)selectedTask.Tag;

                    tareaSeleccionada.Estado = EstadoTarea.Incompleto;

                    ActualizarlistViewTareasHoy();
                }
            }
        }

        private void btnEstadoCompleto_Click(object sender, EventArgs e)
        {
            if (listViewTareasHoy.SelectedItems.Count > 0)
            {
                // Obtiene el elemento seleccionado en el ListView.

                ListViewItem selectedTask = listViewTareasHoy.SelectedItems[0];

                // Verifica si el Tag del elemento seleccionado no es null y es una instancia de Tarea.
                if (selectedTask.Tag is not null && selectedTask.Tag is Tareas)
                {
                    // Obtén la tarea almacenada en el Tag del elemento ListView.
                    Tareas tareaSeleccionada = (Tareas)selectedTask.Tag;

                    tareasManager.MarcarCompleto(tareaSeleccionada);

                    ActualizarlistViewTareasHoy();
                }
            }
        }

        private void btnAgregarTareaLista_Click(object sender, EventArgs e)
        {

            formConsultaAgregar formConsulta = new formConsultaAgregar(listaDeTareasManager, tareasManager);
            //ESTA LINEA DE CODIGO, NO HACE QUE SE ACTUALICE MIS LISTVIEW AL TERMINAR MIS FORMULARIOS.
            if (formConsulta.ShowDialog() == DialogResult.OK)
            {

                ActualizarListViewTareas();
                ActualizarlistViewTareasHoy();
            }

        }
        private void btnModificarTareaLista_Click(object sender, EventArgs e)
        {
            if (listViewTareas.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado en el ListView.
                ListViewItem selectedItem = listViewTareas.SelectedItems[0];

                // Verificar si el Tag del elemento seleccionado no es null.
                if (selectedItem.Tag is not null)
                {
                    // Verificar si el elemento seleccionado es una tarea.
                    if (selectedItem.Tag is Tareas tareaSeleccionada)
                    {
                        // Modificar Tarea

                        ModificarTarea(tareaSeleccionada);

                    }

                    else if (selectedItem.Tag is ListaDeTareas listaSeleccionada)
                    {


                        ModificarLista(listaSeleccionada);

                    }
                }
            }
        }

        private void ModificarLista(ListaDeTareas listaSeleccionada)
        {
            // Crear el formulario para modificar tarea y pasar la tarea seleccionada
            formAgregarLista formModificarLista = new formAgregarLista(listaSeleccionada, listaDeTareasManager);

            // Mostrar el formulario y manejar el resultado
            if (formModificarLista.ShowDialog() == DialogResult.OK)
            {
                // Actualizar listas después de modificar la tarea.
                ActualizarListViewTareas();
                ActualizarlistViewTareasHoy();
            }
        }

        private void ModificarTarea(Tareas tarea)
        {
            // Crear el formulario para modificar tarea y pasar la tarea seleccionada
            frmListaDeTareasAgregarModificar formModificarTarea = new frmListaDeTareasAgregarModificar(tareasManager, tarea);

            // Mostrar el formulario y manejar el resultado
            if (formModificarTarea.ShowDialog() == DialogResult.OK)
            {
                // Actualizar listas después de modificar la tarea.
                ActualizarListViewTareas();
                ActualizarlistViewTareasHoy();
            }
        }

        private void ModificarTareaDeListaSeleccionada(Tareas tarea, ListaDeTareas listaDeTareas)
        {
            // Crear el formulario para modificar tarea y pasar la tarea seleccionada
            frmListaDeTareasAgregarModificar formModificarTarea = new frmListaDeTareasAgregarModificar(tarea, listaDeTareasManager, listaDeTareas);

            // Mostrar el formulario y manejar el resultado
            if (formModificarTarea.ShowDialog() == DialogResult.OK)
            {
                // Actualizar listas después de modificar la tarea.
                ActualizarListViewTareas();
                ActualizarlistViewTareasHoy();
            }
        }

        private void btnEliminarTareaLista_Click(object sender, EventArgs e)
        {
            if (listViewTareas.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado en el ListView.
                ListViewItem selectedTask = listViewTareas.SelectedItems[0];

                // Verificar si el Tag del elemento seleccionado no es null y es una instancia de Tareas.
                if (selectedTask.Tag is not null && selectedTask.Tag is Tareas)
                {
                    // Obtener la tarea almacenada en el Tag del elemento ListView.
                    Tareas tareaSeleccionada = (Tareas)selectedTask.Tag;

                    // Utilizar tareasManager.EliminarTarea para eliminar la tarea.
                    tareasManager.EliminarTarea(tareaSeleccionada);

                    // Actualizar el ListView después de eliminar la tarea.
                    ActualizarlistViewTareasHoy();
                }
                else if (selectedTask.Tag is not null && selectedTask.Tag is ListaDeTareas)
                {
                    // Obtener la tarea almacenada en el Tag del elemento ListView.
                    ListaDeTareas listaSeleccionada = (ListaDeTareas)selectedTask.Tag;

                    // Utilizar tareasManager.EliminarTarea para eliminar la tarea.
                    listaDeTareasManager.EliminarListaDeTareas(listaSeleccionada);

                    // Actualizar el ListView después de eliminar la tarea.
                    ActualizarlistViewTareasHoy();

                    listViewListaSeleccionada.Items.Clear();

                }
            }
        }

        private void btnAgregarTareaListaSelect_Click(object sender, EventArgs e)
        {
            // Verifica si hay una lista seleccionada en el ListView
            if (listViewTareas.SelectedItems.Count > 0 && listViewTareas.SelectedItems[0].Tag is ListaDeTareas listaSeleccionada)
            {
                // Crea una instancia del formulario para agregar/modificar tarea
                frmListaDeTareasAgregarModificar formAgregarModificarTarea = new frmListaDeTareasAgregarModificar(tareasManager, listaSeleccionada);

                // Muestra el formulario
                if (formAgregarModificarTarea.ShowDialog() == DialogResult.OK)
                {
                    // Actualizar listas después de agregar/modificar la tarea.
                    ActualizarListViewTareas();
                    ActualizarlistViewTareasHoy();
                    ActualizarListViewListaSeleccionada(listaSeleccionada);
                }
            }
            else
            {
                // No hay lista seleccionada, muestra un mensaje o maneja según tus necesidades.
                MessageBox.Show("Seleccione una lista antes de agregar una tarea.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarTareaListaSelect_Click(object sender, EventArgs e)
        {
            if (listViewTareas.SelectedItems.Count > 0)
            {
                // Obtiene el elemento seleccionado en el ListView.

                ListViewItem selectedList = listViewTareas.SelectedItems[0];

                // Verifica si el Tag del elemento seleccionado no es null y es una instancia de Tarea.
                if (selectedList.Tag is not null && selectedList.Tag is ListaDeTareas)
                {
                    // Obtén la tarea almacenada en el Tag del elemento ListView.
                    ListaDeTareas listaSeleccionada = (ListaDeTareas)selectedList.Tag;

                    if (listViewListaSeleccionada.SelectedItems.Count > 0)
                    {
                        // Obtener el elemento seleccionado en el ListView.
                        ListViewItem selectedItem = listViewListaSeleccionada.SelectedItems[0];

                        // Verificar si el Tag del elemento seleccionado no es null.
                        if (selectedItem.Tag is not null)
                        {
                            // Verificar si el elemento seleccionado es una tarea.
                            if (selectedItem.Tag is Tareas tareaSeleccionada)
                            {
                                ModificarTareaDeListaSeleccionada(tareaSeleccionada, listaSeleccionada);

                                ActualizarListViewTareas();
                                ActualizarlistViewTareasHoy();
                                ActualizarListViewListaSeleccionada(listaSeleccionada);
                            }
                        }
                    }
                }
            }
        }

        private void btnEliminarTareaListaSelect_Click(object sender, EventArgs e)
        {


            if (listViewTareas.SelectedItems.Count > 0)
            {
                // Obtiene el elemento seleccionado en el ListView.

                ListViewItem selectedList = listViewTareas.SelectedItems[0];

                // Verifica si el Tag del elemento seleccionado no es null y es una instancia de Tarea.
                if (selectedList.Tag is not null && selectedList.Tag is ListaDeTareas)
                {
                    // Obtén la tarea almacenada en el Tag del elemento ListView.
                    ListaDeTareas listaSeleccionada = (ListaDeTareas)selectedList.Tag;

                    if (listViewListaSeleccionada.SelectedItems.Count > 0)
                    {
                        // Obtener el elemento seleccionado en el ListView.
                        ListViewItem selectedItem = listViewListaSeleccionada.SelectedItems[0];

                        // Verificar si el Tag del elemento seleccionado no es null.
                        if (selectedItem.Tag is not null)
                        {
                            // Verificar si el elemento seleccionado es una tarea.
                            if (selectedItem.Tag is Tareas tareaSeleccionada)
                            {
                                listaDeTareasManager.EliminarTareaDeLista(listaSeleccionada, tareaSeleccionada);
                                ActualizarListViewTareas();
                                ActualizarlistViewTareasHoy();
                                ActualizarListViewListaSeleccionada(listaSeleccionada);
                            }
                        }
                    }
                }
            }
        }

        // ... Otros métodos y eventos ...

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Serializar ambas listas a JSON y guardar en un solo archivo
                string jsonString = JsonSerializer.Serialize(new { Tareas = tareasManager.Tareas, ListasDeTareas = listaDeTareasManager.ListasDeTareas });
                File.WriteAllText("datos.json", jsonString);

                MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("datos.json"))
                {
                    // Deserializar ambas listas desde JSON
                    string jsonString = File.ReadAllText("datos.json");
                    var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

                    // Obtener las listas y convertirlas al tipo correcto
                    List<Tareas> tareas = JsonSerializer.Deserialize<List<Tareas>>(data["Tareas"].GetRawText());

                    List<ListaDeTareas> listasDeTareas = JsonSerializer.Deserialize<List<ListaDeTareas>>(data["ListasDeTareas"].GetRawText());

                    // Actualizar las listas existentes con las deserializadas
                    tareasManager.Tareas.Clear();
                    tareasManager.Tareas.AddRange(tareas);

                    listaDeTareasManager.ListasDeTareas.Clear();
                    listaDeTareasManager.ListasDeTareas.AddRange(listasDeTareas);

                    MessageBox.Show("Datos importados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El archivo de datos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
