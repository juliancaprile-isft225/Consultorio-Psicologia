namespace Crud_ConsultorioPsicologico
{
    partial class UC_Turnos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtDniPaciente = new TextBox();
            btnBuscarPaciente = new Button();
            lblNombrePaciente = new Label();
            label2 = new Label();
            dtpFecha = new DateTimePicker();
            label3 = new Label();
            cmbHora = new ComboBox();
            btnGuardarTurno = new Button();
            dtgTurnos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtgTurnos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 54);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "DNI:";
            // 
            // txtDniPaciente
            // 
            txtDniPaciente.Location = new Point(122, 51);
            txtDniPaciente.Name = "txtDniPaciente";
            txtDniPaciente.Size = new Size(100, 23);
            txtDniPaciente.TabIndex = 1;
            txtDniPaciente.TextChanged += txtDniPaciente_TextChanged;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(258, 51);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.Size = new Size(75, 23);
            btnBuscarPaciente.TabIndex = 2;
            btnBuscarPaciente.Text = "buscar";
            btnBuscarPaciente.UseVisualStyleBackColor = true;
            btnBuscarPaciente.Click += btnBuscarPaciente_Click;
            // 
            // lblNombrePaciente
            // 
            lblNombrePaciente.AutoSize = true;
            lblNombrePaciente.Location = new Point(122, 96);
            lblNombrePaciente.Name = "lblNombrePaciente";
            lblNombrePaciente.Size = new Size(58, 15);
            lblNombrePaciente.TabIndex = 3;
            lblNombrePaciente.Text = "Paciente..";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 145);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "FECHA";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(74, 176);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 145);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 6;
            label3.Text = "HORA";
            // 
            // cmbHora
            // 
            cmbHora.FormattingEnabled = true;
            cmbHora.Items.AddRange(new object[] { "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00" });
            cmbHora.Location = new Point(298, 176);
            cmbHora.Name = "cmbHora";
            cmbHora.Size = new Size(110, 23);
            cmbHora.TabIndex = 7;
            // 
            // btnGuardarTurno
            // 
            btnGuardarTurno.Location = new Point(223, 388);
            btnGuardarTurno.Name = "btnGuardarTurno";
            btnGuardarTurno.Size = new Size(75, 23);
            btnGuardarTurno.TabIndex = 8;
            btnGuardarTurno.Text = "Guardar Turno";
            btnGuardarTurno.UseVisualStyleBackColor = true;
            btnGuardarTurno.Click += btnGuardarTurno_Click;
            // 
            // dtgTurnos
            // 
            dtgTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgTurnos.Location = new Point(74, 232);
            dtgTurnos.Name = "dtgTurnos";
            dtgTurnos.Size = new Size(494, 150);
            dtgTurnos.TabIndex = 9;
            // 
            // UC_Turnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dtgTurnos);
            Controls.Add(btnGuardarTurno);
            Controls.Add(cmbHora);
            Controls.Add(label3);
            Controls.Add(dtpFecha);
            Controls.Add(label2);
            Controls.Add(lblNombrePaciente);
            Controls.Add(btnBuscarPaciente);
            Controls.Add(txtDniPaciente);
            Controls.Add(label1);
            Name = "UC_Turnos";
            Size = new Size(596, 424);
            Click += UC_Turnos_Load;
            ((System.ComponentModel.ISupportInitialize)dtgTurnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDniPaciente;
        private Button btnBuscarPaciente;
        private Label lblNombrePaciente;
        private Label label2;
        private DateTimePicker dtpFecha;
        private Label label3;
        private ComboBox cmbHora;
        private Button btnGuardarTurno;
        private DataGridView dtgTurnos;
    }
}
