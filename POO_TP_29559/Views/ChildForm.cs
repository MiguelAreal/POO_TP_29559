using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories.Enumerators;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    public partial class ChildForm : MetroForm
    {
        #region Private Fields

        private readonly IEntityController _controller;  /**< Controlador responsável pela interação com os dados */
        private readonly FormTypes _formType;  /**< Tipo do formulário atual (Produtos, Categorias, etc.) */
        private readonly Utilizador _utilizadorLogado;  /**< Utilizador atualmente autenticado */
        private BindingSource _bindingSource;  /**< Fonte de dados ligada ao DataGridView */
        private List<object> _items;  /**< Lista de itens a ser exibida */

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa o formulário, configura o tipo de formulário e o controlador responsável pelos dados,
        /// e exibe os itens na interface.
        /// </summary>
        /// <param name="formType">O tipo do formulário (Produtos, Categorias, etc.).</param>
        /// <param name="utilizadorLogado">O utilizador autenticado.</param>
        public ChildForm(FormTypes formType, Utilizador utilizadorLogado)
        {
            InitializeComponent();
            _formType = formType;
            _controller = CreateController();
            _utilizadorLogado = utilizadorLogado;
            _bindingSource = new BindingSource();
            changeSettings(formType, _utilizadorLogado.IsAdmin);

            MostraItens(_controller.GetItems());
        }

        #endregion

        #region Configuration Methods

        /// <summary>
        /// Altera as configurações visuais do formulário com base no tipo de formulário e permissões do utilizador.
        /// </summary>
        /// <param name="formType">O tipo do formulário (Produtos, Categorias, etc.).</param>
        /// <param name="isAdmin">Determina se o utilizador é um administrador.</param>
        public void changeSettings(FormTypes formType, bool isAdmin)
        {
            Text = _formType.ToString();  /**< Define o título do formulário com base no tipo */

            if (!isAdmin)
            {
                btnRem.Visible = false;
                btnConsultarAtualizar.Visible = false;
                btnAdd.Visible = false;
                dgvItens.ReadOnly = true;
            }

            switch (formType)
            {
                case FormTypes.Vendas:
                    btnAdd.Text = "🛒";
                    btnConsultarAtualizar.Text = "🧾";
                    break;
                case FormTypes.Compras:
                    btnAdd.Text = "🛒";
                    btnConsultarAtualizar.Text = "🧾";
                    btnRem.Visible = true;
                    btnAdd.Visible = true;
                    break;
                case FormTypes.Utilizadores:
                    btnAdd.Text = "👤";
                    break;
            }
        }

        /// <summary>
        /// Cria o controlador apropriado com base no tipo de formulário.
        /// </summary>
        /// <returns>Um controlador de entidade que gerencia os itens do tipo especificado.</returns>
        private IEntityController CreateController()
        {
            return _formType switch
            {
                FormTypes.Produtos => new ProdutoController(),
                FormTypes.Categorias => new CategoriaController(),
                FormTypes.Marcas => new MarcaController(),
                FormTypes.Utilizadores => new UtilizadorController(),
                FormTypes.Campanhas => new CampanhaController(),
                FormTypes.Vendas => new VendaCompraController(),
                FormTypes.Compras => new VendaCompraController(),
                _ => throw new ArgumentException("FormType inválido.")
            };
        }

        #endregion

        #region View Methods

        /// <summary>
        /// Exibe os itens no DataGridView.
        /// </summary>
        /// <param name="items">Lista de itens a ser exibida.</param>
        public void MostraItens(List<object> items)
        {
            if (_formType == FormTypes.Compras)
            {
                // Filtra apenas as compras feitas pelo utilizador logado
                items = items.OfType<VendaCompraViewModel>()
                             .Where(vc => vc.ClienteID == _utilizadorLogado.Id)
                             .Cast<object>()
                             .ToList();
            }

            _items = items;
            _bindingSource.DataSource = items;
            dgvItens.DataSource = _bindingSource;
            dgvItens.Refresh();

            foreach (DataGridViewColumn column in dgvItens.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Esconde colunas irrelevantes
            ToggleColumnVisibility("Id", false);
            ToggleColumnVisibility("IsParticular", false);
        }

        /// <summary>
        /// Altera a visibilidade de uma coluna no DataGridView.
        /// </summary>
        /// <param name="columnName">O nome da coluna a ser alterada.</param>
        /// <param name="isVisible">Se a coluna deve ser visível ou não.</param>
        private void ToggleColumnVisibility(string columnName, bool isVisible)
        {
            if (dgvItens.Columns.Contains(columnName))
            {
                dgvItens.Columns[columnName].Visible = isVisible;
            }
        }

        #endregion

        #region Auxiliary Methods

        /// <summary>
        /// Altera a cor do texto de um botão.
        /// </summary>
        /// <param name="button">O botão cuja cor de texto será alterada.</param>
        /// <param name="color">A nova cor para o texto do botão.</param>
        private void ChangeButtonColor(Control button, Color color)
        {
            button.ForeColor = color;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Evento de clique no botão de remover.
        /// Exclui o item selecionado no DataGridView e no ficheiro de dados associado.
        /// </summary>
        private void btnRem_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count > 0)
            {
                try
                {
                    int rowIndex = dgvItens.SelectedRows[0].Index;
                    var selectedItem = dgvItens.Rows[rowIndex].DataBoundItem;

                    switch (_formType)
                    {
                        case FormTypes.Produtos:
                            if (selectedItem is ProdutoViewModel produtoSelecionado)
                            {
                                var produto = _controller.GetById(produtoSelecionado.Id);
                                _controller.RemoveItem(produto);
                            }
                            break;

                        case FormTypes.Marcas:
                            if (selectedItem is Marca marcaSelecionada)
                            {
                                _controller.RemoveItem(marcaSelecionada);
                            }
                            break;

                        case FormTypes.Vendas:
                        case FormTypes.Compras:
                            if (selectedItem is VendaCompraViewModel vendaCompraSelecionada)
                            {
                                var vendaCompra = _controller.GetById(vendaCompraSelecionada.Id);
                                var result = MessageBox.Show(
                                    "Deseja proceder à devolução antes de apagar esta venda/compra?",
                                    "Confirmar Devolução",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

                                if (result == DialogResult.Yes)
                                {
                                    _controller.RemoveItem(vendaCompra);
                                    MessageBox.Show("Item devolvido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            break;

                        case FormTypes.Categorias:
                            if (selectedItem is Categoria categoriaSelecionada)
                            {
                                _controller.RemoveItem(categoriaSelecionada);
                            }
                            break;

                        case FormTypes.Utilizadores:
                            if (selectedItem is Utilizador utilizadorSelecionado)
                            {
                                _controller.RemoveItem(utilizadorSelecionado);
                            }
                            break;

                        case FormTypes.Campanhas:
                            if (selectedItem is CampanhaViewModel campanhaSelecionada)
                            {
                                var campanha = _controller.GetById(campanhaSelecionada.Id);
                                _controller.RemoveItem(campanha);
                            }
                            break;

                        default:
                            MessageBox.Show("FormType desconhecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    MostraItens(_controller.GetItems());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro enquanto removia item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um item.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento de clique no botão de adicionar.
        /// Abre um novo formulário para adicionar um item.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addForm;

            switch (_formType)
            {
                case FormTypes.Produtos:
                    addForm = new AddUpdProdutoForm();
                    break;
                case FormTypes.Categorias:
                    addForm = new AddUpdCategoriaForm();
                    break;
                case FormTypes.Marcas:
                    addForm = new AddUpdMarcaForm();
                    break;
                case FormTypes.Vendas:
                    addForm = new AddVendaForm();
                    break;
                case FormTypes.Compras:
                    addForm = new AddCompraForm(_utilizadorLogado);
                    break;
                case FormTypes.Utilizadores:
                    addForm = new AddUpdClienteForm();
                    break;
                case FormTypes.Campanhas:
                    addForm = new AddUpdCampanhaForm();
                    break;
                default:
                    MessageBox.Show("FormType desconhecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            using (addForm)
            {
                addForm.ShowDialog();
            }

            MostraItens(_controller.GetItems());
        }

        /// <summary>
        /// Evento de clique no botão de ver movimento.
        /// Abre um formulário com os detalhes do movimento selecionado, se este for válido.
        /// </summary>
        private void btnConsultarAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedItem = dgvItens.Rows[dgvItens.SelectedRows[0].Index].DataBoundItem;

                    Form form = null;

                    if (selectedItem is VendaCompraViewModel vendaViewModel)
                    {
                        form = new DetalhesVendaCompra(_formType, vendaViewModel.Id);
                    }
                    else if (selectedItem is ProdutoViewModel produto)
                    {
                        form = new AddUpdProdutoForm(produto.Id);
                    }
                    else if (selectedItem is Categoria categoria)
                    {
                        form = new AddUpdCategoriaForm(categoria.Id);
                    }
                    else if (selectedItem is Marca marca)
                    {
                        form = new AddUpdMarcaForm(marca.Id);
                    }
                    else if (selectedItem is Utilizador utilizador)
                    {
                        if (!utilizador.IsAdmin)
                        {
                            form = new AddUpdClienteForm(utilizador.Id);
                        }
                        else
                        {
                            MessageBox.Show("Só é possível alterar dados de clientes.");
                        }
                    }
                    else if (selectedItem is Campanha campanha)
                    {
                        form = new AddUpdCampanhaForm(campanha.Id);
                    }

                    if (form != null)
                    {
                        form.ShowDialog();
                        MostraItens(_controller.GetItems());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro enquanto consultava item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um item.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento de alteração de texto no campo de pesquisa.
        /// Filtra os itens com base no texto inserido e atualiza a exibição no DataGridView.
        /// </summary>
        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Obter o filtro digitado pelo usuário no campo de pesquisa
                string filtro = txtSearchItem.Text;

                // Obter o nome da coluna da célula atualmente selecionada
                string coluna = dgvItens.CurrentCell?.OwningColumn?.Name;

                // Obter os índices da célula atualmente selecionada (coluna e linha)
                int colunaIndex = dgvItens.CurrentCell?.ColumnIndex ?? -1;  // Verifica se a coluna é válida
                int rowIndex = dgvItens.CurrentCell?.RowIndex ?? -1;  // Verifica se a linha é válida

                // Se o filtro estiver vazio, mostra todos os itens
                if (string.IsNullOrEmpty(filtro))
                {
                    MostraItens(_controller.GetItems());  // Método para mostrar todos os itens sem aplicar filtro
                    return;
                }

                // Filtra os itens com base no filtro e na coluna selecionada
                List<object> itensFiltrados = _controller.FiltrarItens(_items, filtro, coluna);
                MostraItens(itensFiltrados);

                // Verifica se há pelo menos uma linha após a filtragem
                if (itensFiltrados.Count > 0)
                {
                    // Caso haja itens filtrados, restaura a célula atual
                    if (rowIndex >= 0 && rowIndex < itensFiltrados.Count)
                    {
                        // Se o rowIndex original estiver dentro do intervalo das linhas filtradas
                        dgvItens.CurrentCell = dgvItens.Rows[rowIndex].Cells[colunaIndex];
                    }
                    else
                    {
                        // Se o rowIndex original não existir mais, foca na primeira linha
                        dgvItens.CurrentCell = dgvItens.Rows[0].Cells[colunaIndex];
                    }
                }
                else
                {
                    // Se não houver resultados, desabilita a célula atual
                    dgvItens.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer um erro durante a filtragem, apenas retorna sem fazer nada
                // Pode ser interessante registrar o erro para depuração
                // Console.WriteLine($"Erro ao filtrar itens: {ex.Message}"); 
                return;
            }
        }

        private void btnRem_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnRem, Color.Red);
        private void btnRem_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnRem, Color.Black);
        private void btnAdd_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnAdd, Color.DodgerBlue);
        private void btnAdd_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnAdd, Color.Black);
        private void btnSeeVenda_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnConsultarAtualizar, Color.DodgerBlue);
        private void btnSeeVenda_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnConsultarAtualizar, Color.Black);
        #endregion
    }
}
