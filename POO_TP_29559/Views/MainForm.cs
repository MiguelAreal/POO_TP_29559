/**
 * @file MainForm.cs
 * @brief Formul�rio principal da aplica��o.
 *
 * Este formul�rio atua como a interface central da aplica��o, permitindo
 * navega��o entre os v�rios formul�rios filhos e controlando o acesso 
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
     * @brief Formul�rio principal da aplica��o.
     * 
     * Gere a interface principal, exibindo sub-formul�rios conforme as op��es
     * selecionadas no menu. Implementa l�gica para restringir o acesso de acordo
     * com as permiss�es do utilizador.
     */
    public partial class MainForm : MetroForm
    {
        private readonly Utilizador _utilizadorLogado;

        /**
         * @brief Construtor do `MainForm`.
         * 
         * Inicializa os componentes do formul�rio, configura o estado inicial dos menus
         * e exibe as informa��es do utilizador atualmente autenticado.
         * 
         * @param utilizadorLogado O utilizador atualmente autenticado.
         */
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

        /**
         * @brief Configura os menus conforme as permiss�es do utilizador.
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
         * @brief Abre um formul�rio filho dentro do painel central.
         * 
         * Remove qualquer formul�rio existente no painel e exibe o novo formul�rio.
         * 
         * @param formFilho O formul�rio filho a ser exibido.
         */
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


        /**
         * @brief Gere o clique nos itens do menu principal.
         * 
         * Instancia o formul�rio correspondente ao item do menu selecionado
         * e o exibe no painel central.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void msMainForm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
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

            // Abre o formul�rio, se v�lido
            if (formFilho != null)
            {
                AbrirFormNoPanel(formFilho);
            }
        }

        /**
         * @brief Cria um formul�rio filho com base no tipo especificado.
         * 
         * @param tipoForm O tipo do formul�rio a ser criado.
         * @return Uma inst�ncia do formul�rio filho.
         */
        private Form CriarFormulario(FormTypes tipoForm)
        {
            return new ChildForm(tipoForm, _utilizadorLogado);
        }

        /**
         * @brief Evento associado ao clique no �cone do GitHub.
         * 
         * Abre o reposit�rio no Github no navegador predefinido.
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
