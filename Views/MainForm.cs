using MetroFramework.Components;
using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Views;

namespace poo_tp_29559
{
    public partial class MainForm : MetroForm
    {

        public MainForm()
        {
            InitializeComponent();

        }



        // Método para abrir formulários dentro do painel
        private void AbrirFormNoPanel(Form formFilho)
        {
            if (panelContainer.Controls.Count > 0)
                panelContainer.Controls[0].Dispose(); // Remove o form anterior, se houver

            formFilho.TopLevel = false;
            formFilho.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formFilho);
            formFilho.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void msMainForm_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Form? formFilho = null; // Declara o formFilho fora do switch

            switch (e.ClickedItem?.Text)
            {
                case "Produtos":
                    formFilho = new ProdutosForm();
                    break;
                case "Categorias":
                    formFilho = new CategoriasForm();
                    break;
                case "Marcas":
                    formFilho = new MarcasForm();
                    break;
                default:
                    MessageBox.Show("Opção desconhecida");
                    return; // Sai do método
            }

            if (formFilho != null)
            {
                AbrirFormNoPanel(formFilho); // Abre o formulário no painel
            }
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
