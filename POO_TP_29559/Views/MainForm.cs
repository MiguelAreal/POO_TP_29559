using MetroFramework.Forms;
using poo_tp_29559.Views;
using poo_tp_29559.Repositories.Enumerators;
using poo_tp_29559.Models;

namespace poo_tp_29559
{
    /// <summary>
    /// Formul�rio principal da aplica��o.
    /// </summary>
    public partial class MainForm : MetroForm
    {
        #region Private Fields

        /// <summary>
        /// O utilizador atualmente autenticado.
        /// </summary>
        private readonly Utilizador _utilizadorLogado;

        #endregion

        #region Construtors

        /// <summary>
        /// Construtor do `MainForm`.
        /// </summary>
        /// <param name="utilizadorLogado">O utilizador atualmente autenticado.</param>
        /// <remarks>
        /// Inicializa os componentes do formul�rio, configura o estado inicial dos menus
        /// e exibe as informa��es do utilizador atualmente autenticado.
        /// </remarks>
        public MainForm(Utilizador utilizadorLogado)
        {
            InitializeComponent();
            _utilizadorLogado = utilizadorLogado;

            // Configura informa��es vis�veis do utilizador autenticado
            string tipoUser = _utilizadorLogado.IsAdmin ? "Administrador" : "Cliente";
            lblUserInfo.Text = $"{_utilizadorLogado.Nome}\n{tipoUser}";

            // Configura visibilidade dos menus com base no tipo de utilizador
            ConfigurarMenus();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configura os menus conforme as permiss�es do utilizador.
        /// </summary>
        /// <remarks>
        /// Esconde os menus "Vendas" e "Utilizadores" para clientes
        /// e esconde "Compras" para administradores.
        /// </remarks>
        private void ConfigurarMenus()
        {
            if (_utilizadorLogado.IsAdmin)
            {
                comprasTSMI.Visible = false;
            }
            else
            {
                vendasTSMI.Visible = false;
                utilizadoresTSMI.Visible = false;
            }
        }

        /// <summary>
        /// Abre um formul�rio filho dentro do painel central.
        /// </summary>
        /// <param name="formFilho">O formul�rio filho a ser exibido.</param>
        private void AbrirFormNoPanel(Form formFilho)
        {
            // Remove formul�rio existente no painel, se houver
            if (panelContainer.Controls.Count > 1)
                panelContainer.Controls[1].Dispose();

            // Esconde a imagem de fundo
            picBg.Hide();

            // Configura evento ao fechar o formul�rio, para voltar a mostrar a imagem de fundo.
            formFilho.FormClosed += (s, args) => picBg.Show();

            // Configura e exibe o formul�rio filho
            formFilho.TopLevel = false;
            formFilho.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formFilho);
            formFilho.Show();
        }

        /// <summary>
        /// Cria um formul�rio filho com base no tipo especificado.
        /// </summary>
        /// <param name="tipoForm">O tipo do formul�rio a ser criado.</param>
        /// <returns>Uma inst�ncia do formul�rio filho.</returns>
        private Form CriarFormulario(FormTypes tipoForm)
        {
            return new ChildForm(tipoForm, _utilizadorLogado);
        }

        #endregion

        #region Menu Events

        /// <summary>
        /// Evento associado ao clique nos itens do menu principal.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        /// <remarks>
        /// Instancia o formul�rio correspondente ao item do menu selecionado
        /// e o exibe no painel central.
        /// </remarks>
        private void msMainForm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Reset nas cores de todos os itens.
            for (int i = 0; i < msMainForm.Items.Count; i++)
            {
                msMainForm.Items[i].ForeColor = Color.Black;
                msMainForm.Items[i].BackColor = Color.Transparent;
            }

            Form? formFilho = null;

            // Determina o formul�rio a abrir com base no item selecionado
            switch (e.ClickedItem?.Text)
            {
                case "Produtos":
                    formFilho = CriarFormulario(FormTypes.Produtos);
                    break;
                case "Categorias":
                    formFilho = CriarFormulario(FormTypes.Categorias);
                    break;
                case "Marcas":
                    formFilho = CriarFormulario(FormTypes.Marcas);
                    break;
                case "Utilizadores":
                    formFilho = CriarFormulario(FormTypes.Utilizadores);
                    break;
                case "Campanhas":
                    formFilho = CriarFormulario(FormTypes.Campanhas);
                    break;
                case "Vendas":
                    formFilho = CriarFormulario(FormTypes.Vendas);
                    break;
                case "Compras":
                    formFilho = CriarFormulario(FormTypes.Compras);
                    break;
                default:
                    MessageBox.Show("Op��o desconhecida.");
                    return;
            }

            // Muda a cor do item selecionado.
            e.ClickedItem.ForeColor = Color.White;
            e.ClickedItem.BackColor = Color.FromArgb(9, 171, 219);

            // Abre o formul�rio, se v�lido
            if (formFilho != null)
            {
                AbrirFormNoPanel(formFilho);
            }
        }

        #endregion

        #region External Events

        /// <summary>
        /// Evento associado ao clique no �cone do GitHub.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        /// <remarks>
        /// Abre o reposit�rio no Github no navegador predefinido.
        /// </remarks>
        private void github_Click(object sender, EventArgs e)
        {
            try
            {
                var processStartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/MiguelAreal/POO_TP_29559",
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
