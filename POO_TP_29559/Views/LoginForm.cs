namespace poo_tp_29559.Views
{
    public partial class LoginForm : Form
    {
        private UtilizadorController _controller;

        public LoginForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void lblRegisteAqui_Click(object sender, EventArgs e)
        {
            // Create an instance of the registration form
            SignupForm FormRegisto = new SignupForm();
            FormRegisto.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPassword.Text;

            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();


            // Verifica se o login é válido
            if (_controller.VerificarLogin(username, password))
            {
                /*MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();*/
            }
            else
            {
                // Se o login falhar, exibe uma mensagem de erro
                MessageBox.Show("Utilizador ou palavra-passe inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
