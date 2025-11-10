using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Crud_ConsultorioPsicologico
{
    public class PacienteDAO
    {
        private string connectionString = "Server=localhost;Database=crud_consultorio;Uid=root;Pwd=;";

        private MySqlConnection ConectarDB()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión DAO: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // --- MÉTODOS ABM ---

        // Método para INSERTAR (Alta) - NOTA: La fecha ahora es un string
        public void Guardar(Paciente paciente, string fechaNacimiento, int dni, int telefono)
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "INSERT INTO paciente (Nombre, Apellido, Fecha_Nacimiento, Direccion, Motivo_Consulta, Dni, Telefono, Correo) " +
                                   "VALUES (@Nombre, @Apellido, @Fecha_Nacimiento, @Direccion, @Motivo_Consulta, @Dni, @Telefono, @Correo)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento); // Se pasa el string directamente
                    cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@Motivo_Consulta", paciente.Motivo);
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar paciente en la DB: " + ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para ACTUALIZAR (Modificación) - NOTA: La fecha ahora es un string
        public void Actualizar(Paciente paciente, string fechaNacimiento, int dni, int telefono)
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "UPDATE paciente SET Nombre = @Nombre, Apellido = @Apellido, Fecha_Nacimiento = @Fecha_Nacimiento, " +
                                   "Direccion = @Direccion, Motivo_Consulta = @Motivo_Consulta, Dni = @Dni, Telefono = @Telefono, Correo = @Correo " +
                                   "WHERE Id_Paciente = @Id_Paciente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id_Paciente", paciente.IdPaciente);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento); // Se pasa el string directamente
                    cmd.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@Motivo_Consulta", paciente.Motivo);
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Correo", paciente.Correo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al actualizar paciente en la DB: " + ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para ELIMINAR (Baja)
        public void Eliminar(int idPaciente)
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "DELETE FROM paciente WHERE Id_Paciente = @Id_Paciente";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id_Paciente", idPaciente);
                    cmd.ExecuteNonQuery();

                    // Si la eliminación fue exitosa (porque no tenía turnos), 
                    // mostramos el mensaje de éxito desde el UserControl (UC_RegistroPacientes).
                }
            }
            catch (MySqlException ex)
            {
                // Esta es la lógica que sugeriste:
                // Error 1451: No se puede borrar o actualizar una fila padre (una violación de Foreign Key).
                if (ex.Number == 1451)
                {
                    MessageBox.Show("No se puede eliminar el paciente porque tiene turnos agendados. " +
                                    "Por favor, elimine primero los turnos asociados a este paciente.",
                                    "Error: Paciente con Turnos",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    // Para cualquier otro error de MySQL
                    MessageBox.Show("Error al eliminar en la DB: " + ex.Message,
                                    "Error MySQL",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        // Método para SELECCIONAR (Lectura)
        public DataTable CargarDatos()
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return null;

                    string query = "SELECT * FROM paciente";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos desde la DB: " + ex.Message, "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        // nuevo metodo para turnos
        // Método para BUSCAR un Paciente por DNI
        // Devuelve una DataTable (fácil de revisar)
        public DataTable BuscarPorDni(int dni)
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return null;

                    // Selecciona todas las columnas del paciente donde el Dni coincida
                    string query = "SELECT * FROM paciente WHERE Dni = @Dni LIMIT 1";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Dni", dni);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt; // Devuelve la tabla (estará vacía o tendrá 1 fila)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar paciente por DNI: " + ex.Message,
                                "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



    }
}

