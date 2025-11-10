using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Crud_ConsultorioPsicologico
{
    
    public class TurnosDAO
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
                MessageBox.Show("Error fatal de conexión DAO (Turnos): " + ex.Message,
                                "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        
        public void GuardarTurno(int idPacienteFK, string fecha, string hora)
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    
                    string query = "INSERT INTO turnos (Id_Paciente_FK, Fecha, Hora) " +
                                   "VALUES (@IdPacienteFK, @Fecha, @Hora)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdPacienteFK", idPacienteFK);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Hora", hora);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                // Este error saltará si el 'idPacienteFK' no existe en la tabla 'paciente'
                if (ex.Number == 1452) // Error de Violación de Foreign Key
                {
                    MessageBox.Show("Error: No se puede guardar el turno porque el ID del paciente no existe.",
                                    "Error de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al guardar el turno en la DB: " + ex.Message,
                                    "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       // cargar los turnos al dtg
        public DataTable CargarTurnos()
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return null;

                    // Consulta simple para traer todos los turnos
                    // NOTA: Esto trae los IDs, no los nombres. Lo podemos mejorar después.
                    string query = "SELECT Id_Turno, Id_Paciente_FK, CAST(Fecha AS CHAR) AS Fecha, CAST(Hora AS CHAR) AS Hora FROM turnos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos desde la DB: " + ex.Message,
                                "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //eliminar tuno
        public void EliminarTurno(int idTurno)
        {
            try
            {
                using (MySqlConnection conn = ConectarDB())
                {
                    if (conn == null) return;

                    string query = "DELETE FROM turnos WHERE Id_Turno = @IdTurno";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdTurno", idTurno);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el turno en la DB: " + ex.Message,
                                "Error MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}