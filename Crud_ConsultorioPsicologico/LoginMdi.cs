namespace Crud_ConsultorioPsicologico
{
    public partial class LoginMdi : Form
    {
        public LoginMdi()
        {
            InitializeComponent();
        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            Form administradorForm = new Administrador();
            administradorForm.Show();
        }
    }
}
