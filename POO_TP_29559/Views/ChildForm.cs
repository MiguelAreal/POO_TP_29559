using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories.Enumerators;
using System;
using System.Drawing; // Make sure to include this for Color
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    public partial class ChildForm : MetroForm
    {
        private readonly IEntityController _controller;
        private readonly FormTypes _formType; // Private for encapsulation
        private string? _activeColumn;
        private int _previousColumnIndex = -1;

        public ChildForm(FormTypes formType)
        {
            InitializeComponent();
            _formType = formType;
            _controller = CreateController();
            _controller.Initialize();
            Text = _formType.ToString();
        }

        private IEntityController CreateController()
        {
            return _formType switch
            {
                FormTypes.Produtos => new ProdutoController(this),
                FormTypes.Categorias => new CategoriaController(this),
                FormTypes.Marcas => new MarcaController(this),
                FormTypes.Clientes => new ClienteController(this),
                _ => throw new ArgumentException("Unknown object type.")
            };
        }

        public void MostraItens(object items)
        {
            // Store current selected column index
            int currentColumnIndex = dgvItens.CurrentCell?.ColumnIndex ?? -1;

            // Set DataSource and refresh DataGridView
            dgvItens.DataSource = new BindingSource { DataSource = items };
            dgvItens.Refresh();

            // Restore the selected cell if valid
            if (currentColumnIndex >= 0 && dgvItens.Rows.Count > 0 && currentColumnIndex < dgvItens.Columns.Count)
            {
                dgvItens.CurrentCell = dgvItens.Rows[0].Cells[currentColumnIndex];
            }

            // Hide specific columns if they exist
            ToggleColumnVisibility("Id", false);
            ToggleColumnVisibility("IsParticular", false);
        }

        private void ToggleColumnVisibility(string columnName, bool isVisible)
        {
            if (dgvItens.Columns.Contains(columnName))
            {
                dgvItens.Columns[columnName].Visible = isVisible;
            }
        }

        private void ChangeButtonColor(Control button, Color color)
        {
            button.ForeColor = color;
        }

        private void btnRemItem_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnRemItem, Color.Red);
        private void btnRemItem_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnRemItem, Color.Black);
        private void btnAddItem_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnAddItem, Color.DodgerBlue);
        private void btnAddItem_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnAddItem, Color.Black);

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            _controller.FiltrarItens(txtSearchItem.Text, _activeColumn);
            RestoreCurrentCell();
        }

        private void RestoreCurrentCell()
        {
            if (dgvItens.Rows.Count > 0)
            {
                int currentColumnIndex = dgvItens.Columns[_activeColumn]?.Index ?? -1;
                dgvItens.CurrentCell = currentColumnIndex >= 0 && currentColumnIndex < dgvItens.Columns.Count
                    ? dgvItens.Rows[0].Cells[currentColumnIndex]
                    : dgvItens.Rows[0].Cells[0]; // Fallback to the first cell
            }
        }

        private void dgvItens_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvItens.CurrentCell != null)
            {
                int currentColumnIndex = dgvItens.CurrentCell.ColumnIndex;

                if (currentColumnIndex != _previousColumnIndex)
                {
                    _activeColumn = dgvItens.Columns[currentColumnIndex].Name;
                    _previousColumnIndex = currentColumnIndex;
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Form addForm;

            // Determine which form to open based on the current form type
            switch (_formType)
            {
                case FormTypes.Produtos:
                    addForm = new AddProdutoForm(this);
                    break;
                case FormTypes.Categorias:
                    addForm = new AddCategoriaForm(this);
                    break;
                case FormTypes.Marcas:
                    addForm = new AddMarcaForm(this);
                    break;
                /*case FormTypes.Clientes:
                    addForm = new AddClienteForm(this);
                    break;*/
                default:
                    MessageBox.Show("Unknown form type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit if the form type is unknown
            }

            // Open the form as a dialog
            using (addForm)
            {
                addForm.ShowDialog();
            }

            // Reload items after the add form is closed
            _controller.CarregaItens();
        }

        private void btnRemItem_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (dgvItens.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the selected row index
                    int rowIndex = dgvItens.SelectedRows[0].Index;

                    // Get the selected item
                    var selectedItem = dgvItens.Rows[rowIndex].DataBoundItem;

                    switch (_formType)
                    {
                        case FormTypes.Produtos:
                            if (selectedItem is ProdutoViewModel produtoSelecionado)
                            {
                                var produto = _controller.GetById(produtoSelecionado.Id); // Fetch the actual Produto
                                _controller.DeleteItem(produto); // Delete the item
                            }
                            break;

                        case FormTypes.Marcas:
                            if (selectedItem is Marca marcaSelecionada)
                            {
                                _controller.DeleteItem(marcaSelecionada); // Delete the item
                            }
                            break;

                        case FormTypes.Categorias:
                            if (selectedItem is Categoria categoriaSelecionada)
                            {
                                _controller.DeleteItem(categoriaSelecionada); // Delete the item
                            }
                            break;

                        case FormTypes.Clientes:
                            if (selectedItem is Cliente clienteSelecionado)
                            {
                                _controller.DeleteItem(clienteSelecionado); // Delete the item
                            }
                            break;

                        default:
                            MessageBox.Show("Unknown form type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit if the form type is unknown
                    }

                    // Refresh the list after deletion
                    _controller.CarregaItens();
                }
                catch (Exception ex)
                {
                    // Display an error message if an exception occurs
                    MessageBox.Show($"Error while removing item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
