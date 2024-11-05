using MetroFramework.Components;
using MetroFramework.Forms; 
using poo_tp_29559.Controllers;
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
        /// <summary>
        /// Construtor da classe <see cref="MainForm"/> que inicializa os componentes do form.
        /// </summary>
        public MainForm()
        {
            // Inicializa os componentes do formul�rio
            InitializeComponent();
        }

        /// <summary>
        /// M�todo que abre um form dentro do painel central espec�fico.
        /// Se um form j� estiver aberto, ele � removido antes de abrir o novo.
        /// </summary>
        /// <param name="formFilho">O formul�rio filho a ser aberto no painel.</param>
        private void AbrirFormNoPanel(Form formFilho)
        {
            // Verifica se j� existe um form no painel e remove-o, se necess�rio
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls[0].Dispose();

            // Configura as propriedades do form filho e mostra-o
            formFilho.TopLevel = false;
            formFilho.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formFilho);
            formFilho.Show();
        }

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
    }
}
