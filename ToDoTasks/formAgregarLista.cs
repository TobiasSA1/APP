using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoTasks
{
    public partial class formAgregarLista : Form
    {
        private ListaDeTareasManager listaDeTareasManager;

        private ListaDeTareas listaSeleccionada;
        public formAgregarLista(ListaDeTareasManager listaDeTareasManager)
        {
            InitializeComponent();

            this.listaDeTareasManager = listaDeTareasManager;

        }

        public formAgregarLista(ListaDeTareas listaSeleccionada, ListaDeTareasManager listaDeTareasManager) : this(listaDeTareasManager)
        {

            this.listaSeleccionada = listaSeleccionada;

            if (this.listaSeleccionada is not null)
            {


                ConfigurarCamposListaSeleccionada();
                BloquearControlesParaModificacion();
            }
        }

        private void ConfigurarCamposListaSeleccionada()
        {
            richTextBoxNombreLista.Text = listaSeleccionada.Nombre;

            ActualizarInterfazSegunLista();
        }

        private void BloquearControlesParaModificacion()
        {
            // Bloquear todos los controles de configuración, excepto el nombre
            radioRutinaria.Enabled = false;
            radioIrregular.Enabled = false;
            checkFechaEspecifica.Enabled = false;
            checkDiaria.Enabled = false;
            checkDias.Enabled = false;
        }

        private void ActualizarInterfazSegunLista()
        {
            // Lógica para actualizar la interfaz gráfica según el tipo de tarea y repetición
            // ...

            // Ejemplo: Actualizar los controles de acuerdo al tipo de tarea seleccionada

            if (listaSeleccionada.Tipo == TipoTarea.Rutinaria)
            {
                radioRutinaria.Checked = true;

                if (listaSeleccionada.Repetir == Repeticion.Dias)
                {
                    checkDias.Checked = true;
                    // Otros controles relacionados con la repetición por días
                    // ...
                }
                else if (listaSeleccionada.Repetir == Repeticion.EnFechaEspecifica)
                {
                    checkFechaEspecifica.Checked = true;
                    // Otros controles relacionados con la repetición en fecha específica
                    // ...
                }
                else if (listaSeleccionada.Repetir == Repeticion.Diaria)
                {
                    checkDiaria.Checked = true;
                    // Otros controles relacionados con la repetición diaria
                    // ...
                }
            }
            else if (listaSeleccionada.Tipo == TipoTarea.Irregular)
            {
                radioIrregular.Checked = true;
                // Otros controles relacionados con tareas irregulares
                // ...
            }
        }


        private void formAgregarLista_Load(object sender, EventArgs e)
        {
            // Inicializar los controles
            //BloquearControlesIrregular();
        }

        private void BloquearControlesIrregular()
        {
            // Bloquear controles para tipo irregular
            checkFechaEspecifica.Enabled = false;
            checkDiaria.Enabled = false;
            checkDias.Enabled = false;
        }

        private void DesbloquearControlesRutinaria()
        {
            // Desbloquear controles para tipo rutinario
            checkFechaEspecifica.Enabled = true;
            checkDiaria.Enabled = true;
            checkDias.Enabled = true;
        }

        private void RadioIrregular_CheckedChanged(object sender, EventArgs e)
        {
            BloquearControlesIrregular();
        }

        private void RadioRutinaria_CheckedChanged(object sender, EventArgs e)
        {
            DesbloquearControlesRutinaria();
        }

        private void CheckDiaria_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDiaria.Checked)
            {
                BloquearControlesDiaria();
            }
            else
            {
                DesbloquearControlesRutinaria();
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
                DesbloquearControlesRutinaria();
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
                DesbloquearControlesRutinaria();
            }
        }

        private void BloquearControlesDiaria()
        {
            // Bloquear controles para tarea diaria
            checkFechaEspecifica.Enabled = false;
            checkDias.Enabled = false;
        }

        private void BloquearControlesFechaEspecifica()
        {
            // Bloquear controles para tarea en fecha específica
            checkDiaria.Enabled = false;
            checkDias.Enabled = false;
        }

        private void BloquearControlesDias()
        {
            // Bloquear controles para tarea por días de la semana
            checkDiaria.Enabled = false;
            checkFechaEspecifica.Enabled = false;
        }



        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarLista();

                // Solo cerrar el formulario si la tarea se agrega exitosamente
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error, pero no cerrar el formulario
                MessageBox.Show($"Error al agregar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ObtenerNombreLista()
        {
            string nombre = richTextBoxNombreLista.Text;
            ValidarNombreLista(nombre);
            return nombre;
        }

        private static void ValidarNombreLista(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre de la lista no puede estar vacío.", nameof(nombre));
            }
        }

        private TipoTarea ObtenerTipoTarea()
        {
            return radioRutinaria.Checked ? TipoTarea.Rutinaria : TipoTarea.Irregular;
        }

        private Repeticion ObtenerRepeticion()
        {
            if (checkFechaEspecifica.Checked)
            {
                return Repeticion.EnFechaEspecifica;
            }
            else if (checkDiaria.Checked)
            {
                return Repeticion.Diaria;
            }
            else if (checkDias.Checked)
            {
                return Repeticion.Dias;
            }
            else
            {
                // Puedes ajustar esto según tus necesidades, por ejemplo, lanzar una excepción
                return Repeticion.Ninguna;
            }
        }

        private void AgregarLista()
        {
            try
            {
                string nombre = ObtenerNombreLista();
                TipoTarea tipo = ObtenerTipoTarea();
                Repeticion repeticion = ObtenerRepeticion();

                var nuevaLista = new ListaDeTareas(nombre, tipo, repeticion);

                if (listaSeleccionada is not null)
                {
                    listaDeTareasManager.ModificarListaDeTareas(listaSeleccionada, nombre);
                }
                else
                {
                    listaDeTareasManager.AgregarListaDeTareas(nuevaLista);
                }

                MessageBox.Show("Lista de tareas agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                // Manejar la excepción mostrando un mensaje de error específico
                MessageBox.Show($"Error al agregar la lista de tareas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones mostrando un mensaje de error genérico
                MessageBox.Show($"Error al agregar la lista de tareas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
