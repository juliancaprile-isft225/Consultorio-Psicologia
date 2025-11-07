using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
// Asegúrate de que tu clase Paciente esté en el mismo namespace o importada
// using Crud_ConsultorioPsicologico; 

namespace Crud_ConsultorioPsicologico
{
    public partial class UC_RegistroPacientes : UserControl
    {
        // Constructor
        public UC_RegistroPacientes()
        {
            InitializeComponent();
            // Asignar eventos de forma programática (puedes hacerlo desde el diseñador también)
            this.Load += UC_RegistroPacientes_Load;
            this.dtgRegistroPaciente.CellClick += dtgRegistroPaciente_CellClick;
        }

        // ==========================================================
        // MÉTODOS DE CONEXIÓN Y ABM
        // ==========================================================

        // Método para conectar a la base de datos
        public MySqlConnection ConectarDB()
        {
            try
            {
                // Verifica que los datos de conexión sean correctos para tu XAMPP/MySQL
                string connectionString = "Server=localhost;Database=Crud_consultorio;Uid=root;Pwd=;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                return null;
            }
        }

        // Alta - Guardar nuevo paciente
        public void GuardarPaciente()
        {
            try
            {
                // Omitiendo validación, pero haciendo el parseo necesario para MySQL
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                int dni = int.Parse(txtDni.Text);
                int telefono = int.Parse(txtTelefono.Text);

                Paciente paciente = new Paciente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Motivo = txtMotivo.Text,
                    Correo = txtCorreo.Text
                };

                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "INSERT INTO Paciente (Nombre, Apellido, Fecha_Nacimiento, Direccion, Motivo_Consulta, Dni, Telefono, Correo) " +
                                   "VALUES (@Nombre, @Apellido, @Fecha_Nacimiento, @Direccion, @Motivo_Consulta, @Dni, @Telefono, @Correo)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@Motivo_Consulta", paciente.Motivo);
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente guardado correctamente (Alta).");
                    CargarDatos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar paciente (Verifique formatos de Fecha/DNI/Teléfono): " + ex.Message);
            }
        }

        // Modificación - Actualizar paciente existente
        public void ActualizarPaciente(int idPaciente)
        {
            try
            {
                // Omitiendo validación, pero haciendo el parseo necesario para MySQL
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                int dni = int.Parse(txtDni.Text);
                int telefono = int.Parse(txtTelefono.Text);

                Paciente paciente = new Paciente
                {
                    IdPaciente = idPaciente, // CLAVE para la modificación
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion = txtDireccion.Text,
                    Motivo = txtMotivo.Text,
                    Correo = txtCorreo.Text
                };

                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "UPDATE Paciente SET Nombre = @Nombre, Apellido = @Apellido, Fecha_Nacimiento = @Fecha_Nacimiento, " +
                                   "Direccion = @Direccion, Motivo_Consulta = @Motivo_Consulta, Dni = @Dni, Telefono = @Telefono, Correo = @Correo " +
                                   "WHERE Id_Paciente = @Id_Paciente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id_Paciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@Motivo_Consulta", paciente.Motivo);
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente actualizado correctamente (Modificación).");
                    CargarDatos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar paciente: " + ex.Message);
            }
        }

        // Baja - Eliminar paciente
        public void EliminarPaciente(int idPaciente)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea ELIMINAR este paciente?", "Confirmar Baja", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No) return;

                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "DELETE FROM Paciente WHERE Id_Paciente = @Id_Paciente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id_Paciente", idPaciente);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente eliminado correctamente (Baja).");
                    CargarDatos();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar paciente: " + ex.Message);
            }
        }

        // Lectura - Cargar datos al DGV
        public void CargarDatos()
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "SELECT * FROM Paciente";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dtgRegistroPaciente.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        // ==========================================================
        // MÉTODOS AUXILIARES Y EVENTOS
        // ==========================================================

        // Limpia todos los TextBox
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

                // Asegúrate de que los nombres de las columnas coincidan con tu tabla MySQL (ej: Id_Paciente)
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();

                // Manejo de la fecha
                if (row.Cells["Fecha_Nacimiento"].Value != DBNull.Value)
                {
                    if (row.Cells["Fecha_Nacimiento"].Value is DateTime fecha)
                    {
                        txtFechaNacimiento.Text = fecha.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtFechaNacimiento.Text = row.Cells["Fecha_Nacimiento"].Value.ToString();
                    }
                }

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

        // Evento del botón Guardar (Alta)
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPaciente();
        }

        // Evento del botón Actualizar (Modificación)
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dtgRegistroPaciente.SelectedRows.Count > 0)
            {
                // Obtiene el ID del registro seleccionado (asumiendo que Id_Paciente es la clave)
                int idPaciente = Convert.ToInt32(dtgRegistroPaciente.SelectedRows[0].Cells["Id_Paciente"].Value);
                ActualizarPaciente(idPaciente);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila y modifique los campos para actualizar.");
            }
        }

        // Evento del botón Eliminar (Baja)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgRegistroPaciente.SelectedRows.Count > 0)
            {
                // Obtiene el ID del registro seleccionado
                int idPaciente = Convert.ToInt32(dtgRegistroPaciente.SelectedRows[0].Cells["Id_Paciente"].Value);
                EliminarPaciente(idPaciente);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.");
            }
        }
    }
}