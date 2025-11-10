using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Crud_ConsultorioPsicologico
{
    public partial class UC_RegistroPacientes : UserControl
    {
        private PacienteDAO pacienteDAO = new PacienteDAO();

        // Constructor (sin cambios)
        public UC_RegistroPacientes()
        {
            InitializeComponent();

        }

       //LLAMAMOS A LA DAO

        // Alta - Guardar nuevo paciente
        public void GuardarPaciente()
        {
            // La fecha ahora se trata como un STRING
            string fechaNacimientoSQL = string.Empty;
            int dniSQL;
            int telefonoSQL;

            try
            {
               
                fechaNacimientoSQL = txtFechaNacimiento.Text.Trim();

                // Validación de que DNI y Teléfono sean números
                dniSQL = int.Parse(txtDni.Text);
                telefonoSQL = int.Parse(txtTelefono.Text);

               
            }
            catch (FormatException)
            {
                MessageBox.Show("Error de formato: El DNI o Teléfono deben ser números enteros válidos.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Crear objeto Paciente con datos de string
                Paciente paciente = new Paciente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Motivo = txtMotivo.Text,
                    Correo = txtCorreo.Text
                };

                // llamamos a la dao
                // Se pasa la fecha como string
                pacienteDAO.Guardar(paciente, fechaNacimientoSQL, dniSQL, telefonoSQL);

                // Si la llamada fue exitosa y no hubo error mostrar
                MessageBox.Show("Paciente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // verificar si hubo un error  en la dao
                MessageBox.Show("Error en la interfaz al guardar: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // clases 
        // Modificación - Actualizar paciente existente
        public void ActualizarPaciente(int idPaciente)
        {
            string fechaNacimientoSQL = string.Empty;
            int dniSQL;
            int telefonoSQL;

            try
            {
                // 1. Lógica de UI (Parseo/Validación): Solo DNI y Teléfono requieren ser números
                fechaNacimientoSQL = txtFechaNacimiento.Text.Trim();

                dniSQL = int.Parse(txtDni.Text);
                telefonoSQL = int.Parse(txtTelefono.Text);

                if (string.IsNullOrWhiteSpace(fechaNacimientoSQL))
                {
                    MessageBox.Show("El campo Fecha de Nacimiento no puede estar vacío.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error de formato: El DNI o Teléfono deben ser números enteros válidos.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Paciente paciente = new Paciente
                {
                    IdPaciente = idPaciente,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Motivo = txtMotivo.Text,
                    Correo = txtCorreo.Text
                };

                // 2. LLAMADA A LA CAPA DE DATOS (PacienteDAO)
                pacienteDAO.Actualizar(paciente, fechaNacimientoSQL, dniSQL, telefonoSQL);

                MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la interfaz al actualizar: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Baja - Eliminar paciente
        public void EliminarPaciente(int idPaciente)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea ELIMINAR este paciente?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No) return;

            try
            {
                // LLAMADA A LA CAPA DE DATOS (PacienteDAO)
                pacienteDAO.Eliminar(idPaciente);

                MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la interfaz al eliminar: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Lectura - Cargar datos al DGV
        public void CargarDatos()
        {
            // LLAMADA A LA CAPA DE DATOS (PacienteDAO)
            DataTable dt = pacienteDAO.CargarDatos();
            if (dtgRegistroPaciente != null && dt != null)
            {
                dtgRegistroPaciente.DataSource = dt;
            }
        }

     

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtFechaNacimiento.Clear();
            txtDireccion.Clear();
            txtMotivo.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtNombre.Focus();
        }

        // Carga los datos de la fila seleccionada a los TextBox
        private void CargarCamposDesdeDGV()
        {
            if (dtgRegistroPaciente.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgRegistroPaciente.SelectedRows[0];

                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();

                // La fecha se carga como string simple
                txtFechaNacimiento.Text = row.Cells["Fecha_Nacimiento"].Value.ToString();

                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtMotivo.Text = row.Cells["Motivo_Consulta"].Value.ToString();
                txtDni.Text = row.Cells["Dni"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo"].Value.ToString();
            }
        }

        // Evento Load del UserControl (para cargar datos al iniciar)
        private void UC_RegistroPacientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Evento Click del DataGridView (para cargar datos en los TextBox)
        private void dtgRegistroPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarCamposDesdeDGV();
        }

        // fin de las clases

        // eventoss


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPaciente();
        }

       
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtgRegistroPaciente.SelectedRows.Count > 0)
            {
                int idPaciente = Convert.ToInt32(dtgRegistroPaciente.SelectedRows[0].Cells["Id_Paciente"].Value);
                ActualizarPaciente(idPaciente);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila y modifique los campos para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgRegistroPaciente.SelectedRows.Count > 0)
            {
                int idPaciente = Convert.ToInt32(dtgRegistroPaciente.SelectedRows[0].Cells["Id_Paciente"].Value);
                EliminarPaciente(idPaciente);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}