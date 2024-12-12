using ValidationLibrary;

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
            bool allvalid = true;

            // Valida o NIF (já tratado pela validação de nove dígitos)
            allvalid &= FieldValidator.ValidateNineDigits(txtNIF.Text, imgUser, Color.FromArgb(9, 171, 219));

            // Valida outros campos (exemplo com password)
            allvalid &= FieldValidator.ValidateFields(new Control[] { txtPassword }, new Label[] { imgPwd }, Color.FromArgb(9, 171, 219));

            // Se algum campo não for válido, interrompe
            if (!allvalid)
            {
                return;
            }

            // Agora, o NIF já foi validado, e não precisamos de convertê-lo
            int NIF = Convert.ToInt32(txtNIF.Text);  // A conversão aqui é segura, pois a validação anterior já garante que é um número

            string password = txtPassword.Text;

            // Verifica se o login é válido
            if (_controller.VerificarLogin(NIF, password))
            {
                // Obtém o utilizador autenticado
                var utilizadorAtual = _controller.ObterUtilizadorPorNIF(NIF);

                // Passa o utilizador atual para o MainForm
                MainForm mainForm = new MainForm(utilizadorAtual);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Se o login falhar, exibe uma mensagem de erro
                MessageBox.Show("Utilizador ou palavra-passe inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
