using MetroFramework.Components;
using MetroFramework.Forms; 
using poo_tp_29559.Models;   
using poo_tp_29559.Views;
using poo_tp_29559.Repositories.Enumerators;

namespace poo_tp_29559
{
    /// <summary>
    /// Classe principal do formul�rio da aplica��o, que herda de <see cref="MetroForm"/>.
    /// Este form serve como o ponto de entrada da aplica��o e gere a navega��o entre outros forms.
    /// </summary>
    public partial class MainForm : MetroForm
    {
        private readonly Utilizador _utilizadorLogado;
        /// <summary>
        /// Construtor da classe <see cref="MainForm"/> que inicializa os componentes do form.
        /// </summary>
        public MainForm(Utilizador utilizadorLogado)
        {
            // Inicializa os componentes do formul�rio
            InitializeComponent();
            _utilizadorLogado = utilizadorLogado;
            string tipoUser = _utilizadorLogado.IsAdmin ? "Administrador" : "Cliente";
            lblUserInfo.Text = $"{_utilizadorLogado.Nome}\n{tipoUser}";

            // Verifica se o utilizador � admin ou cliente
            if (!_utilizadorLogado.IsAdmin)
            {
                // Esconde os itens de menu que n�o devem ser acess�veis por um cliente
                // Vendas e Clientes
                vendasTSMI.Visible = false;
                clientesTSMI.Visible = false;
            }
            else
            {   
                // Esconde os itens de menu que n�o devem ser acess�veis por um administrador (porque � in�til)
                // Vendas e Clientes
                comprarTSMI.Visible = false;
            }
        }

        /// <summary>
        /// M�todo que abre um form dentro do painel central espec�fico.
        /// Se um form j� estiver aberto, ele � removido antes de abrir o novo.
        /// </summary>
        /// <param name="formFilho">O formul�rio filho a ser aberto no painel.</param>
        private void AbrirFormNoPanel(Form formFilho)
        {
            // Verifica se j� existe um form no painel e remove-o, se necess�rio
            // Indexado em 1, devido � picture box que j� existe no panel.

            if (panelContainer.Controls.Count > 1)
                panelContainer.Controls[1].Dispose();

            //  Esconde imagem de fundo
            picBg.Hide();

            // Adiciona um Evento de ao fechar do formul�rio filho
            formFilho.FormClosed += (s, args) =>
            {
                // Mostra a imagem de fundo novamente
                picBg.Show();
            };


            // Configura as propriedades do form filho e mostra-o
            formFilho.TopLevel = false;
            formFilho.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formFilho);
            formFilho.Show();
        }

        /// <summary>
        /// Evento chamado quando o formul�rio � carregado.
        /// </summary>
        /// <summary>
        /// Evento chamado quando o formul�rio � carregado.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Evento chamado quando um item do menu principal � clicado.
        /// Abre o formul�rio correspondente ao item clicado.
        /// </summary>
        /// <param name="sender">O objeto que gerou o evento.</param>
        /// <param name="e">Os dados do evento.</param>
        private void msMainForm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form? formFilho = null; // Declara o formFilho fora do switch

            // Verifica qual item do menu foi clicado e instancia o form correspondente
            switch (e.ClickedItem?.Text)
            {
                case "Produtos":
                    formFilho = new ChildForm(FormTypes.Produtos, _utilizadorLogado.IsAdmin);
                    break;
                case "Categorias":
                    formFilho = new ChildForm(FormTypes.Categorias, _utilizadorLogado.IsAdmin);
                    break;
                case "Marcas":
                    formFilho = new ChildForm(FormTypes.Marcas, _utilizadorLogado.IsAdmin);
                    break;
                case "Clientes":
                    formFilho = new ChildForm(FormTypes.Clientes, _utilizadorLogado.IsAdmin);
                    break;
                case "Campanhas":
                    formFilho = new ChildForm(FormTypes.Campanhas, _utilizadorLogado.IsAdmin);
                    break;
                case "Vendas":
                    formFilho = new ChildForm(FormTypes.Vendas, _utilizadorLogado.IsAdmin);
                    break;
                default:
                    MessageBox.Show("Op��o desconhecida");
                    return;
            }

            // Abre-o no painel
            if (formFilho != null)
            {
                AbrirFormNoPanel(formFilho);
            }
        }

        private void github_Click(object sender, EventArgs e)
        {
            try
            {
                var processStartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/MiguelAreal/POO_TP_29559",
                    UseShellExecute = true // Ensures the URL is opened using the default browser
                };
                System.Diagnostics.Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
