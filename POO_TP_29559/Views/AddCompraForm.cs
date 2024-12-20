﻿using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories.Enumerators;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace poo_tp_29559.Views
{
    #region Class AddCompraForm

    /// <summary>
    /// Formulário para a criação de uma compra, por um cliente.
    /// </summary>
    /// <remarks>
    /// Este formulário serve para adicionar uma nova compra ao sistema.
    /// O utilizador cliente deve preencher vários campos, como produtos, quantidades e método de pagamento.
    /// Além disso, o sistema valida os campos para garantir que os dados inseridos sejam válidos.
    /// </remarks>
    public partial class AddCompraForm : MetroForm
    {
        #region Private Fields
        private readonly VendaCompraController _controllerVenda; ///< Controlador de vendas e compras
        private UtilizadorController utilizadorController; ///< Controlador de utilizadores
        private ProdutoController produtoController; ///< Controlador de produtos
        private CategoriaController categoriaController; ///< Controlador de categorias
        private MarcaController marcaController; ///< Controlador de marcas
        private readonly Utilizador _cliente; ///< Cliente associado à compra
        private List<Produto>? _produtos; ///< Lista de produtos disponíveis
        int mesesGarantia = 36; ///< Garantia predefinida em meses
        decimal totalBruto = 0, totalLiquido = 0; ///< Totais brutos e líquidos da compra
        #endregion

        #region Constructor
        /// <summary>
        /// Construtor da classe AddCompraForm.
        /// </summary>
        /// <param name="cliente">O utilizador cliente associado à compra, à partida será sempre o utilizador autenticado.</param>
        public AddCompraForm(Utilizador cliente)
        {
            InitializeComponent();
            _cliente = cliente;
            _controllerVenda = new VendaCompraController();
            utilizadorController = new UtilizadorController();
            produtoController = new ProdutoController();
            categoriaController = new CategoriaController();
            marcaController = new MarcaController();

            CarregaProdutos();
            CarregaMetodosPagamento();
            CalculaGarantia(cliente);
        }
        #endregion

        #region Loading Methods
        /// <summary>
        /// Carrega os produtos disponíveis na combo box.
        /// </summary>
        /// <remarks>
        /// Este método busca todos os produtos através do controlador de produtos, mapeia o nome e ID e exibe-os no 
        /// combo box para que o utilizador possa selecionar uma.
        /// </remarks>
        private void CarregaProdutos()
        {
            _produtos = produtoController.GetRawProdutos();

            if (_produtos != null)
            {
                cmbProdutos.DataSource = _produtos;
                cmbProdutos.DisplayMember = "Nome";
                cmbProdutos.ValueMember = "Id";
            }
        }

        /// <summary>
        /// Atribui meses de garantia calculados pelo controlador.
        /// </summary>
        /// <param name="cliente">Objeto do tipo Utilizador que representa o utilizador autenticado.</param>
        private void CalculaGarantia(Utilizador cliente)
        {
            mesesGarantia = _controllerVenda.CalculaGarantia(cliente);
            txtGarantia.Text = $"{mesesGarantia} meses";
        }

        /// <summary>
        /// Carrega os Métodos de Pagamento.
        /// </summary>
        /// <remarks>
        /// Este método carrega e mapeia os métodos de pagamento disponíveis para a execução da compra num combobox, 
        /// para o utilizador escolher. Tem os dados provenientes da classe EnumHelper.
        /// </remarks>
        private void CarregaMetodosPagamento()
        {
            var metodosPagamento = EnumHelper.GetEnumDescriptions<MetodoPagamento>();

            cmbMetodoPagamento.DataSource = metodosPagamento;
            cmbMetodoPagamento.DisplayMember = "Key";
            cmbMetodoPagamento.ValueMember = "Value";
        }

        /// <summary>
        /// Atualiza o total bruto e líquido da compra.
        /// </summary>
        /// <remarks>
        /// Este método cálcula o total bruto, fazendo a soma do produto da quantidade pelo preço unitário para todos os 
        /// produtos na DataGridView. Cálculo de total líquido é dado pela subtração do total bruto pelos descontos encontrados 
        /// para as categorias a que os produtos pertecem.
        /// </remarks>
        private void AtualizarTotais()
        {
            decimal totalDesconto = 0;

            foreach (DataGridViewRow row in dgvFatura.Rows)
            {
                if (row.Cells["Quantidade"].Value != null && row.Cells["PrecoUni"].Value != null && row.Cells["IDProduto"].Value != null)
                {
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    decimal precoUnitario = Convert.ToDecimal(row.Cells["PrecoUni"].Value);
                    int produtoId = Convert.ToInt32(row.Cells["IDProduto"].Value);

                    totalBruto += quantidade * precoUnitario;

                    // Obter categoria do produto pelo ID
                    Produto produto = (Produto)produtoController.GetById(produtoId);

                    if (produto != null)
                    {
                        var desconto = ObterDescontoPorCategoria(produto.CategoriaID);
                        totalDesconto += (quantidade * precoUnitario) * (desconto / 100);
                    }
                }
            }

            // Calcular o total líquido
            totalLiquido = totalBruto - totalDesconto;

            txtTotalBruto.Text = totalBruto.ToString("C");
            txtTotalLiquido.Text = totalLiquido.ToString("C");
        }



        /// <summary>
        /// Obtém desconto aplicável por categoria.
        /// </summary>
        /// <param name="categoriaId">Identificador da categoria a pesquisar.</param>
        /// <returns>Percentagem do desconto aplicável.</returns>
        private decimal ObterDescontoPorCategoria(int? categoriaId)
        {
            CampanhaRepo campanhaRepo = new();
            var campanhas = campanhaRepo.GetAll();

            // Verificar se existe uma campanha válida para a categoria
            var campanhaValida = campanhas.FirstOrDefault(c => c.CategoriaId == categoriaId && campanhaRepo.IsCampanhaValida(c));

            if (campanhaValida != null)
            {
                return campanhaValida.PercentagemDesc ?? 0;
            }

            return 0; // Sem desconto
        }

        /// <summary>
        /// Verifica campanhas aplicáveis aos produtos na DataGridView e exibe ao utilizador.
        /// </summary>
        private void VerificarCampanhas()
        {
            CampanhaRepo campanhaRepo = new();
            List<Campanha> campanhas = campanhaRepo.GetAll();

            // Obter categorias dos produtos na fatura
            var categoriasNaFatura = dgvFatura.Rows
                .Cast<DataGridViewRow>()
                .Select(row => row.Cells["IDProduto"].Value)
                .Where(idProduto => idProduto != null)
                .Select(idProduto =>
                {
                    Produto produto = (Produto)produtoController.GetById(Convert.ToInt32(idProduto));
                    return produto?.CategoriaID;
                })
                .Where(categoriaId => categoriaId != null)
                .Distinct()
                .ToList();

            // Filtrar campanhas aplicáveis
            var campanhasAplicaveis = campanhas
                .Where(c => categoriasNaFatura.Contains(c.CategoriaId) && campanhaRepo.IsCampanhaValida(c))
                .ToList();

            AtualizaListViewCampanhas(campanhasAplicaveis);
        }

        /// <summary>
        /// Atualiza o ListView com as campanhas aplicáveis.
        /// </summary>
        /// <param name="campanhas">Lista de campanhas aplicáveis.</param>
        private void AtualizaListViewCampanhas(List<Campanha> campanhas)
        {
            listViewCampanhas.Items.Clear();
            foreach (var campanha in campanhas)
            {
                ListViewItem item = new ListViewItem(campanha.Nome);
                item.SubItems.Add(ObterNomeCategoria(campanha.CategoriaId));
                item.SubItems.Add($"{campanha.PercentagemDesc}%");
                listViewCampanhas.Items.Add(item);
            }
        }

        /// <summary>
        /// Retorna o nome da categoria através do ID.
        /// </summary>
        /// <param name="categoriaId">Identificador da categoria.</param>
        /// <returns>Nome da categoria.</returns>
        private string ObterNomeCategoria(int categoriaId)
        {
            Categoria categoria = (Categoria)categoriaController.GetById(categoriaId);
            return categoria.Nome ?? "Desconhecida";
        }

        /// <summary>
        /// Retorna o nome da marca através do ID.
        /// </summary>
        /// <param name="marcaId">Identificador da marca.</param>
        /// <returns>Nome da marca.</returns>
        private string ObterNomeMarca(int marcaId)
        {
            Marca marca = (Marca)marcaController.GetById(marcaId);
            return marca.Nome ?? "Desconhecida";
        }

        /// <summary>
        /// Valida os campos necessários para a venda.
        /// </summary>
        private bool ValidarVenda()
        {
            if (dgvFatura.Rows.Count == 0)
                return false;

            if (cmbMetodoPagamento.SelectedIndex < 0)
                return false;

            return true;
        }

        /// <summary>
        /// Cria um objeto Venda com os dados do formulário.
        /// </summary>
        private VendaCompra CriarCompra()
        {
            VendaCompra venda = new()
            {
                ClienteID = _cliente.Id,
                NIF = _cliente.Nif,
                TotalBruto = totalBruto,
                TotalLiquido = totalLiquido,
                DataVenda = DateTime.Now.ToString("dd-MM-yyyy - HH:mm"),
                FimDataGarantia = DateTime.Now.AddMonths(mesesGarantia).ToString("dd-MM-yyyy"),

                MetodoPagamento = Enum.TryParse(cmbMetodoPagamento.SelectedValue?.ToString(), out MetodoPagamento metodo)
                  ? metodo
                  : (MetodoPagamento?)null
            };

            foreach (DataGridViewRow row in dgvFatura.Rows)
            {
                if (row.Cells["IDProduto"].Value != null && row.Cells["Quantidade"].Value != null)
                {
                    int produtoID = Convert.ToInt32(row.Cells["IDProduto"].Value);
                    int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    Produto produto = (Produto)produtoController.GetById(produtoID);

                    if (produto != null)
                    {
                        ItemVenda itemVenda = new(
                            produtoID,
                            produto.Nome,
                            produto.Preco,
                            produto.CategoriaID,
                            ObterNomeCategoria(produto.CategoriaID),
                            ObterNomeMarca(produto.MarcaID),
                            quantidade,
                            (int?)ObterDescontoPorCategoria(produto.CategoriaID) // Adicionado o argumento para percentagemDesc

                        );



                        venda.Itens.Add(itemVenda);
                    }
                }
            }

            return venda;
        }

        #endregion

        #region Form Events
        /// <summary>
        /// Adiciona um produto à DataGridView de representação de fatura final.
        /// </summary>
        /// <remarks>
        /// Este método adiciona o produto selecionado na combobox de produtos à fatura final, face a quantidade escolhida 
        /// na NumericUpDown de quantidade. Inclui verificações de stock, e se o produto já se encontra na fatura, para 
        /// apenas adicionar quantidade. Verifica então totais monetários e campanhas aplicáveis.
        /// </remarks>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Dados do evento.</param>
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            if (cmbProdutos.SelectedItem is not Produto produtoSelecionado)
            {
                MessageBox.Show("Selecione um produto antes de adicionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidadeDesejada = (int)nudQtd.Value;

            // Verificar stock disponível considerando o que já foi adicionado na fatura anteriormente, do mesmo produto
            int quantidadeTotalFatura = dgvFatura.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["Produto"].Value?.ToString() == produtoSelecionado.Nome)
                .Sum(row => Convert.ToInt32(row.Cells["Quantidade"].Value));

            int quantidadeDisponivel = (produtoSelecionado.QuantidadeEmStock - quantidadeTotalFatura);

            // Operador ternário para se a quantidade disponível for negativa, mostrar apenas 0, e não números negativos.
            quantidadeDisponivel = quantidadeDisponivel < 0 ? 0 : quantidadeDisponivel;

            if (quantidadeDesejada <= 0 || quantidadeDesejada > quantidadeDisponivel)
            {
                MessageBox.Show($"Quantidade inválida ou insuficiente no stock! Disponível: {quantidadeDisponivel}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar se o produto já está na fatura e atualizar a quantidade na linha
            // Atualiza totais bruto e liquido.
            foreach (DataGridViewRow row in dgvFatura.Rows)
            {
                if (row.Cells["Produto"].Value?.ToString() == produtoSelecionado.Nome)
                {
                    int quantidadeAtual = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    row.Cells["Quantidade"].Value = quantidadeAtual + quantidadeDesejada;
                    produtoSelecionado.QuantidadeEmStock -= quantidadeDesejada;
                    return;
                }
            }

            // Adicionar novo produto à fatura
            dgvFatura.Rows.Add(produtoSelecionado.Id, produtoSelecionado.Nome, ObterNomeCategoria(produtoSelecionado.CategoriaID), ObterNomeMarca(produtoSelecionado.MarcaID), quantidadeDesejada, produtoSelecionado.Preco);
            AtualizarTotais();

            // Verificar campanhas aplicáveis
            VerificarCampanhas();
        }

        /// <summary>
        /// Remover item da fatura.
        /// </summary>
        /// <remarks>
        /// Este método remove o item selecionado na DataGridView e recalcula os totais e campanhas.
        /// </remarks>
        private void btnRemItem_Click(object sender, EventArgs e)
        {
            if (dgvFatura.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item na fatura para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvFatura.SelectedRows[0];
            dgvFatura.Rows.Remove(row);

            // Recalcular campanhas
            VerificarCampanhas();
            AtualizarTotais();
        }

        /// <summary>
        /// Método acionado quando uma célula da DataGridView é editada.
        /// </summary>
        private void dgvFatura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFatura.Columns["Quantidade"].Index)
            {
                AtualizarTotais();
            }
        }

        /// <summary>
        /// Confirma a compra e realiza as ações necessárias.
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validação de entrada
            if (!ValidarVenda())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios e adicione pelo menos um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Criar a venda
            VendaCompra compra = CriarCompra();

            try
            {
                // Atualizar o stock dos produtos vendidos
                foreach (var itemCompra in compra.Itens)
                {
                    Produto produto = (Produto)produtoController.GetById(itemCompra.ProdutoID);
                    if (produto != null)
                    {
                        // Subtrai a quantidade vendida do stock de cada produto
                        produto.QuantidadeEmStock -= itemCompra.Unidades;

                        // Atualiza o produto no repositório
                        produtoController.UpdateItem(produto);
                    }
                }

                // Guarda a venda no repositório
                VendaCompraRepo vendaCompraRepo = new();

                vendaCompraRepo.Add(compra);

                MessageBox.Show("Venda registada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Fechar form após venda
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao gravar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       


        private void btnAddProduto_MouseEnter(object sender, EventArgs e) => btnAddProduto.ForeColor = Color.DodgerBlue;
        private void btnAddProduto_MouseLeave(object sender, EventArgs e) => btnAddProduto.ForeColor = Color.Black;
        private void btnRemItem_MouseEnter(object sender, EventArgs e) => btnRemItem.ForeColor = Color.Red;
        private void btnRemItem_MouseLeave(object sender, EventArgs e) => btnRemItem.ForeColor = Color.Black;
        #endregion
    }
}
#endregion