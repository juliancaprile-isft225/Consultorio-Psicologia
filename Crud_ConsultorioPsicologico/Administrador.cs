using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_ConsultorioPsicologico
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void registroPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PanelRegistros.Controls.Clear(); //no se apilen  paneles
            //creamos intancia del panel
            UC_RegistroPacientes registroPacientes = new UC_RegistroPacientes();

            registroPacientes.Dock = DockStyle.Fill; //ocupe todo 

            PanelRegistros.Controls.Add(registroPacientes); //agregamos el panel al contenedor



            registroPacientes.Show(); //traer al frente

        }

        private void registroProfesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelRegistros.Controls.Clear(); // no se apilen paneles
            // Creamos instancia del panel
            UCRegistroPsicologo registroPsicologo = new UCRegistroPsicologo();

            registroPsicologo.Dock = DockStyle.Fill; // ocupamos toda la pantalla

            PanelRegistros.Controls.Add(registroPsicologo); // agregamos el panel al contenedor

            registroPsicologo.Show(); // mostramos
        }

        // Método para cargar cualquier UserControl en el Panel Contenedor 
        private void LoadUserControl(System.Windows.Forms.UserControl userControl)
        {
            
            PanelRegistros.Controls.Clear(); // limpiamos panel del control anterior

            
            userControl.Dock = DockStyle.Fill; // ocupamos toda la pantalla

           //agregamos el nuevo control de usuario
            PanelRegistros.Controls.Add(userControl);

           // mostrmos
            userControl.Show();
        }

        
    }
}
