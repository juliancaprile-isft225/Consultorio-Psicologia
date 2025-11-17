using System;
using System.Data;
using System.Windows.Forms;
using Crud_ConsultorioPsicologico.Clases;
using MySql.Data.MySqlClient;

namespace Crud_ConsultorioPsicologico
{
    public partial class UC_RegistroPacientes : UserControl
    {
        private PacienteDAO pacienteDAO = new PacienteDAO();

       
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

                // Validación de que DNI y Telefono sean números
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


        /*
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

        */

        // Evento Load del UserControl (para cargar datos al iniciar)
        private void UC_RegistroPacientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        // Evento Click del DataGridView (para cargar datos en los TextBox)
        private void dtgRegistroPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // CargarCamposDesdeDGV();
        }

        // fin de las clases

        // eventoss


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPaciente();
        }

        /*
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
        */

        // MODIFICAMOS LOS DATOS DESDE EL DTV
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //  Validar que la grilla tenga datos
            if (dtgRegistroPaciente.DataSource == null)
            {
                MessageBox.Show("No hay datos cargados para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  ObtenE la DataTable que estA "atada" al DGV
            // (Esta tabla contiene los cambios que el usuario hizo en la grilla)
            DataTable dt = (DataTable)dtgRegistroPaciente.DataSource;

            // 3 OBTENEMOS SOLO LAS FILAS MODIFICADAS
            // FUNCION GETCHANGES 
            //ROW STATE REPRESENTA EL ESTADO DE LA FILA
            DataTable dtChanges = dt.GetChanges(DataRowState.Modified);

            // 4 Si no hay cambios, no hacer nada
            if (dtChanges == null)
            {
                MessageBox.Show("No se detectaron cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 5. Si hay cambios, recorrerlos uno por uno y actualizarlos en la DB
            int filasActualizadas = 0;
            try
            {
                // Recorremos la mini-tabla dtChanges
                foreach (DataRow row in dtChanges.Rows)
                {
                    // Extraer datos de la fila (igual que en el CellValueChanged)
                    // Usamos 'row' (la fila de la tabla de cambios)
                    int idPaciente = Convert.ToInt32(row["Id_Paciente"]);
                    string fechaNac = row["Fecha_Nacimiento"].ToString();
                    int dni = int.Parse(row["Dni"].ToString());
                    int telefono = int.Parse(row["Telefono"].ToString());

                    Paciente paciente = new Paciente
                    {
                        IdPaciente = idPaciente,
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        Motivo = row["Motivo_Consulta"].ToString(),
                        Correo = row["Correo"].ToString()
                    };

                    // Llamar al DAO por CADA fila cambiada
                    
                    pacienteDAO.Actualizar(paciente, fechaNac, dni, telefono);
                    filasActualizadas++;
                }

                // 6. "Confirmar" los cambios en la tabla en memoria 
                // Esto le dice a la DataTable que los cambios ya se guardaron en la DB
                dt.AcceptChanges();

                MessageBox.Show($"¡Éxito! Se actualizaron {filasActualizadas} filas.", "Actualización por Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato en una de las filas editadas: DNI o Teléfono deben ser números.\n" + ex.Message, "Error de Lote", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshacer cambios en la grilla si algo falló
                dt.RejectChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la actualización por lotes: " + ex.Message, "Error de Lote", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshacer cambios en la grilla si algo falló
                dt.RejectChanges();
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