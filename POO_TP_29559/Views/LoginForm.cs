/**
 * @file LoginForm.cs
 * @brief Formulário de Login da aplicação.
 *
 * Esta classe representa o formulário de login da aplicação, responsável
 * por capturar as credenciais do utilizador, validá-las e proceder à autenticação.
 * Também permite aceder ao formulário de registo e alternar a visibilidade da palavra-passe.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using ValidationLibrary;

namespace poo_tp_29559.Views
{
    /**
     * @class LoginForm
     * @brief View responsável pelo formulário de login.
     * 
     * A View `LoginForm` fornece a interface gráfica para o utilizador introduzir
     * o NIF e a palavra-passe. Inclui validações de entrada, manipulação de eventos
     * de botões e integração com o `UtilizadorController` para autenticação.
     */
    public partial class LoginForm : Form
    {
        /// @brief Controlador para manipulação dos utilizadores.
        private UtilizadorController _controller;

        /**
         * @brief Construtor da classe `LoginForm`.
         * 
         * Inicializa os componentes visuais do formulário e instancia o controlador.
         */
        public LoginForm()
        {
            InitializeComponent();
            _controller = new UtilizadorController();
        }

        /**
         * @brief Evento para fechar a aplicação.
         * 
         * Executado quando o botão "Sair" é clicado.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * @brief Alterna a visibilidade da palavra-passe.
         * 
         * Este método alterna entre ocultar e mostrar os caracteres da palavra-passe
         * no campo de texto, alterando a propriedade `UseSystemPasswordChar`.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
        private void btnHidePwd_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        /**
         * @brief Abre o formulário de registo.
         * 
         * Quando o utilizador clica em "Registe Aqui", o formulário de registo
         * (`SignupForm`) é instanciado e exibido, enquanto o formulário de login
         * é ocultado.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
        private void lblRegisteAqui_Click(object sender, EventArgs e)
        {
            SignupForm FormRegisto = new SignupForm();
            FormRegisto.Show();
            this.Hide();
        }

        /**
         * @brief Valida os campos e realiza o login.
         * 
         * Este método valida o NIF e a palavra-passe introduzidos pelo utilizador
         * usando a biblioteca `ValidationLibrary`. Se os campos forem válidos, 
         * verifica as credenciais utilizando o `UtilizadorController`.
         * Em caso de sucesso, abre o `MainForm` e passa o utilizador autenticado.
         * Caso contrário, exibe uma mensagem de erro.
         * 
         * @param sender Objeto que dispara o evento.
         * @param e Argumentos do evento.
         */
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
    }
}
