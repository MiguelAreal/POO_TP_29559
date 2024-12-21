using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /// <summary>
    /// View responsável pelo formulário de login.
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Private Fields

        /// <summary>
        /// Controlador para manipulação dos utilizadores.
        /// </summary>
        private UtilizadorController _controller;

        #endregion

        #region Constructors

        /// <summary>
        /// Construtor da classe `LoginForm`.
        /// </summary>
        /// <remarks>
        /// Inicializa os componentes visuais do formulário e instancia o controlador.
        /// </remarks>
        public LoginForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Evento para fechar a aplicação.
        /// </summary>
        /// <param name="sender">Objeto que dispara o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Alterna a visibilidade da palavra-passe.
        /// </summary>
        /// <param name="sender">Objeto que dispara o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        /// <summary>
        /// Abre o formulário de registo.
        /// </summary>
        /// <param name="sender">Objeto que dispara o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void lblRegisteAqui_Click(object sender, EventArgs e)
        {
            SignupForm FormRegisto = new SignupForm();
            FormRegisto.Show();
            this.Hide();
        }

        /// <summary>
        /// Valida os campos e realiza o login.
        /// </summary>
        /// <param name="sender">Objeto que dispara o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool allvalid = true;

            // Validação do NIF (garante nove dígitos)
            allvalid &= FieldValidator.ValidateNineDigits(txtNIF.Text, imgUser, Color.FromArgb(9, 171, 219));

            // Validação da palavra-passe
            allvalid &= FieldValidator.ValidateFields(new Control[] { txtPassword }, new Label[] { imgPwd }, Color.FromArgb(9, 171, 219));

            // Interrompe se houver validações inválidas
            if (!allvalid)
            {
                return;
            }

            // Conversão segura do NIF após validação
            int NIF = Convert.ToInt32(txtNIF.Text);
            string password = txtPassword.Text;

            // Verifica as credenciais
            if (_controller.VerificarLogin(NIF, password))
            {
                // Obtém o utilizador autenticado e abre o MainForm
                var utilizadorAtual = _controller.ObterUtilizadorPorNIF(NIF);
                MainForm mainForm = new MainForm(utilizadorAtual);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Exibe mensagem de erro no caso de falha
                MessageBox.Show("Utilizador ou palavra-passe inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
