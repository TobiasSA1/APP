namespace ToDoTasks
{
    partial class formPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            label2 = new Label();
            btnAgregarTareaLista = new Button();
            btnEliminarTareaLista = new Button();
            btnModificarTareaLista = new Button();
            label3 = new Label();
            label4 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            labelHoraActual = new Label();
            btnEstadoCompleto = new Button();
            textBoxDescripcion = new TextBox();
            listViewTareasHoy = new ListView();
            listViewTareas = new ListView();
            listViewListaSeleccionada = new ListView();
            label5 = new Label();
            btnModificarTareaListaSelect = new Button();
            btnEliminarTareaListaSelect = new Button();
            btnAgregarTareaListaSelect = new Button();
            calendario = new MonthCalendar();
            label1 = new Label();
            btnExportar = new Button();
            btnImportar = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(485, 15);
            label2.Name = "label2";
            label2.Size = new Size(178, 28);
            label2.TabIndex = 2;
            label2.Text = "LISTA de TAREAS:";
            // 
            // btnAgregarTareaLista
            // 
            btnAgregarTareaLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarTareaLista.Location = new Point(1050, 56);
            btnAgregarTareaLista.Name = "btnAgregarTareaLista";
            btnAgregarTareaLista.Size = new Size(126, 38);
            btnAgregarTareaLista.TabIndex = 1;
            btnAgregarTareaLista.Text = "AGREGAR TAREA/LISTA";
            btnAgregarTareaLista.UseVisualStyleBackColor = true;
            btnAgregarTareaLista.Click += btnAgregarTareaLista_Click;
            // 
            // btnEliminarTareaLista
            // 
            btnEliminarTareaLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminarTareaLista.Location = new Point(1050, 180);
            btnEliminarTareaLista.Name = "btnEliminarTareaLista";
            btnEliminarTareaLista.Size = new Size(126, 38);
            btnEliminarTareaLista.TabIndex = 3;
            btnEliminarTareaLista.Text = "ELIMINAR TAREA/LISTA";
            btnEliminarTareaLista.UseVisualStyleBackColor = true;
            btnEliminarTareaLista.Click += btnEliminarTareaLista_Click;
            // 
            // btnModificarTareaLista
            // 
            btnModificarTareaLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificarTareaLista.Location = new Point(1050, 117);
            btnModificarTareaLista.Name = "btnModificarTareaLista";
            btnModificarTareaLista.Size = new Size(126, 38);
            btnModificarTareaLista.TabIndex = 2;
            btnModificarTareaLista.Text = "MODIFICAR TAREA/LISTA";
            btnModificarTareaLista.UseVisualStyleBackColor = true;
            btnModificarTareaLista.Click += btnModificarTareaLista_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(28, 236);
            label3.Name = "label3";
            label3.Size = new Size(149, 28);
            label3.TabIndex = 9;
            label3.Text = "Tareas de Hoy:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(466, 582);
            label4.Name = "label4";
            label4.Size = new Size(207, 28);
            label4.TabIndex = 11;
            label4.Text = "Notas e Información:";
            // 
            // labelHoraActual
            // 
            labelHoraActual.AutoSize = true;
            labelHoraActual.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelHoraActual.Location = new Point(37, 13);
            labelHoraActual.Name = "labelHoraActual";
            labelHoraActual.Size = new Size(0, 28);
            labelHoraActual.TabIndex = 13;
            // 
            // btnEstadoCompleto
            // 
            btnEstadoCompleto.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEstadoCompleto.Location = new Point(193, 547);
            btnEstadoCompleto.Name = "btnEstadoCompleto";
            btnEstadoCompleto.Size = new Size(163, 38);
            btnEstadoCompleto.TabIndex = 6;
            btnEstadoCompleto.Text = "COMPLETA/PENDIENTE";
            btnEstadoCompleto.UseVisualStyleBackColor = true;
            btnEstadoCompleto.Click += btnEstadoCompleto_Click;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxDescripcion.Location = new Point(258, 622);
            textBoxDescripcion.Multiline = true;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(698, 162);
            textBoxDescripcion.TabIndex = 11;
            // 
            // listViewTareasHoy
            // 
            listViewTareasHoy.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            listViewTareasHoy.Location = new Point(28, 269);
            listViewTareasHoy.Name = "listViewTareasHoy";
            listViewTareasHoy.Size = new Size(655, 271);
            listViewTareasHoy.TabIndex = 4;
            listViewTareasHoy.UseCompatibleStateImageBehavior = false;
            listViewTareasHoy.SelectedIndexChanged += ListViewTareasHoy_SelectedIndexChanged;
            // 
            // listViewTareas
            // 
            listViewTareas.Location = new Point(22, 56);
            listViewTareas.Name = "listViewTareas";
            listViewTareas.Size = new Size(1015, 162);
            listViewTareas.TabIndex = 0;
            listViewTareas.UseCompatibleStateImageBehavior = false;
            listViewTareas.SelectedIndexChanged += ListViewTareas_SelectedIndexChanged;
            // 
            // listViewListaSeleccionada
            // 
            listViewListaSeleccionada.Location = new Point(725, 269);
            listViewListaSeleccionada.Name = "listViewListaSeleccionada";
            listViewListaSeleccionada.Size = new Size(451, 271);
            listViewListaSeleccionada.TabIndex = 5;
            listViewListaSeleccionada.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Emoji", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(725, 236);
            label5.Name = "label5";
            label5.Size = new Size(325, 28);
            label5.TabIndex = 19;
            label5.Text = "TAREAS de la LISTA seleccionada:";
            // 
            // btnModificarTareaListaSelect
            // 
            btnModificarTareaListaSelect.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificarTareaListaSelect.Location = new Point(890, 548);
            btnModificarTareaListaSelect.Name = "btnModificarTareaListaSelect";
            btnModificarTareaListaSelect.Size = new Size(126, 38);
            btnModificarTareaListaSelect.TabIndex = 8;
            btnModificarTareaListaSelect.Text = "MODIFICAR TAREA";
            btnModificarTareaListaSelect.UseVisualStyleBackColor = true;
            btnModificarTareaListaSelect.Click += btnModificarTareaListaSelect_Click;
            // 
            // btnEliminarTareaListaSelect
            // 
            btnEliminarTareaListaSelect.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminarTareaListaSelect.Location = new Point(1050, 548);
            btnEliminarTareaListaSelect.Name = "btnEliminarTareaListaSelect";
            btnEliminarTareaListaSelect.Size = new Size(126, 38);
            btnEliminarTareaListaSelect.TabIndex = 9;
            btnEliminarTareaListaSelect.Text = "ELIMINAR TAREA";
            btnEliminarTareaListaSelect.UseVisualStyleBackColor = true;
            btnEliminarTareaListaSelect.Click += btnEliminarTareaListaSelect_Click;
            // 
            // btnAgregarTareaListaSelect
            // 
            btnAgregarTareaListaSelect.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregarTareaListaSelect.Location = new Point(725, 548);
            btnAgregarTareaListaSelect.Name = "btnAgregarTareaListaSelect";
            btnAgregarTareaListaSelect.Size = new Size(126, 38);
            btnAgregarTareaListaSelect.TabIndex = 7;
            btnAgregarTareaListaSelect.Text = "AGREGAR TAREA";
            btnAgregarTareaListaSelect.UseVisualStyleBackColor = true;
            btnAgregarTareaListaSelect.Click += btnAgregarTareaListaSelect_Click;
            // 
            // calendario
            // 
            calendario.Location = new Point(28, 622);
            calendario.Name = "calendario";
            calendario.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(28, 547);
            label1.Name = "label1";
            label1.Size = new Size(159, 22);
            label1.TabIndex = 33;
            label1.Text = "Marcar tarea como:";
            // 
            // btnExportar
            // 
            btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportar.Location = new Point(980, 622);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(126, 38);
            btnExportar.TabIndex = 34;
            btnExportar.Text = "EXPORTAR (ARCHIVOS)";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportar.Location = new Point(980, 677);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(126, 38);
            btnImportar.TabIndex = 35;
            btnImportar.Text = "IMPORTAR (ARCHIVOS)";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // formPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 811);
            Controls.Add(btnImportar);
            Controls.Add(btnExportar);
            Controls.Add(label1);
            Controls.Add(calendario);
            Controls.Add(btnModificarTareaListaSelect);
            Controls.Add(btnEliminarTareaListaSelect);
            Controls.Add(btnAgregarTareaListaSelect);
            Controls.Add(label5);
            Controls.Add(listViewListaSeleccionada);
            Controls.Add(listViewTareas);
            Controls.Add(listViewTareasHoy);
            Controls.Add(textBoxDescripcion);
            Controls.Add(btnEstadoCompleto);
            Controls.Add(labelHoraActual);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnModificarTareaLista);
            Controls.Add(btnEliminarTareaLista);
            Controls.Add(btnAgregarTareaLista);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "formPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "To-DoTASKS: Organizador de Tareas.";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button btnAgregarTareaLista;
        private Button btnEliminarTareaLista;
        private Label label3;
        private Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label labelHoraActual;
        private Button btnEstadoCompleto;
        private TextBox textBoxDescripcion;
        private ListView listViewTareasHoy;
        private ListView listViewTareas;
        private ListView listViewListaSeleccionada;
        private Label label5;
        private Button btnModificarTareaListaSelect;
        private Button btnEliminarTareaListaSelect;
        private Button btnAgregarTareaListaSelect;
        private Button button11;
        private MonthCalendar calendario;
        private Button btnModificarTareaLista;
        private Label label1;
        private Button btnExportar;
        private Button btnImportar;
    }
}