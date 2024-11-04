using MetroFramework.Forms;
using poo_tp_29559.Repositories.Enumerators;
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    public partial class ChildForm : MetroForm
    {
        private readonly IController<IIdentifiable>? _controller;
        public FormTypes _formtype;

        public ChildForm(FormTypes formtype)
        {
            InitializeComponent();
            _formtype = formtype;
            _controller = CreateController();

            //Aproveita o enumerator para alterar o nome exibido do form.
            this.Text = formtype.ToString();
        }

        private IController<IIdentifiable>? CreateController()
        {
            return _formtype switch
            {
                FormTypes.Produtos => new ProdutoController(this) as IController<IIdentifiable>,
                FormTypes.Categorias => new CategoriaController(this) as IController<IIdentifiable>,
                FormTypes.Marcas => new MarcaController(this) as IController<IIdentifiable>,
                FormTypes.Clientes => new ClienteController(this) as IController<IIdentifiable>,
                _ => throw new ArgumentException("Tipo de objeto desconhecido.")
            };
        }


        /// <summary>
        /// Displays a list of items in the DataGridView.
        /// </summary>
        /// <param name="items">The list of items to display.</param>
        public void MostraItens(object items)
        {
            BindingSource bs = new BindingSource
            {
                DataSource = items
            };
            dgvItens.DataSource = bs;
            dgvItens.Refresh();

            // Esconde coluna 'ID' caso exista
            if (dgvItens.Columns.Contains("Id"))
            {
                dgvItens.Columns["Id"].Visible = false;
            }
            
            // Esconde coluna 'isParticular' (para clientes) caso exista
            if (dgvItens.Columns.Contains("IsParticular"))
            {
                dgvItens.Columns["IsParticular"].Visible = false;
            }
        }

    }
}
