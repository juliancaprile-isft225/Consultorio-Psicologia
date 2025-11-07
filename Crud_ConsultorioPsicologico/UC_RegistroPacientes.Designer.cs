namespace Crud_ConsultorioPsicologico
{
    partial class UC_RegistroPacientes
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            txtFechaNacimiento = new TextBox();
            txtApellido = new TextBox();
            btn_Guardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dtgRegistroPaciente = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            txtMotivo = new TextBox();
            txtDni = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgRegistroPaciente).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(468, 17);
            label1.Name = "label1";
            label1.Size = new Size(229, 37);
            label1.TabIndex = 0;
            label1.Text = "Registrar paciente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(191, 91);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 127);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 168);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 3;
            label4.Text = "Fecha de nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(476, 88);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 4;
            label5.Text = "Direccion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(318, 85);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(612, 83);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 6;
            // 
            // txtFechaNacimiento
            // 
            txtFechaNacimiento.Location = new Point(318, 160);
            txtFechaNacimiento.Name = "txtFechaNacimiento";
            txtFechaNacimiento.Size = new Size(100, 23);
            txtFechaNacimiento.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(318, 119);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 8;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Location = new Point(331, 215);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(75, 23);
            btn_Guardar.TabIndex = 9;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(562, 215);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(758, 215);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dtgRegistroPaciente
            // 
            dtgRegistroPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgRegistroPaciente.Location = new Point(31, 266);
            dtgRegistroPaciente.Name = "dtgRegistroPaciente";
            dtgRegistroPaciente.Size = new Size(1139, 316);
            dtgRegistroPaciente.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(476, 168);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 13;
            label6.Text = "DNI";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(476, 127);
            label7.Name = "label7";
            label7.Size = new Size(109, 15);
            label7.TabIndex = 14;
            label7.Text = "Motivo de consulta";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(612, 124);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(100, 23);
            txtMotivo.TabIndex = 15;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(612, 165);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(763, 93);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 17;
            label8.Text = "Telefono";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(763, 132);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 18;
            label9.Text = "Correo Electronico";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(906, 88);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 19;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(906, 129);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(100, 23);
            txtCorreo.TabIndex = 20;
            // 
            // UC_RegistroPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtDni);
            Controls.Add(txtMotivo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dtgRegistroPaciente);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btn_Guardar);
            Controls.Add(txtApellido);
            Controls.Add(txtFechaNacimiento);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_RegistroPacientes";
            Size = new Size(1200, 600);
            ((System.ComponentModel.ISupportInitialize)dtgRegistroPaciente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtFechaNacimiento;
        private TextBox txtApellido;
        private Button btn_Guardar;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dtgRegistroPaciente;
        private Label label6;
        private Label label7;
        private TextBox txtMotivo;
        private TextBox txtDni;
        private Label label8;
        private Label label9;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
    }
}
