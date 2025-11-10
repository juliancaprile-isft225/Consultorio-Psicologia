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
       //declaraciones de uc 
        private UC_RegistroPacientes ucRegistroPacientesInstance;
        private UCRegistroPsicologo ucRegistroPsicologoInstance;
        private UC_Turnos ucTurnosInstance; 
        public Administrador()
        {
            InitializeComponent();

            //constructor
            ucRegistroPacientesInstance = new UC_RegistroPacientes();
            ucRegistroPsicologoInstance = new UCRegistroPsicologo();
            ucTurnosInstance = new UC_Turnos();
        }

        private void registroPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PASO 3: Llamar al método auxiliar de carga, pasando la instancia ÚNICA
            LoadUserControl(ucRegistroPacientesInstance);

            // Opcional: Asegurarse de que el DGV se actualice al mostrar (si no se hace en el Load del UC)
            ucRegistroPacientesInstance.CargarDatos();
        }

        private void registroProfesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PASO 3: Llamar al método auxiliar de carga, pasando la instancia ÚNICA
            LoadUserControl(ucRegistroPsicologoInstance);

            // Si UCRegistroPsicologo tiene un DGV, puedes hacer:
            // ucRegistroPsicologoInstance.CargarDatos(); 
        }

        // Método para cargar cualquier UserControl en el Panel Contenedor 
        private void LoadUserControl(System.Windows.Forms.UserControl userControl)
        {
            // Este método ahora recibe la instancia ÚNICA que declaramos arriba

            PanelRegistros.Controls.Clear(); // Limpiamos panel del control anterior

            userControl.Dock = DockStyle.Fill; // Ocupamos toda la pantalla

            // Agregamos el control de usuario (la instancia que se pasó)
            PanelRegistros.Controls.Add(userControl);

            // Mostramos (esto es redundante si se agrega a Controls, pero no hace daño)
            userControl.Show();
        }
        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Llamamos al método auxiliar de carga, pasando la instancia ÚNICA
            LoadUserControl(ucTurnosInstance);

            // Opcional: Asegurarse de que el DGV de turnos se actualice al mostrar
            // (Aunque ya lo hace el evento Load del UC_Turnos, esto es una doble verificación)
            // ucTurnosInstance.CargarGrillaTurnos(); 
        }


    }
}