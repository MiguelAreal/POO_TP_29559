/**
 * @file ChildForm.cs
 * @brief Formulário filho da aplicação, utilizado para gerir diferentes tipos de itens (Produtos, Categorias, Marcas, etc.).
 *
 * Este formulário é responsável pela exibição e interação com os itens de cada tipo específico (Produtos, Categorias, Marcas, etc.).
 * Também disponibiliza funcionalidades para adicionar, remover, pesquisar e editar itens através de uma UI intuitiva.
 * O formulário ajusta os comportamentos e botões visíveis dependendo do tipo de utilizador (Administrador ou Cliente) e do tipo de formulário em questão.
 *
 * @author Miguel Areal
 * @date 12/2024
 */

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
    /**
     * @class ChildForm
     * @brief Formulário filho responsável pela interação com os dados dos itens.
     * 
     * Este formulário é usado para exibir, editar, adicionar e remover itens conforme o tipo de formulário ativo (Produtos, Categorias, Marcas, etc.).
     * Ele possui funcionalidades específicas para manipulação de dados, incluindo a possibilidade de ordenar, filtrar e editar os itens.
     * O comportamento e a visibilidade de certos botões são alterados dependendo do tipo de utilizador (Administrador ou Cliente).
     */
    public partial class ChildForm : MetroForm
    {
        private readonly IEntityController _controller;  /**< Controlador responsável pela interação com os dados */
        private readonly FormTypes _formType;  /**< Tipo do formulário atual (Produtos, Categorias, etc.) */
        private readonly Utilizador _utilizadorLogado;  /**< Utilizador atualmente autenticado */
        private string? _activeColumn;  /**< Nome da coluna ativa para filtros e ordenação */
        private int _previousColumnIndex = -1;  /**< Índice da coluna anteriormente selecionada */
        private BindingSource _bindingSource;  /**< Fonte de dados ligada ao DataGridView */
        private object items;  /**< Lista de itens a ser exibida */


        /**
        * @brief Construtor do `ChildForm`.
        * 
        * Inicializa os componentes do formulário, configura o tipo de formulário e o controlador responsável pelos dados,
        * e exibe os itens na interface.
        * 
        * @param formType O tipo do formulário (Produtos, Categorias, etc.).
        * @param utilizadorLogado O utilizador autenticado.
        */
        public ChildForm(FormTypes formType, Utilizador utilizadorLogado)
        {
            InitializeComponent();
            _formType = formType;
            _controller = CreateController();
            _utilizadorLogado = utilizadorLogado;
            _bindingSource = new BindingSource();
            changeSettings(formType, _utilizadorLogado.IsAdmin);
            MostraItens();

        }

        /**
         * @brief Altera as configurações visuais do formulário com base no tipo de formulário e permissões do utilizador.
         * 
         * Altera a visibilidade de botões e outras configurações visuais conforme o tipo de formulário e se o utilizador
         * é um administrador ou cliente.
         * 
         * @param formType O tipo do formulário (Produtos, Categorias, etc.).
         * @param isAdmin Determina se o utilizador é um administrador.
         */
        public void changeSettings(FormTypes formType, bool isAdmin)
        {
            btnSeeMovimento.Visible = false;  /**< Esconde o botão de ver venda por defeito */
            Text = _formType.ToString();  /**< Define o título do formulário com base no tipo */

            if (!isAdmin)
            {
                btnRem.Visible = false;
                btnSeeMovimento.Visible = false;
                btnAdd.Visible = false;
                dgvItens.ReadOnly = true;
            }

            switch (formType)
            {
                case FormTypes.Vendas:
                    btnAdd.Text = "🛒";
                    btnSeeMovimento.Visible = true;
                    dgvItens.ReadOnly = true;
                    break;
                case FormTypes.Compras:
                    btnAdd.Text = "🛒";
                    btnRem.Visible = true;
                    btnSeeMovimento.Visible = true;
                    btnAdd.Visible = true;
                    dgvItens.ReadOnly = true;
                    break;
                case FormTypes.Utilizadores:
                    btnAdd.Text = "👤";
                    break;

            }


        }

        /**
         * @brief Cria o controlador apropriado com base no tipo de formulário.
         * 
         * Este método cria e retorna o controlador correspondente ao tipo de formulário atual.
         * 
         * @return Um controlador de entidade que gerencia os itens do tipo especificado.
         */
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
                _ => throw new ArgumentException("FormType desconhecido.")
            };
        }

        /**
         * @brief Exibe os itens no DataGridView.
         * 
         * Este método busca os dados do controlador, atualiza o BindingSource e exibe os itens no DataGridView.
         */
        public void MostraItens()
        {
            items = _controller.GetItems();
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
            ToggleColumnVisibility("Password", false);
        }

        /**
        * @brief Altera a visibilidade de uma coluna no DataGridView.
        * 
        * Este método esconde ou exibe uma coluna no DataGridView com base no nome da coluna.
        * 
        * @param columnName O nome da coluna a ser alterada.
        * @param isVisible Se a coluna deve ser visível ou não.
        */
        private void ToggleColumnVisibility(string columnName, bool isVisible)
        {
            if (dgvItens.Columns.Contains(columnName))
            {
                dgvItens.Columns[columnName].Visible = isVisible;
            }
        }

        /**
        * @brief Altera a cor do texto de um botão.
        * 
        * Este método altera a cor do texto de um botão para o valor especificado.
        * 
        * @param button O botão cuja cor de texto será alterada.
        * @param color A nova cor para o texto do botão.
        */
        private void ChangeButtonColor(Control button, Color color)
        {
            button.ForeColor = color;
        }


        private void btnRem_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnRem, Color.Red);
        private void btnRem_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnRem, Color.Black);
        private void btnAdd_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnAdd, Color.DodgerBlue);
        private void btnAdd_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnAdd, Color.Black);
        private void btnSeeVenda_MouseEnter(object sender, EventArgs e) => ChangeButtonColor(btnSeeMovimento, Color.DodgerBlue);
        private void btnSeeVenda_MouseLeave(object sender, EventArgs e) => ChangeButtonColor(btnSeeMovimento, Color.Black);


        /**
         * @brief Evento de busca de itens.
         * 
         * Este evento é acionado quando o texto de pesquisa é alterado. Ele aplica um filtro ao BindingSource
         * para exibir apenas os itens que correspondem ao texto inserido na pesquisa.
         * 
         * @param sender O objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchItem.Text) && !string.IsNullOrEmpty(_activeColumn))
            {
                _bindingSource.Filter = $"{_activeColumn} LIKE '*{txtSearchItem.Text}*'";
            }
            else
            {
                _bindingSource.RemoveFilter();
            }

            dgvItens.Refresh();
            RestoreCurrentCell();
        }


        /**
         * @brief Restaura a célula ativa após alteração.
         * 
         * Este método restaura a célula ativa após uma alteração no DataGridView,
         * como uma pesquisa ou modificação de dados, para persistência visual.
         */
        private void RestoreCurrentCell()
        {
            if (dgvItens.Rows.Count > 0)
            {
                int currentColumnIndex = dgvItens.Columns[_activeColumn]?.Index ?? -1;
                dgvItens.CurrentCell = currentColumnIndex >= 0 && currentColumnIndex < dgvItens.Columns.Count
                    ? dgvItens.Rows[0].Cells[currentColumnIndex]
                    : dgvItens.Rows[0].Cells[0]; // Fallback para a primeira célula
            }
        }


        /**
         * @brief Evento de mudança de célula no DataGridView.
         * 
         * Este evento é acionado quando a célula ativa no DataGridView é alterada.
         * Ele armazena a coluna ativa para filtros.
         * 
         * @param sender O objeto que disparou o evento.
         * @param e Dados do evento.
         */
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


        /**
          * @brief Evento de mudança de conteúdo de uma célula no DataGridView.
          * 
          * Este evento é acionado quando uma célula tem o seu conteúdo alterado no DataGridView.
          * O comportamento do evento é dinâmico, depende do tipo de form ativo.
          * 
          * @param sender O objeto que disparou o evento.
          * @param e Dados do evento.
          */
        private void dgvItens_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /**<Tenta obter o item editado com base na linha e coluna alteradas> */
            try
            {
                // Certifica-se de que a linha e a coluna são válidas
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < dgvItens.Rows.Count)
                {
                    var selectedItem = dgvItens.Rows[e.RowIndex].DataBoundItem;
                    _controller.UpdateItem(selectedItem);
                    MostraItens();
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


        /**
         * @brief Evento de clique no botão de remover.
         * 
         * Este evento é acionado quando o botão de remover é clicado. Ele exclui o item selecionado no DataGridView e no ficheiro de dados associado. 
         * 
         * @param sender O objeto que disparou o evento.
         * @param e Dados do evento.
         */
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
                        case FormTypes.Compras:
                            if (selectedItem is VendaCompraViewModel vendaCompraSelecionada)
                            {
                                var vendaCompra = _controller.GetById(vendaCompraSelecionada.Id);

                                // Emitir aviso para confirmação de devolução
                                var result = MessageBox.Show(
                                    "Deseja proceder à devolução antes de apagar esta venda/compra?",
                                    "Confirmar Devolução",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );

                                if (result == DialogResult.Yes)
                                {
                                    _controller.DeleteItem(vendaCompra);
                                    MessageBox.Show("Item devolvido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            break;

                        case FormTypes.Categorias:
                            if (selectedItem is Categoria categoriaSelecionada)
                            {
                                _controller.DeleteItem(categoriaSelecionada);
                            }
                            break;

                        case FormTypes.Utilizadores:
                            if (selectedItem is Utilizador utilizadorSelecionado)
                            {
                                _controller.DeleteItem(utilizadorSelecionado);
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


        /**
        * @brief Evento de clique no botão de adicionar.
        * 
        * Este evento é acionado quando o botão de adicionar é clicado. Ele abre um novo formulário para adicionar um item.
        * O novo form aberto depende do tipo de formulário a ser utilizado no momento.
        * 
        * @param sender O objeto que disparou o evento.
        * @param e Dados do evento.
        */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addForm;

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
                case FormTypes.Compras:
                    addForm = new AddCompraForm(_utilizadorLogado);
                    break;
                case FormTypes.Utilizadores:
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


        /**
         * @brief Evento de clique no botão de ver movimento.
         * 
         * Este evento é acionado quando o botão de ver movimento é clicado.
         * Ele abre um formulário com os detalhes do movimento selecionado, se este for válido.
         * 
         * @param sender O objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void btnSeeMovimento_Click(object sender, EventArgs e)
        {
            // Verifica se há alguma linha selecionada
            if (dgvItens.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtém o índice da linha selecionada
                    int rowIndex = dgvItens.SelectedRows[0].Index;

                    // Obtém o item selecionado pelo índice da linha (que é um VendaViewModel)
                    var selectedItem = dgvItens.Rows[rowIndex].DataBoundItem;

                    // Verifica se o item selecionado é um VendaViewModel
                    if (selectedItem is VendaCompraViewModel vendaViewModel)
                    {
                        // Busca a venda completa com base no Id da VendaViewModel
                        VendaCompra venda = (VendaCompra)_controller.GetById(vendaViewModel.Id);
                        string titulo;
                        // Verifica se o formulário ativo é de Vendas
                        if (_formType == FormTypes.Vendas)
                        {
                            titulo = "   Detalhes de Venda";
                        }
                        else if (_formType == FormTypes.Compras)
                        {
                            titulo = "   Detalhes de Compra";
                        }
                        else
                        {
                            return;
                        }

                        // Abre o formulário
                        Form consultaForm = new DetalhesVendaCompra(titulo, venda);
                        using (consultaForm)
                        {
                            consultaForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione um movimento válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro enquanto consultava movimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um movimento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
