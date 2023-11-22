namespace ToDoTasks
{
    partial class formConsultaAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConsultaAgregar));
            lblConsulta = new Label();
            btnLista = new Button();
            btnTarea = new Button();
            SuspendLayout();
            // 
            // lblConsulta
            // 
            lblConsulta.AutoSize = true;
            lblConsulta.Font = new Font("Courier New", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblConsulta.Location = new Point(86, 35);
            lblConsulta.Name = "lblConsulta";
            lblConsulta.Size = new Size(322, 23);
            lblConsulta.TabIndex = 26;
            lblConsulta.Text = "¿Que desea dar de alta?:";
            // 
            // btnLista
            // 
            btnLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLista.Location = new Point(27, 113);
            btnLista.Name = "btnLista";
            btnLista.Size = new Size(168, 49);
            btnLista.TabIndex = 0;
            btnLista.Text = "LISTA";
            btnLista.UseVisualStyleBackColor = true;
            btnLista.Click += btnLista_Click;
            // 
            // btnTarea
            // 
            btnTarea.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnTarea.Location = new Point(301, 113);
            btnTarea.Name = "btnTarea";
            btnTarea.Size = new Size(168, 49);
            btnTarea.TabIndex = 1;
            btnTarea.Text = "TAREA";
            btnTarea.UseVisualStyleBackColor = true;
            btnTarea.Click += btnTarea_Click;
            // 
            // formConsultaAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 191);
            Controls.Add(btnTarea);
            Controls.Add(btnLista);
            Controls.Add(lblConsulta);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "formConsultaAgregar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta de Alta.";
            Load += formConsultaAgregar_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsulta;
        private Button btnLista;
        private Button btnTarea;
    }
}