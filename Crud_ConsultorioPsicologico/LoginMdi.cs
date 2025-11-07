namespace Crud_ConsultorioPsicologico
{
    public partial class LoginMdi : Form
    {
        public LoginMdi()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Administrador Administrador = new Administrador();
            Administrador.Show();
        }
    }
}
