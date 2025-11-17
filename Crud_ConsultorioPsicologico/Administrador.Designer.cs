namespace Crud_ConsultorioPsicologico
{
    partial class Administrador
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
            menuStrip1 = new MenuStrip();
            registroToolStripMenuItem = new ToolStripMenuItem();
            registroPacientesToolStripMenuItem = new ToolStripMenuItem();
            registroProfesionalesToolStripMenuItem = new ToolStripMenuItem();
            turnosToolStripMenuItem = new ToolStripMenuItem();
            verAgendaToolStripMenuItem = new ToolStripMenuItem();
            registrarTurnoToolStripMenuItem = new ToolStripMenuItem();
            PanelRegistros = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { registroToolStripMenuItem, turnosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1097, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem
            // 
            registroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registroPacientesToolStripMenuItem, registroProfesionalesToolStripMenuItem });
            registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            registroToolStripMenuItem.Size = new Size(62, 20);
            registroToolStripMenuItem.Text = "Registro";
            // 
            // registroPacientesToolStripMenuItem
            // 
            registroPacientesToolStripMenuItem.Name = "registroPacientesToolStripMenuItem";
            registroPacientesToolStripMenuItem.Size = new Size(190, 22);
            registroPacientesToolStripMenuItem.Text = "Registro Pacientes";
            registroPacientesToolStripMenuItem.Click += registroPacientesToolStripMenuItem_Click;
            // 
            // registroProfesionalesToolStripMenuItem
            // 
            registroProfesionalesToolStripMenuItem.Name = "registroProfesionalesToolStripMenuItem";
            registroProfesionalesToolStripMenuItem.Size = new Size(190, 22);
            registroProfesionalesToolStripMenuItem.Text = "Registro Profesionales";
            registroProfesionalesToolStripMenuItem.Click += registroProfesionalesToolStripMenuItem_Click;
            // 
            // turnosToolStripMenuItem
            // 
            turnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verAgendaToolStripMenuItem, registrarTurnoToolStripMenuItem });
            turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            turnosToolStripMenuItem.Size = new Size(56, 20);
            turnosToolStripMenuItem.Text = "Turnos";
            // 
            // verAgendaToolStripMenuItem
            // 
            verAgendaToolStripMenuItem.Name = "verAgendaToolStripMenuItem";
            verAgendaToolStripMenuItem.Size = new Size(155, 22);
            verAgendaToolStripMenuItem.Text = "Ver Agenda";
            // 
            // registrarTurnoToolStripMenuItem
            // 
            registrarTurnoToolStripMenuItem.Name = "registrarTurnoToolStripMenuItem";
            registrarTurnoToolStripMenuItem.Size = new Size(155, 22);
            registrarTurnoToolStripMenuItem.Text = "Registrar Turno";
            registrarTurnoToolStripMenuItem.Click += turnosToolStripMenuItem_Click;
            // 
            // PanelRegistros
            // 
            PanelRegistros.BackColor = SystemColors.ActiveCaption;
            PanelRegistros.Dock = DockStyle.Fill;
            PanelRegistros.Location = new Point(0, 24);
            PanelRegistros.Name = "PanelRegistros";
            PanelRegistros.Size = new Size(1097, 519);
            PanelRegistros.TabIndex = 1;
            // 
            // Administrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 543);
            Controls.Add(PanelRegistros);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Administrador";
            Text = "Administrador";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem registroToolStripMenuItem;
        private ToolStripMenuItem registroPacientesToolStripMenuItem;
        private ToolStripMenuItem registroProfesionalesToolStripMenuItem;
        private ToolStripMenuItem turnosToolStripMenuItem;
        private ToolStripMenuItem verAgendaToolStripMenuItem;
        private ToolStripMenuItem registrarTurnoToolStripMenuItem;
        private Panel PanelRegistros;
    }
}