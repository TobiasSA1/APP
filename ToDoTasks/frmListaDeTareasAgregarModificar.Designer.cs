namespace ToDoTasks
{
    partial class frmListaDeTareasAgregarModificar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaDeTareasAgregarModificar));
            btnCancelar = new Button();
            btnAceptar = new Button();
            richTextBoxNombreTareas = new RichTextBox();
            lblNombreDeLaTarea = new Label();
            RadioRutinaria = new RadioButton();
            RadioIrregular = new RadioButton();
            lblTipo = new Label();
            lblHorario = new Label();
            lblDescripcion = new Label();
            checkedListBoxDias = new CheckedListBox();
            dateTimePicker = new DateTimePicker();
            richTextBoxDescripcion = new RichTextBox();
            checkDiaria = new CheckBox();
            lblRepeticion = new Label();
            checkFechaEspecifica = new CheckBox();
            checkDias = new CheckBox();
            lblFecha = new Label();
            maskedTextBoxHora = new MaskedTextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(32, 669);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 49);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(945, 669);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(140, 49);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // richTextBoxNombreTareas
            // 
            richTextBoxNombreTareas.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxNombreTareas.Location = new Point(32, 64);
            richTextBoxNombreTareas.Name = "richTextBoxNombreTareas";
            richTextBoxNombreTareas.Size = new Size(1053, 30);
            richTextBoxNombreTareas.TabIndex = 0;
            richTextBoxNombreTareas.Text = "";
            // 
            // lblNombreDeLaTarea
            // 
            lblNombreDeLaTarea.AutoSize = true;
            lblNombreDeLaTarea.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreDeLaTarea.Location = new Point(32, 22);
            lblNombreDeLaTarea.Name = "lblNombreDeLaTarea";
            lblNombreDeLaTarea.Size = new Size(257, 23);
            lblNombreDeLaTarea.TabIndex = 25;
            lblNombreDeLaTarea.Text = "Nombre de la Tarea:";
            // 
            // RadioRutinaria
            // 
            RadioRutinaria.AutoSize = true;
            RadioRutinaria.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            RadioRutinaria.Location = new Point(27, 211);
            RadioRutinaria.Name = "RadioRutinaria";
            RadioRutinaria.Size = new Size(145, 27);
            RadioRutinaria.TabIndex = 2;
            RadioRutinaria.TabStop = true;
            RadioRutinaria.Text = "Rutinaria";
            RadioRutinaria.UseVisualStyleBackColor = true;
            RadioRutinaria.CheckedChanged += RadioRutinaria_CheckedChanged;
            // 
            // RadioIrregular
            // 
            RadioIrregular.AutoSize = true;
            RadioIrregular.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            RadioIrregular.Location = new Point(27, 166);
            RadioIrregular.Name = "RadioIrregular";
            RadioIrregular.Size = new Size(145, 27);
            RadioIrregular.TabIndex = 1;
            RadioIrregular.TabStop = true;
            RadioIrregular.Text = "Irregular";
            RadioIrregular.UseVisualStyleBackColor = true;
            RadioIrregular.CheckedChanged += RadioIrregular_CheckedChanged_1;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipo.Location = new Point(27, 120);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(75, 23);
            lblTipo.TabIndex = 28;
            lblTipo.Text = "Tipo:";
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblHorario.Location = new Point(963, 120);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(114, 23);
            lblHorario.TabIndex = 37;
            lblHorario.Text = "Horario:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.Location = new Point(27, 381);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(166, 23);
            lblDescripcion.TabIndex = 38;
            lblDescripcion.Text = "Descripcion:";
            // 
            // checkedListBoxDias
            // 
            checkedListBoxDias.Font = new Font("Courier New", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkedListBoxDias.FormattingEnabled = true;
            checkedListBoxDias.Location = new Point(555, 246);
            checkedListBoxDias.Name = "checkedListBoxDias";
            checkedListBoxDias.Size = new Size(207, 158);
            checkedListBoxDias.TabIndex = 8;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Font = new Font("Courier New", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker.Location = new Point(555, 161);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(375, 27);
            dateTimePicker.TabIndex = 6;
            // 
            // richTextBoxDescripcion
            // 
            richTextBoxDescripcion.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxDescripcion.Location = new Point(27, 427);
            richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            richTextBoxDescripcion.Size = new Size(1058, 224);
            richTextBoxDescripcion.TabIndex = 9;
            richTextBoxDescripcion.Text = "";
            // 
            // checkDiaria
            // 
            checkDiaria.AutoSize = true;
            checkDiaria.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkDiaria.Location = new Point(256, 212);
            checkDiaria.Name = "checkDiaria";
            checkDiaria.Size = new Size(107, 27);
            checkDiaria.TabIndex = 4;
            checkDiaria.Text = "Diaria";
            checkDiaria.UseVisualStyleBackColor = true;
            checkDiaria.CheckedChanged += CheckDiaria_CheckedChanged;
            // 
            // lblRepeticion
            // 
            lblRepeticion.AutoSize = true;
            lblRepeticion.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblRepeticion.Location = new Point(256, 120);
            lblRepeticion.Name = "lblRepeticion";
            lblRepeticion.Size = new Size(153, 23);
            lblRepeticion.TabIndex = 45;
            lblRepeticion.Text = "Repeticion:";
            // 
            // checkFechaEspecifica
            // 
            checkFechaEspecifica.AutoSize = true;
            checkFechaEspecifica.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkFechaEspecifica.Location = new Point(256, 166);
            checkFechaEspecifica.Name = "checkFechaEspecifica";
            checkFechaEspecifica.Size = new Size(237, 27);
            checkFechaEspecifica.TabIndex = 3;
            checkFechaEspecifica.Text = "Fecha especifica";
            checkFechaEspecifica.UseVisualStyleBackColor = true;
            checkFechaEspecifica.CheckedChanged += CheckFechaEspecifica_CheckedChanged;
            // 
            // checkDias
            // 
            checkDias.AutoSize = true;
            checkDias.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkDias.Location = new Point(256, 263);
            checkDias.Name = "checkDias";
            checkDias.Size = new Size(107, 27);
            checkDias.TabIndex = 5;
            checkDias.Text = "Dia/s:";
            checkDias.UseVisualStyleBackColor = true;
            checkDias.CheckedChanged += CheckDias_CheckedChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha.Location = new Point(555, 120);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(88, 23);
            lblFecha.TabIndex = 48;
            lblFecha.Text = "Fecha:";
            // 
            // maskedTextBoxHora
            // 
            maskedTextBoxHora.Location = new Point(969, 158);
            maskedTextBoxHora.MinimumSize = new Size(100, 30);
            maskedTextBoxHora.Name = "maskedTextBoxHora";
            maskedTextBoxHora.Size = new Size(100, 23);
            maskedTextBoxHora.TabIndex = 7;
            // 
            // frmListaDeTareasAgregarModificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 742);
            Controls.Add(maskedTextBoxHora);
            Controls.Add(lblFecha);
            Controls.Add(checkDias);
            Controls.Add(checkFechaEspecifica);
            Controls.Add(lblRepeticion);
            Controls.Add(checkDiaria);
            Controls.Add(RadioIrregular);
            Controls.Add(richTextBoxDescripcion);
            Controls.Add(dateTimePicker);
            Controls.Add(checkedListBoxDias);
            Controls.Add(lblDescripcion);
            Controls.Add(lblHorario);
            Controls.Add(RadioRutinaria);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(lblTipo);
            Controls.Add(richTextBoxNombreTareas);
            Controls.Add(lblNombreDeLaTarea);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmListaDeTareasAgregarModificar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de (TAREAS).";
            Load += frmListaDeTareasAgregarModificar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Button btnAceptar;
        private RichTextBox richTextBoxNombreTareas;
        private Label lblNombreDeLaTarea;
        private RadioButton RadioRutinaria;
        private RadioButton RadioIrregular;
        private Label lblTipo;
        private Label lblHorario;
        private Label lblDescripcion;
        private CheckedListBox checkedListBoxDias;
        private DateTimePicker dateTimePicker;
        private RichTextBox richTextBoxDescripcion;
        private GroupBox groupBox1;
        private CheckBox checkDiaria;
        private Label lblRepeticion;
        private CheckBox checkFechaEspecifica;
        private CheckBox checkDias;
        private Label lblFecha;
        private MaskedTextBox maskedTextBoxHora;
    }
}