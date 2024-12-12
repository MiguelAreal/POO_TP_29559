using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories.Enumerators;
using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    public partial class ChildForm : MetroForm
    {
        private readonly IEntityController _controller;
        private readonly FormTypes _formType;
        private string? _activeColumn;
        private int _previousColumnIndex = -1;
        object items;

        public ChildForm(FormTypes formType)
        {
            InitializeComponent();
            _formType = formType;
            _controller = CreateController();
            changeSettings(formType);
            
            MostraItens();
                        
        }

        //  Dependendo do form ativo, Altera o ícone de adicionar item.
        public void changeSettings(FormTypes formType)
        {
            // Por defeito este botão não é visível, ao recarregar mantém-no como invisível.
            btnSeeVenda.Visible = false;

            // Título do form
            Text = _formType.ToString();
            switch (formType)
            {
                case FormTypes.Vendas:
                    btnAdd.Text = "$";
                    btnSeeVenda.Visible = true;
                    dgvItens.ReadOnly = true;
                    break;
                case FormTypes.Clientes:
                    btnAdd.Text = "👤";
                break;
                
            }
        }

        // Inicialização de controladores dependendo do tipo de form ativo.
        private IEntityController CreateController()
        {
            return _formType switch
            {
                FormTypes.Produtos => new ProdutoController(),
                FormTypes.Categorias => new CategoriaController(),
                FormTypes.Marcas => new MarcaController(),
                FormTypes.Clientes => new UtilizadorController(),
                FormTypes.Campanhas => new CampanhaController(),
                FormTypes.Vendas => new VendaController(),
                _ => throw new ArgumentException("FormType desconhecido.")
            };
        }

        public void MostraItens()
        {
            items = _controller.GetItems();

            //  Guarda index na coluna selecionada
            int currentColumnIndex = dgvItens.CurrentCell?.ColumnIndex ?? -1;

            // Atribui DataSource e atualiza DataGridView
            dgvItens.DataSource = new BindingSource { DataSource = items };
            dgvItens.Refresh();

            // Configurar SortMode para todas as colunas
            foreach (DataGridViewColumn column in dgvItens.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic; 
            }

            // Restaura a célula selecionada, se for válida.
            if (currentColumnIndex >= 0 && dgvItens.Rows.Count > 0 && currentColumnIndex < dgvItens.Columns.Count)
            {
                dgvItens.CurrentCell = dgvItens.Rows[0].Cells[currentColumnIndex];
            }

            // Esconde propriedades não relevantes em termos visuais.
            ToggleColumnVisibility("Id", false);
            ToggleColumnVisibility("IsParticular", false);
            ToggleColumnVisibility("IsAdmin", false);
            ToggleColumnVisibility("Password", false);

        }

        // Esconde da DataGridView dados não relevantes em termos visuais.
        private void ToggleColumnVisibility(string columnName, bool isVisible)
        {
            if (dgvItens.Columns.Contains(columnName))
            {
                dgvItens.Columns[columnName].Visible = isVisible;
            }
        }

        // Altera a cor de botão passado por parâmetro, para uma cor passada por parâmetro.
        private void ChangeButtonColor(Control button, Color color)
        {
            button.ForeColor = color;
        }

        // Eventos para alterar a cor de botões de adicionar e remover, ao passar o rato por cima.
        private void btnRem_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnRem, Color.Red);
        private void btnRem_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnRem, Color.Black);
        private void btnAdd_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnAdd, Color.DodgerBlue);
        private void btnAdd_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnAdd, Color.Black);
        private void btnSeeVenda_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnSeeVenda, Color.DodgerBlue);
        private void btnSeeVenda_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnSeeVenda, Color.Black);


        // Evento da caixa de pesquisa, executa função de filtrar itens do controlador relevante.
        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            _controller.FiltrarItens(txtSearchItem.Text, _activeColumn);
            RestoreCurrentCell();
        }

        // Usado para restaurar a célula atual, utilizado após pesquisa para manter integridade de seleção.
        private void RestoreCurrentCell()
        {
            if (dgvItens.Rows.Count > 0)
            {
                int currentColumnIndex = dgvItens.Columns[_activeColumn]?.Index ?? -1;
                dgvItens.CurrentCell = currentColumnIndex >= 0 && currentColumnIndex < dgvItens.Columns.Count
                    ? dgvItens.Rows[0].Cells[currentColumnIndex]
                    : dgvItens.Rows[0].Cells[0]; // Fallback para primeira célula
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


        // Para atualizar dados de uma célula.
        private void dgvItens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Tenta obter o item editado com base na linha e coluna alteradas
            try
            {
                // Certifica-se de que a linha e a coluna são válidas
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvItens.Rows.Count)
                {
                    var selectedItem = dgvItens.Rows[e.RowIndex].DataBoundItem;

                    // Verifica o tipo de item e faz a conversão
                    switch (_formType)
                    {
                        case FormTypes.Produtos:
                            if (selectedItem is ProdutoViewModel produtoSelecionado)
                            {
                                //_controller.UpdateItem(produto);
                            }
                            break;

                        case FormTypes.Marcas:
                            if (selectedItem is Marca marcaSelecionada)
                            {
                                _controller.UpdateItem(marcaSelecionada);
                            }
                            break;

                        case FormTypes.Categorias:
                            if (selectedItem is Categoria categoriaSelecionada)
                            {
                                _controller.UpdateItem(categoriaSelecionada);
                            }
                            break;

                        case FormTypes.Clientes:
                            if (selectedItem is Utilizador clienteSelecionado)
                            {
                                _controller.UpdateItem(clienteSelecionado);
                            }
                            break;

                        case FormTypes.Campanhas:
                            if (selectedItem is Campanha campanhaSelecionada)
                            {
                                _controller.UpdateItem(campanhaSelecionada);
                            }
                            break;
                        default:
                            MessageBox.Show("FormType desconhecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                }
            }
            // Trata o caso em que a linha ou coluna não é válida
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Selecione uma célula válida para editar.");
            }
            // Trata o caso em que a conversão do valor não é válida
            catch (InvalidCastException)
            {
                MessageBox.Show("Erro ao tentar atualizar o item. Verifique os dados.");
            }
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            // Vê se tem alguma linha selecionada
            if (dgvItens.SelectedRows.Count > 0)
            {
                try
                {
                    // Busca índice
                    int rowIndex = dgvItens.SelectedRows[0].Index;
                    // Busca item selecionado pelo índice
                    var selectedItem = dgvItens.Rows[rowIndex].DataBoundItem;

                    switch (_formType)
                    {
                        case FormTypes.Produtos:
                            if (selectedItem is ProdutoViewModel produtoSelecionado)
                            {
                                var produto = _controller.GetById(produtoSelecionado.Id);
                                _controller.DeleteItem(produto);
                            }
                            break;

                        case FormTypes.Marcas:
                            if (selectedItem is Marca marcaSelecionada)
                            {
                                _controller.DeleteItem(marcaSelecionada);
                            }
                            break;

                        case FormTypes.Vendas:
                            if (selectedItem is Venda vendaSelecionada)
                            {
                                MessageBox.Show("Proceder com a devolução?");
                                //_controller.DeleteItem(marcaSelecionada);
                            }
                            break;

                        case FormTypes.Categorias:
                            if (selectedItem is Categoria categoriaSelecionada)
                            {
                                _controller.DeleteItem(categoriaSelecionada);
                            }
                            break;

                        case FormTypes.Clientes:
                            if (selectedItem is Utilizador clienteSelecionado)
                            {
                                _controller.DeleteItem(clienteSelecionado);
                            }
                            break;
                        case FormTypes.Campanhas:
                            if (selectedItem is CampanhaViewModel campanhaSelecionada)
                            {
                                var campanha = _controller.GetById(campanhaSelecionada.Id);
                                _controller.DeleteItem(campanha);
                            }
                            break;

                        default:
                            MessageBox.Show("FormType desconhecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    // Recarrega itens após eliminação
                    MostraItens();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro enquanto removia item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addForm;

            //Determina form a abrir
            switch (_formType)
            {
                case FormTypes.Produtos:
                    addForm = new AddProdutoForm();
                    break;
                case FormTypes.Categorias:
                    addForm = new AddCategoriaForm();
                    break;
                case FormTypes.Marcas:
                    addForm = new AddMarcaForm();
                    break;
                case FormTypes.Vendas:
                    addForm = new AddVendaForm();
                    break;
                case FormTypes.Clientes:
                    addForm = new AddClienteForm();
                    break;
                case FormTypes.Campanhas:
                    addForm = new AddCampanhaForm();
                    break;
                default:
                    MessageBox.Show("FormType desconhecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Abre form
            using (addForm)
            {
                addForm.ShowDialog();
            }

            // Recarrega itens
            MostraItens();
        }

    }
}
