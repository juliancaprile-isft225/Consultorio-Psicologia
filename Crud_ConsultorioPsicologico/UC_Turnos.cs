using System;
using System.Data;
using System.Drawing; // Necesario para cambiar colores
using System.Windows.Forms;
using Crud_ConsultorioPsicologico.Clases;

namespace Crud_ConsultorioPsicologico
{
    public partial class UC_Turnos : UserControl
    {
        // --- Conexión a las dos lógicas DAO ---
        private TurnosDAO turnosDAO = new TurnosDAO();
        private PacienteDAO pacienteDAO = new PacienteDAO(); // Necesita al DAO de Pacientes para buscar

        // --- Variable para guardar al paciente ---
        // Guardamos el ID del paciente que encontramos para usarlo al guardar el turno
        private int idPacienteEncontrado = 0;

        // Constructor
        public UC_Turnos()
        {
            InitializeComponent();
        }

        // --- Evento Load (Cuando el UC se carga por primera vez) ---
        private void UC_Turnos_Load(object sender, EventArgs e)
        {
            CargarGrillaTurnos();

            // Configuración inicial de la interfaz
            // Deshabilitamos el botón guardar hasta que se encuentre un paciente
            btnGuardarTurno.Enabled = false;
            lblNombrePaciente.Text = "Por favor, busque un DNI";

            // Establecemos un formato simple para el DateTimePicker
            // 'Format' controla cómo se ve; 'CustomFormat' le dice qué formato usar.
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
        }

        // --- Lógica del Botón "Buscar" ---
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            // 1. Validar la entrada de DNI
            if (!int.TryParse(txtDniPaciente.Text, out int dniBuscado))
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Llamar al PacienteDAO (el método que acabamos de agregar)
            DataTable dt = pacienteDAO.BuscarPorDni(dniBuscado);

            // 3. Revisar los resultados
            if (dt != null && dt.Rows.Count > 0)
            {
                // ¡Encontramos al paciente!
                DataRow row = dt.Rows[0];

                // Guardamos el ID para usarlo después al guardar el turno
                idPacienteEncontrado = Convert.ToInt32(row["Id_Paciente"]);

                // Mostramos el nombre para confirmación visual
                string nombreCompleto = $"{row["Nombre"]} {row["Apellido"]}";
                lblNombrePaciente.Text = $"Paciente: {nombreCompleto}";
                lblNombrePaciente.ForeColor = Color.Green; // Opcional: ponerlo en verde

                // HABILITAMOS el botón para guardar
                btnGuardarTurno.Enabled = true;
            }
            else
            {
                // No encontramos al paciente
                idPacienteEncontrado = 0; // Reseteamos el ID
                lblNombrePaciente.Text = "Paciente no encontrado.";
                lblNombrePaciente.ForeColor = Color.Red; // Opcional: ponerlo en rojo

                // DESHABILITAMOS el botón guardar
                btnGuardarTurno.Enabled = false;
            }
        }

        // --- Lógica del Botón "Guardar Turno" ---
        private void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            // 1. Doble chequeo: ¿Realmente tenemos un paciente seleccionado?
            if (idPacienteEncontrado == 0)
            {
                MessageBox.Show("Debe buscar y encontrar un paciente válido antes de guardar un turno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 2. Validar que se haya elegido una hora
            if (cmbHora.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una hora válida del combo.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Obtener los datos del formulario
            // Tomamos el ID que guardamos cuando buscamos al paciente
            int idPaciente = idPacienteEncontrado;

            // Convertimos la fecha del DateTimePicker a un string simple (como en tu tabla)
            string fechaTurno = dtpFecha.Value.ToString("dd/MM/yyyy");

            // Tomamos la hora seleccionada del ComboBox
            string horaTurno = cmbHora.SelectedItem.ToString();

            // 4. LLAMAR AL TurnosDAO
            turnosDAO.GuardarTurno(idPaciente, fechaTurno, horaTurno);

            // 5. Feedback y limpieza
            MessageBox.Show("¡Turno guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarGrillaTurnos(); // Actualizamos el DGV
            LimpiarFormulario(); // Reseteamos la interfaz
        }

        // --- Métodos Auxiliares ---

        // Carga el DGV de Turnos
        private void CargarGrillaTurnos()
        {
            DataTable dt = turnosDAO.CargarTurnos();
            if (dt != null)
            {
                dtgTurnos.DataSource = dt;
            }
        }

        // Resetea la interfaz después de guardar
        private void LimpiarFormulario()
        {
            txtDniPaciente.Clear();
            lblNombrePaciente.Text = "Por favor, busque un DNI";
            lblNombrePaciente.ForeColor = Color.Black;
            idPacienteEncontrado = 0;
            btnGuardarTurno.Enabled = false;
            cmbHora.SelectedIndex = -1; // Deselecciona la hora
            dtpFecha.Value = DateTime.Now; // Resetea la fecha a "hoy"
        }

        // Opcional: Si el usuario borra el DNI, reseteamos
        private void txtDniPaciente_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDniPaciente.Text))
            {
                LimpiarFormulario();
            }
        }
    }
}