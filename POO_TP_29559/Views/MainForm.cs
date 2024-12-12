using MetroFramework.Components;
using MetroFramework.Forms; 
using poo_tp_29559.Models;   
using poo_tp_29559.Views;
using poo_tp_29559.Repositories.Enumerators;

namespace poo_tp_29559
{
    /// <summary>
    /// Classe principal do formulário da aplicação, que herda de <see cref="MetroForm"/>.
    /// Este form serve como o ponto de entrada da aplicação e gere a navegação entre outros forms.
    /// </summary>
    public partial class MainForm : MetroForm
    {
        /// <summary>
        /// Construtor da classe <see cref="MainForm"/> que inicializa os componentes do form.
        /// </summary>
        public MainForm()
        {
            // Inicializa os componentes do formulário
            InitializeComponent();
        }

        /// <summary>
        /// Método que abre um form dentro do painel central específico.
        /// Se um form já estiver aberto, ele é removido antes de abrir o novo.
        /// </summary>
        /// <param name="formFilho">O formulário filho a ser aberto no painel.</param>
        private void AbrirFormNoPanel(Form formFilho)
        {
            // Verifica se já existe um form no painel e remove-o, se necessário
            // Indexado em 1, devido à picture box que já existe no panel.

            if (panelContainer.Controls.Count > 1)
                panelContainer.Controls[1].Dispose();

            //  Esconde imagem de fundo
            picBg.Hide();

            // Adiciona um Evento de ao fechar do formulário filho
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
        /// Evento chamado quando o formulário é carregado.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Evento chamado quando um item do menu principal é clicado.
        /// Abre o formulário correspondente ao item clicado.
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
                    formFilho = new ChildForm(FormTypes.Produtos);
                    break;
                case "Categorias":
                    formFilho = new ChildForm(FormTypes.Categorias);
                    break;
                case "Marcas":
                    formFilho = new ChildForm(FormTypes.Marcas);
                    break;
                case "Clientes":
                    formFilho = new ChildForm(FormTypes.Clientes);
                    break;
                case "Campanhas":
                    formFilho = new ChildForm(FormTypes.Campanhas);
                    break;
                case "Vendas":
                    formFilho = new ChildForm(FormTypes.Vendas);
                    break;
                default:
                    MessageBox.Show("Opção desconhecida");
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
