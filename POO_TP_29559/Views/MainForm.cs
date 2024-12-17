/**
 * @file MainForm.cs
 * @brief Formulário principal da aplicação.
 *
 * Este formulário atua como a interface central da aplicação, permitindo
 * navegação entre os vários formulários filhos e controlando o acesso 
 * baseado no tipo de utilizador (Administrador ou Cliente).
 * Utiliza a biblioteca MetroFramework para um design moderno.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using MetroFramework.Forms;
using poo_tp_29559.Views;
using poo_tp_29559.Repositories.Enumerators;

namespace poo_tp_29559
{
    /**
     * @class MainForm
     * @brief Formulário principal da aplicação.
     * 
     * Gere a interface principal, exibindo sub-formulários conforme as opções
     * selecionadas no menu. Implementa lógica para restringir o acesso de acordo
     * com as permissões do utilizador.
     */
    public partial class MainForm : MetroForm
    {
        private readonly Utilizador _utilizadorLogado;

        /**
         * @brief Construtor do `MainForm`.
         * 
         * Inicializa os componentes do formulário, configura o estado inicial dos menus
         * e exibe as informações do utilizador atualmente autenticado.
         * 
         * @param utilizadorLogado O utilizador atualmente autenticado.
         */
        public MainForm(Utilizador utilizadorLogado)
        {
            InitializeComponent();
            _utilizadorLogado = utilizadorLogado;

            // Configura informações visíveis do utilizador autenticado
            string tipoUser = _utilizadorLogado.IsAdmin ? "Administrador" : "Cliente";
            lblUserInfo.Text = $"{_utilizadorLogado.Nome}\n{tipoUser}";

            // Configura visibilidade dos menus com base no tipo de utilizador
            ConfigurarMenus();
        }

        /**
         * @brief Configura os menus conforme as permissões do utilizador.
         * 
         * Esconde os menus "Vendas" e "Utilizadores" para clientes
         * e esconde "Compras" para administradores.
         */
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

        /**
         * @brief Abre um formulário filho dentro do painel central.
         * 
         * Remove qualquer formulário existente no painel e exibe o novo formulário.
         * 
         * @param formFilho O formulário filho a ser exibido.
         */
        private void AbrirFormNoPanel(Form formFilho)
        {
            // Remove formulário existente no painel, se houver
            if (panelContainer.Controls.Count > 1)
                panelContainer.Controls[1].Dispose();

            // Esconde a imagem de fundo
            picBg.Hide();

            // Configura evento ao fechar o formulário, para voltar a mostrar a imagem de fundo.
            formFilho.FormClosed += (s, args) => picBg.Show();

            // Configura e exibe o formulário filho
            formFilho.TopLevel = false;
            formFilho.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formFilho);
            formFilho.Show();
        }


        /**
         * @brief Gere o clique nos itens do menu principal.
         * 
         * Instancia o formulário correspondente ao item do menu selecionado
         * e o exibe no painel central.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void msMainForm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form? formFilho = null;

            // Determina o formulário a abrir com base no item selecionado
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
                    MessageBox.Show("Opção desconhecida.");
                    return;
            }

            // Abre o formulário, se válido
            if (formFilho != null)
            {
                AbrirFormNoPanel(formFilho);
            }
        }

        /**
         * @brief Cria um formulário filho com base no tipo especificado.
         * 
         * @param tipoForm O tipo do formulário a ser criado.
         * @return Uma instância do formulário filho.
         */
        private Form CriarFormulario(FormTypes tipoForm)
        {
            return new ChildForm(tipoForm, _utilizadorLogado);
        }

        /**
         * @brief Evento associado ao clique no ícone do GitHub.
         * 
         * Abre o repositório no Github no navegador predefinido.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
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
    }
}
