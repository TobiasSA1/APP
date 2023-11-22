namespace ToDoTasks
{
    partial class formAgregarLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAgregarLista));
            richTextBoxNombreLista = new RichTextBox();
            label1 = new Label();
            checkDias = new CheckBox();
            checkFechaEspecifica = new CheckBox();
            label5 = new Label();
            checkDiaria = new CheckBox();
            radioIrregular = new RadioButton();
            radioRutinaria = new RadioButton();
            label3 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // richTextBoxNombreLista
            // 
            richTextBoxNombreLista.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxNombreLista.Location = new Point(12, 61);
            richTextBoxNombreLista.Name = "richTextBoxNombreLista";
            richTextBoxNombreLista.Size = new Size(807, 30);
            richTextBoxNombreLista.TabIndex = 0;
            richTextBoxNombreLista.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(387, 23);
            label1.TabIndex = 27;
            label1.Text = "Nombre de la Lista de Tareas:";
            // 
            // checkDias
            // 
            checkDias.AutoSize = true;
            checkDias.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkDias.Location = new Point(460, 189);
            checkDias.Name = "checkDias";
            checkDias.Size = new Size(107, 27);
            checkDias.TabIndex = 5;
            checkDias.Text = "Dia/s:";
            checkDias.UseVisualStyleBackColor = true;
            checkDias.CheckedChanged += CheckDias_CheckedChanged;
            // 
            // checkFechaEspecifica
            // 
            checkFechaEspecifica.AutoSize = true;
            checkFechaEspecifica.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkFechaEspecifica.Location = new Point(460, 123);
            checkFechaEspecifica.Name = "checkFechaEspecifica";
            checkFechaEspecifica.Size = new Size(237, 27);
            checkFechaEspecifica.TabIndex = 3;
            checkFechaEspecifica.Text = "Fecha especifica";
            checkFechaEspecifica.UseVisualStyleBackColor = true;
            checkFechaEspecifica.CheckedChanged += CheckFechaEspecifica_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(285, 122);
            label5.Name = "label5";
            label5.Size = new Size(153, 23);
            label5.TabIndex = 52;
            label5.Text = "Repeticion:";
            // 
            // checkDiaria
            // 
            checkDiaria.AutoSize = true;
            checkDiaria.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            checkDiaria.Location = new Point(460, 156);
            checkDiaria.Name = "checkDiaria";
            checkDiaria.Size = new Size(107, 27);
            checkDiaria.TabIndex = 4;
            checkDiaria.Text = "Diaria";
            checkDiaria.UseVisualStyleBackColor = true;
            checkDiaria.CheckedChanged += CheckDiaria_CheckedChanged;
            // 
            // radioIrregular
            // 
            radioIrregular.AutoSize = true;
            radioIrregular.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            radioIrregular.Location = new Point(108, 155);
            radioIrregular.Name = "radioIrregular";
            radioIrregular.Size = new Size(145, 27);
            radioIrregular.TabIndex = 2;
            radioIrregular.TabStop = true;
            radioIrregular.Text = "Irregular";
            radioIrregular.UseVisualStyleBackColor = true;
            radioIrregular.CheckedChanged += RadioIrregular_CheckedChanged;
            // 
            // radioRutinaria
            // 
            radioRutinaria.AutoSize = true;
            radioRutinaria.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            radioRutinaria.Location = new Point(108, 122);
            radioRutinaria.Name = "radioRutinaria";
            radioRutinaria.Size = new Size(145, 27);
            radioRutinaria.TabIndex = 1;
            radioRutinaria.TabStop = true;
            radioRutinaria.Text = "Rutinaria";
            radioRutinaria.UseVisualStyleBackColor = true;
            radioRutinaria.CheckedChanged += RadioRutinaria_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 122);
            label3.Name = "label3";
            label3.Size = new Size(75, 23);
            label3.TabIndex = 48;
            label3.Text = "Tipo:";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(33, 239);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 49);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Location = new Point(649, 239);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(140, 49);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAgregarLista_Click;
            // 
            // formAgregarLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 317);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(checkDias);
            Controls.Add(checkFechaEspecifica);
            Controls.Add(label5);
            Controls.Add(checkDiaria);
            Controls.Add(radioIrregular);
            Controls.Add(radioRutinaria);
            Controls.Add(label3);
            Controls.Add(richTextBoxNombreLista);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "formAgregarLista";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de (LISTAS).";
            Load += formAgregarLista_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxNombreLista;
        private Label label1;
        private CheckBox checkDias;
        private CheckBox checkFechaEspecifica;
        private Label label5;
        private CheckBox checkDiaria;
        private RadioButton radioIrregular;
        private RadioButton radioRutinaria;
        private Label label3;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}