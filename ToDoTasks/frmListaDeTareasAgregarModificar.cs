using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace ToDoTasks
{
    public partial class frmListaDeTareasAgregarModificar : Form
    {

        private TareasManager tareasManager;

        private ListaDeTareasManager listadeTareasManager;

        private Tareas tareaSeleccionada;

        private ListaDeTareas listaSeleccionada;

        public frmListaDeTareasAgregarModificar(TareasManager tareasManager)
        {
            InitializeComponent();
            this.tareasManager = tareasManager;


        }


        public frmListaDeTareasAgregarModificar(TareasManager tareasManager, Tareas tareaSeleccionada)
            : this(tareasManager)
        {
            this.tareaSeleccionada = tareaSeleccionada;

            // Verificar si la tarea seleccionada no es nula
            if (this.tareaSeleccionada is not null)
            {
                // Configurar los campos con los datos de la tarea seleccionada
                ConfigurarCamposTareaSeleccionada();
            }
        }

        public frmListaDeTareasAgregarModificar(TareasManager tareasManager, ListaDeTareas listaSeleccionada)
        : this(tareasManager)
        {
            this.listaSeleccionada = listaSeleccionada;

            if (this.listaSeleccionada is not null)
            {
                ConfigurarControlesDesdeListaSeleccionada();
            }
        }

        public frmListaDeTareasAgregarModificar(Tareas tarea, ListaDeTareasManager listaDeTareasManager, ListaDeTareas listaSeleccionada)
        {
            InitializeComponent();
            this.listaSeleccionada = listaSeleccionada;
            this.listadeTareasManager = listaDeTareasManager;
            this.tareaSeleccionada = tarea;

            // Verificar si la lista seleccionada no es nula

            //ESTE CONSTRUCTOR ES PARA MODIFICAR UNA TAREA DE LA LISTA SELECCIONADA.

            if (this.listaSeleccionada is not null && this.listadeTareasManager is not null && tareaSeleccionada is not null)
            {
                // Configurar controles desde la lista seleccionada
                ConfigurarControlesDesdeListaSeleccionada();
                ConfigurarCamposTareaSeleccionada();
            }
        }

        private void ConfigurarControlesDesdeListaSeleccionada()
        {
            if (listaSeleccionada is not null)
            {
                // Marcar el RadioButton correspondiente al Tipo
                if (listaSeleccionada.Tipo == TipoTarea.Rutinaria)
                {
                    RadioRutinaria.Checked = true;
                }
                else if (listaSeleccionada.Tipo == TipoTarea.Irregular)
                {
                    RadioIrregular.Checked = true;
                }

                // Marcar y bloquear los controles según el TipoRepeticion
                if (listaSeleccionada.Repetir == Repeticion.Dias)
                {
                    checkDias.Checked = true;
                    BloquearControlesDias();
                }
                else if (listaSeleccionada.Repetir == Repeticion.EnFechaEspecifica)
                {
                    checkFechaEspecifica.Checked = true;
                    BloquearControlesFechaEspecifica();
                }
                else if (listaSeleccionada.Repetir == Repeticion.Diaria)
                {
                    checkDiaria.Checked = true;
                    BloquearControlesDiaria();
                }

                RadioRutinaria.Enabled = false;
                RadioIrregular.Enabled = false;
                checkFechaEspecifica.Enabled = false;
                checkDiaria.Enabled = false;
                checkDias.Enabled = false;
                //checkedListBoxDias.Enabled = false;
            }
        }


        // Método para configurar los campos con los datos de la tarea seleccionada
        private void ConfigurarCamposTareaSeleccionada()
        {
            richTextBoxNombreTareas.Text = tareaSeleccionada.Nombre;
            richTextBoxDescripcion.Text = tareaSeleccionada.Descripcion;
            maskedTextBoxHora.Text = tareaSeleccionada.Hora.ToString("hh\\:mm");

            ConfigurarCheckedListBoxDias();

            // Actualizar la interfaz gráfica según la tarea seleccionada
            ActualizarInterfazSegunTarea();
        }

        // Método para actualizar la interfaz gráfica según la tarea seleccionada
        private void ActualizarInterfazSegunTarea()
        {
            // Lógica para actualizar la interfaz gráfica según el tipo de tarea y repetición
            // ...

            // Ejemplo: Actualizar los controles de acuerdo al tipo de tarea seleccionada
            if (tareaSeleccionada is TareaRutinaria tareaRutinaria)
            {
                RadioRutinaria.Checked = true;

                if (tareaRutinaria.Repetir == Repeticion.Dias)
                {
                    checkDias.Checked = true;
                    // Otros controles relacionados con la repetición por días
                    // ...
                }
                else if (tareaRutinaria.Repetir == Repeticion.EnFechaEspecifica)
                {
                    checkFechaEspecifica.Checked = true;
                    // Otros controles relacionados con la repetición en fecha específica
                    // ...
                }
                else if (tareaRutinaria.Repetir == Repeticion.Diaria)
                {
                    checkDiaria.Checked = true;
                    // Otros controles relacionados con la repetición diaria
                    // ...
                }
            }
            else if (tareaSeleccionada is TareaIrregular)
            {
                RadioIrregular.Checked = true;
                // Otros controles relacionados con tareas irregulares
                // ...
            }
        }

        private void Inicializar()
        {
            checkedListBoxDias.Items.Add("Lunes");
            checkedListBoxDias.Items.Add("Martes");
            checkedListBoxDias.Items.Add("Miercoles");
            checkedListBoxDias.Items.Add("Jueves");
            checkedListBoxDias.Items.Add("Viernes");
            checkedListBoxDias.Items.Add("Sabado");
            checkedListBoxDias.Items.Add("Domingo");

            dateTimePicker.MinDate = DateTime.Today;

            maskedTextBoxHora.Mask = "99:99";
            //maskedTextBoxHora.PromptChar = '0';
            maskedTextBoxHora.MaxLength = 5;

            RadioIrregular.Checked = true;
        }


        private void maskedTextBoxHora_GotFocus(object sender, EventArgs e)
        {
            // Mover el cursor al principio del texto
            maskedTextBoxHora.Select(0, 0);
        }
        private void frmListaDeTareasAgregarModificar_Load(object sender, EventArgs e)
        {
            Inicializar();
            maskedTextBoxHora.GotFocus += maskedTextBoxHora_GotFocus;

        }
        private void RadioIrregular_CheckedChanged_1(object sender, EventArgs e)
        {
            BloquearControlesIrregular();

        }
        private void RadioRutinaria_CheckedChanged(object sender, EventArgs e)
        {

            DesbloquearControles();

        }

        private void CheckDiaria_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDiaria.Checked)
            {
                BloquearControlesDiaria();
            }
            else
            {
                DesbloquearControles();
            }
        }

        private void CheckFechaEspecifica_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFechaEspecifica.Checked)
            {
                BloquearControlesFechaEspecifica();
            }
            else
            {
                DesbloquearControles();
            }
        }

        private void CheckDias_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDias.Checked)
            {
                BloquearControlesDias();
            }
            else
            {
                DesbloquearControles();

                foreach (int index in checkedListBoxDias.CheckedIndices)
                {
                    checkedListBoxDias.SetItemChecked(index, false);
                }
            }
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Lógica de bloqueo/desbloqueo y agregar tarea

        private void BloquearControlesIrregular()
        {
            // Bloquear controles para tipo irregular
            checkFechaEspecifica.Checked = false;
            checkDiaria.Checked = false;
            checkDias.Checked = false;

            checkFechaEspecifica.Enabled = false;
            checkDiaria.Enabled = false;
            checkDias.Enabled = false;
            checkedListBoxDias.Enabled = false;

        }

        private void DesbloquearControles()
        {
            // Desbloquear controles para tipo rutinario
            dateTimePicker.Enabled = true;
            checkFechaEspecifica.Enabled = true;
            checkDiaria.Enabled = true;
            checkDias.Enabled = true;
            checkedListBoxDias.Enabled = true;
        }

        private void BloquearControlesDiaria()
        {
            // Bloquear controles para tarea diaria
            checkFechaEspecifica.Enabled = false;
            dateTimePicker.Enabled = false;
            checkDias.Enabled = false;
            checkedListBoxDias.Enabled = false;

            foreach (int index in checkedListBoxDias.CheckedIndices)
            {
                checkedListBoxDias.SetItemChecked(index, false);
            }
        }

        private void BloquearControlesFechaEspecifica()
        {
            // Bloquear controles para tarea en fecha específica
            checkDiaria.Enabled = false;
            checkDias.Enabled = false;
            dateTimePicker.Enabled = true;
            checkedListBoxDias.Enabled = false;

            foreach (int index in checkedListBoxDias.CheckedIndices)
            {
                checkedListBoxDias.SetItemChecked(index, false);
            }
        }

        private void BloquearControlesDias()
        {
            // Bloquear controles para tarea por días de la semana
            checkDiaria.Enabled = false;
            checkFechaEspecifica.Enabled = false;
            dateTimePicker.Enabled = false;
        }
        private void AgregarTarea()
        {
            try
            {
                string nombre = ObtenerNombre();
                string descripcion = ObtenerDescripcion();
                TimeSpan hora = ObtenerHora();
                EstadoTarea estado = EstadoTarea.Pendiente;
                Repeticion repeticion;
                DateTime fechaSeleccionada;
                HashSet<DayOfWeek> dias = new HashSet<DayOfWeek>();

                if (RadioRutinaria.Checked)
                {
                    if (checkDias.Checked)
                    {
                        repeticion = Repeticion.Dias;
                        dias = ObtenerDiasSeleccionados();

                        var nuevaTarea = new TareaRutinaria(nombre, hora, repeticion, descripcion, estado, dias, DateTime.Today);


                        if (listaSeleccionada is not null)
                        {
                            listaSeleccionada.AgregarTarea(nuevaTarea);
                        }
                        else
                        {
                            tareasManager.AgregarTarea(nuevaTarea);
                        }
                    }
                    else if (checkFechaEspecifica.Checked)
                    {
                        repeticion = Repeticion.EnFechaEspecifica;
                        fechaSeleccionada = ObtenerFechaEspecifica();

                        var nuevaTarea = new TareaRutinaria(nombre, hora, repeticion, descripcion, estado, dias, fechaSeleccionada);

                        if (listaSeleccionada is not null)
                        {
                            listaSeleccionada.AgregarTarea(nuevaTarea);
                        }
                        else
                        {
                            tareasManager.AgregarTarea(nuevaTarea);
                        }
                    }
                    else if (checkDiaria.Checked)
                    {
                        repeticion = Repeticion.Diaria;
                        dias = ObtenerDiasDiarios();

                        var nuevaTarea = new TareaRutinaria(nombre, hora, repeticion, descripcion, estado, dias, DateTime.Today);

                        if (listaSeleccionada is not null)
                        {
                            listaSeleccionada.AgregarTarea(nuevaTarea);
                        }
                        else
                        {
                            tareasManager.AgregarTarea(nuevaTarea);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Por favor, seleccione una repetición para la tarea rutinaria.");
                    }
                }
                else if (RadioIrregular.Checked)
                {
                    fechaSeleccionada = ObtenerFechaIrregular();

                    var nuevaTarea = new TareaIrregular(nombre, hora, descripcion, estado, fechaSeleccionada);


                    if (listaSeleccionada is not null)
                    {
                        listaSeleccionada.AgregarTarea(nuevaTarea);
                    }

                    else
                    {
                        tareasManager.AgregarTarea(nuevaTarea);
                    }
                }

                MessageBox.Show("Tarea agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Manejar la excepción mostrando un mensaje de error específico
                MessageBox.Show($"Error al agregar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones mostrando un mensaje de error genérico
                MessageBox.Show($"Error al agregar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerNombre()
        {
            string nombre = richTextBoxNombreTareas.Text;
            ValidarNombre(nombre);
            return nombre;
        }

        private static void ValidarNombre(string nombre)
        {
            if (nombre.Length > 40)
            {
                throw new ArgumentException("El nombre no puede tener más de 40 caracteres.", nameof(nombre));
            }
        }

        private string ObtenerDescripcion()
        {
            return richTextBoxDescripcion.Text;
        }

        private TimeSpan ObtenerHora()
        {
            string tiempo = maskedTextBoxHora.Text;

            if (!TimeSpan.TryParse(tiempo, out TimeSpan hora))
            {
                throw new ArgumentException("El formato de la hora no es válido. Debe ser en formato HH:mm.", nameof(tiempo));
            }
            return hora;
        }

        private HashSet<DayOfWeek> ObtenerDiasSeleccionados()
        {
            Dictionary<string, DayOfWeek> mapeoDias = new Dictionary<string, DayOfWeek>
                {
                    { "Lunes", DayOfWeek.Monday },
                    { "Martes", DayOfWeek.Tuesday },
                    { "Miercoles", DayOfWeek.Wednesday },
                    { "Jueves", DayOfWeek.Thursday },
                    { "Viernes", DayOfWeek.Friday },
                    { "Sabado", DayOfWeek.Saturday },
                    { "Domingo", DayOfWeek.Sunday }
                };

            HashSet<DayOfWeek> dias = new HashSet<DayOfWeek>();

            // Validar que haya al menos un día seleccionado
            if (checkedListBoxDias.CheckedItems.Count == 0)
            {
                throw new ArgumentException("Seleccione al menos un día de la semana.", nameof(checkedListBoxDias));
            }

            foreach (string diaTexto in checkedListBoxDias.CheckedItems)
            {
                // Verifica si el nombre del día está en el mapeo
                if (mapeoDias.TryGetValue(diaTexto, out DayOfWeek dia))
                {
                    // Agrega el día al conjunto
                    dias.Add(dia);
                }
            }

            return dias;
        }

        private DateTime ObtenerFechaEspecifica()
        {
            return dateTimePicker.Value;
        }

        private static HashSet<DayOfWeek> ObtenerDiasDiarios()
        {
            HashSet<DayOfWeek> diario = new HashSet<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
            return diario;
        }

        private DateTime ObtenerFechaIrregular()
        {
            return dateTimePicker.Value;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tareaSeleccionada != null)
                {
                    ModificarTarea();
                }
                else
                {
                    AgregarTarea();
                }

                // Solo cerrar el formulario si la tarea se agrega o modifica exitosamente
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error, pero no cerrar el formulario
                MessageBox.Show($"Error al {(tareaSeleccionada != null ? "modificar" : "agregar")} la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarCheckedListBoxDias()
        {
            // Limpiar selecciones anteriores
            for (int i = 0; i < checkedListBoxDias.Items.Count; i++)
            {
                checkedListBoxDias.SetItemChecked(i, false);
            }

            // Configurar selecciones según la tarea seleccionada
            if (tareaSeleccionada is TareaRutinaria tareaRutinaria)
            {
                foreach (var dia in tareaRutinaria.diasSemanales)
                {
                    int index = ObtenerIndiceDia(dia);
                    // Verificar que el índice sea válido antes de intentar establecer el estado de verificación
                    if (index >= 0 && index < checkedListBoxDias.Items.Count)
                    {
                        checkedListBoxDias.SetItemChecked(index, true);
                    }
                }
            }
        }

        private static int ObtenerIndiceDia(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Monday:
                    return 0;
                case DayOfWeek.Tuesday:
                    return 1;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 3;
                case DayOfWeek.Friday:
                    return 4;
                case DayOfWeek.Saturday:
                    return 5;
                case DayOfWeek.Sunday:
                    return 6;
                default:
                    return -1; // Día no válido
            }
        }

        private void ModificarTarea()
        {
            try
            {
                // Obtener los datos actuales de la tarea seleccionada
                string nombre = ObtenerNombre();
                string descripcion = ObtenerDescripcion();
                TimeSpan hora = ObtenerHora();
                EstadoTarea estado = tareaSeleccionada.Estado; // Mantener el estado actual
                Repeticion repeticion;
                DateTime fechaSeleccionada;
                HashSet<DayOfWeek> dias = new HashSet<DayOfWeek>();

                if (RadioRutinaria.Checked)
                {
                    if (checkDias.Checked)
                    {
                        repeticion = Repeticion.Dias;
                        dias = ObtenerDiasSeleccionados();
                        Tareas nuevaTarea = new TareaRutinaria(nombre, hora, repeticion, descripcion, estado, dias, DateTime.Today);

                        if (tareasManager is not null)
                        {
                            tareasManager.EliminarTarea(tareaSeleccionada);
                            tareasManager.AgregarTarea(nuevaTarea);
                        }
                        else
                        {
                            listadeTareasManager.EliminarTareaDeLista(listaSeleccionada, tareaSeleccionada);
                            listaSeleccionada.AgregarTarea(nuevaTarea);
                        }
                    }
                    else if (checkFechaEspecifica.Checked)
                    {
                        repeticion = Repeticion.EnFechaEspecifica;
                        fechaSeleccionada = ObtenerFechaEspecifica();
                        Tareas nuevaTarea = new TareaRutinaria(nombre, hora, repeticion, descripcion, estado, dias, fechaSeleccionada);

                        if (tareasManager is not null)
                        {
                            tareasManager.EliminarTarea(tareaSeleccionada);
                            tareasManager.AgregarTarea(nuevaTarea);
                        }
                        else
                        {
                            listadeTareasManager.EliminarTareaDeLista(listaSeleccionada, tareaSeleccionada);
                            listaSeleccionada.AgregarTarea(nuevaTarea);
                        }

                    }
                    else if (checkDiaria.Checked)
                    {
                        repeticion = Repeticion.Diaria;
                        dias = ObtenerDiasDiarios();
                        Tareas nuevaTarea = new TareaRutinaria(nombre, hora, repeticion, descripcion, estado, dias, DateTime.Today);

                        if (tareasManager is not null)
                        {
                            tareasManager.EliminarTarea(tareaSeleccionada);
                            tareasManager.AgregarTarea(nuevaTarea);
                        }
                        else
                        {
                            listadeTareasManager.EliminarTareaDeLista(listaSeleccionada, tareaSeleccionada);
                            listaSeleccionada.AgregarTarea(nuevaTarea);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Por favor, seleccione una repetición para la tarea rutinaria.");
                    }
                }
                else if (RadioIrregular.Checked)
                {
                    repeticion = Repeticion.Ninguna;

                    fechaSeleccionada = ObtenerFechaIrregular();
                    Tareas nuevaTarea = new TareaIrregular(nombre, hora, descripcion, estado, fechaSeleccionada);

                    if (tareasManager is not null)
                    {
                        tareasManager.EliminarTarea(tareaSeleccionada);
                        tareasManager.AgregarTarea(nuevaTarea);
                    }
                    else
                    {
                        listadeTareasManager.EliminarTareaDeLista(listaSeleccionada, tareaSeleccionada);
                        listaSeleccionada.AgregarTarea(nuevaTarea);
                    }
                }
                else
                {
                    throw new ArgumentException("Por favor, seleccione un tipo de tarea.");
                }

                MessageBox.Show("Tarea modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error, pero no cerrar el formulario
                MessageBox.Show($"Error al modificar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
