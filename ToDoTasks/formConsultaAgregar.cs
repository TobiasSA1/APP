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
    public partial class formConsultaAgregar : Form
    {
        private ListaDeTareasManager listaDeTareasManager;
        private TareasManager tareasManager;

        public formConsultaAgregar()
        {
            InitializeComponent();
        }

        public formConsultaAgregar(ListaDeTareasManager listaDeTareasManager, TareasManager tareasManager)
        {
            InitializeComponent();
            this.listaDeTareasManager = listaDeTareasManager;
            this.tareasManager = tareasManager;
        }

        private void formConsultaAgregar_Load(object sender, EventArgs e)
        {

        }

        private void AgregarLista()
        {
            formAgregarLista formAgregarLista = new formAgregarLista(listaDeTareasManager);

            if (formAgregarLista.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AgregarTarea()
        {
            frmListaDeTareasAgregarModificar formAgregarTarea = new frmListaDeTareasAgregarModificar(tareasManager);
            if (formAgregarTarea.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnTarea_Click(object sender, EventArgs e)
        {
            AgregarTarea();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            AgregarLista();
        }

        private void formConsultaAgregar_Load_1(object sender, EventArgs e)
        {

        }

    }
}
