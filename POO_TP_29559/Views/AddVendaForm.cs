using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Repositories.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace poo_tp_29559.Views
{
    /// <summary>
    /// Formulário para adicionar vendas.
    /// Este formulário permite registar vendas, associar clientes, adicionar produtos à fatura, 
    /// calcular totais (bruto e líquido) e verificar campanhas promocionais aplicáveis.
    /// </summary>
    public partial class AddVendaForm : MetroForm
    {
        #region Variables
        private readonly VendaCompraController _controllerVenda;
        private UtilizadorController utilizadorController;
        private ProdutoController produtoController;
        private CategoriaController categoriaController;
        private MarcaController marcaController;

        private List<Utilizador> _clientes;
        private List<Produto>? _produtos;

        int mesesGarantia = 36;
        decimal totalBruto = 0, totalLiquido = 0;
        #endregion

        #region Constructor and Initialization
        /// <summary>
        /// Construtor da classe AddVendaForm. Inicializa os controladores e carrega os dados iniciais.
        /// </summary>
        public AddVendaForm()
        {
            InitializeComponent();

            utilizadorController = new UtilizadorController();
            produtoController = new ProdutoController();
            categoriaController = new CategoriaController();
            marcaController = new MarcaController();

            CarregaProdutos();
            CarregaClientes();
            CarregaMetodosPagamento();
        }
        #endregion

        #region Loading Methods
        /// <summary>
        /// Carrega os produtos e os ordena na combobox.
        /// </summary>
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
        /// Carrega os clientes na combobox.
        /// </summary>
        private void CarregaClientes()
        {
            _clientes = utilizadorController.GetClientes(); // Chama o controlador para obter apenas os clientes.

            if (_clientes != null && _clientes.Count > 0)
            {
                cmbClientes.DataSource = _clientes;
                cmbClientes.DisplayMember = "Nome";
                cmbClientes.ValueMember = "Id";
                cmbClientes.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Carrega os métodos de pagamento a partir de um enumerador.
        /// </summary>
        private void CarregaMetodosPagamento()
        {
            var metodosPagamento = EnumHelper.GetEnumDescriptions<MetodoPagamento>();

            cmbMetodoPagamento.DataSource = metodosPagamento;
            cmbMetodoPagamento.DisplayMember = "Key";
            cmbMetodoPagamento.ValueMember = "Value";
        }
        #endregion

        #region Form Events

        /// <summary>
        /// Evento acionado quando se edita uma célula na tabela.
        /// Atualiza os totais monetários.
        /// </summary>
        private void dgvFatura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFatura.Columns["Quantidade"].Index)
            {
                AtualizarTotais();
            }
        }

        /// <summary>
        /// Evento acionado quando o NIF fica sem foco.
        /// Realiza verificações.
        /// </summary>
        private void txtNIF_Leave(object sender, EventArgs e)
        {
            // Verificar se o NIF tem exatamente 9 caracteres
            if (txtNIF.Text.Length != 9)
            {
                MessageBox.Show("O NIF deve ter 9 dígitos.", "NIF inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Clear();
                return;
            }

            // Tentar converter o texto para um número inteiro (int)
            if (!int.TryParse(txtNIF.Text, out int nifValue))
            {
                MessageBox.Show("O NIF deve conter apenas números.", "NIF inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Clear();
                return;
            }
        }

        /// <summary>
        /// Evento acionado quando botão de remover é clicado
        /// Remove um item da fatura final.
        /// </summary>
        /// 
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
        /// Evento acionado quando botão de confirmar é clicado
        /// Valida a venda e executa a mesma.
        /// </summary>
        /// 
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validação de entrada
            if (!ValidarVenda())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios e adicione pelo menos um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Criar a venda
            VendaCompra venda = CriarVenda();

            try
            {
                // Atualizar o stock dos produtos vendidos
                foreach (var itemVenda in venda.Itens)
                {
                    Produto produto = (Produto)produtoController.GetById(itemVenda.ProdutoID);
                    if (produto != null)
                    {
                        // Subtrai a quantidade vendida do stock de cada produto
                        produto.QuantidadeEmStock -= itemVenda.Unidades;

                        // Atualiza o produto no repositório
                        produtoController.UpdateItem(produto);
                    }
                }

                // Guarda a venda no repositório
                VendaCompraRepo vendaRepo = new();
                vendaRepo.Add(venda);

                MessageBox.Show("Venda registada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Fechar form após venda
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao gravar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Evento acionado quando o cliente é selecionado.
        /// Atualiza o NIF com o valor do cliente selecionado.
        /// </summary>
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilizador? clienteSelecionado = cmbClientes.SelectedItem as Utilizador;

            if (clienteSelecionado != null)
            {
                txtNIF.Text = clienteSelecionado.Nif.ToString();
            }
        }

        /// <summary>
        /// Evento acionado quando o texto do NIF é alterado.
        /// Realiza validação do NIF e ajusta a garantia.
        /// </summary>
        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            string enteredNif = txtNIF.Text;

            if (!string.IsNullOrWhiteSpace(enteredNif) && int.TryParse(enteredNif, out int nifParsed))
            {
                var clienteCorrespondente = _clientes.FirstOrDefault(c => c.Nif == nifParsed);
                if (clienteCorrespondente != null)
                {
                    cmbClientes.SelectedItem = clienteCorrespondente;
                }
                else
                {
                    cmbClientes.SelectedIndex = -1;
                }

                if (enteredNif.Length == 9)
                {
                    if (enteredNif.StartsWith("1") || enteredNif.StartsWith("2") || enteredNif.StartsWith("3"))
                    {
                        mesesGarantia = 36;
                    }
                    else
                    {
                        mesesGarantia = 12;
                    }
                }
                else
                {
                    mesesGarantia = 36;
                }
            }
            else
            {
                cmbClientes.SelectedIndex = -1;
            }

            txtGarantia.Text = $"{mesesGarantia} meses";
        }

        /// <summary>
        /// Atualiza os totais da fatura, incluindo o total bruto e o total líquido.
        /// </summary>
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

                    Produto produto = (Produto)produtoController.GetById(produtoId);

                    if (produto != null)
                    {
                        var desconto = ObterDescontoPorCategoria(produto.CategoriaID);
                        totalDesconto += (quantidade * precoUnitario) * (desconto / 100);
                    }
                }
            }

            totalLiquido = totalBruto - totalDesconto;

            txtTotalBruto.Text = totalBruto.ToString("C");
            txtTotalLiquido.Text = totalLiquido.ToString("C");
        }

        /// <summary>
        /// Calcula o desconto aplicável a partir da categoria do produto.
        /// </summary>
        private decimal ObterDescontoPorCategoria(int? categoriaId)
        {
            CampanhaRepo campanhaRepo = new();
            var campanhas = campanhaRepo.GetAll();

            var campanhaValida = campanhas.FirstOrDefault(c => c.CategoriaId == categoriaId && campanhaRepo.IsCampanhaValida(c));

            if (campanhaValida != null)
            {
                return campanhaValida.PercentagemDesc ?? 0;
            }

            return 0;
        }

        /// <summary>
        /// Verifica as campanhas aplicáveis aos produtos na fatura.
        /// </summary>
        private void VerificarCampanhas()
        {
            CampanhaRepo campanhaRepo = new();
            List<Campanha> campanhas = campanhaRepo.GetAll();

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

            var campanhasAplicaveis = campanhas
                .Where(c => categoriasNaFatura.Contains(c.CategoriaId) && campanhaRepo.IsCampanhaValida(c))
                .ToList();

            AtualizaListViewCampanhas(campanhasAplicaveis);
        }

        /// <summary>
        /// Atualiza o ListView com as campanhas aplicáveis.
        /// </summary>
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
        /// Retorna o nome da categoria a partir do ID.
        /// </summary>
        private string ObterNomeCategoria(int categoriaId)
        {
            Categoria categoria = (Categoria)categoriaController.GetById(categoriaId);
            return categoria.Nome ?? "Desconhecida";
        }

        /// <summary>
        /// Retorna o nome da marca a partir do ID.
        /// </summary>
        private string ObterNomeMarca(int marcaId)
        {
            Marca marca = (Marca)marcaController.GetById(marcaId);
            return marca.Nome ?? "Desconhecida";
        }
        #endregion

        #region Validation and Creation
        /// <summary>
        /// Valida a venda antes de ser registada.
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
        /// Cria o objeto Venda a partir dos dados do formulário.
        /// </summary>
        private VendaCompra CriarVenda()
        {
            VendaCompra venda = new()
            {
                ClienteID = (int)cmbClientes.SelectedValue,
                NIF = Convert.ToInt32(txtNIF.Text),
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
                            (int?)ObterDescontoPorCategoria(produto.CategoriaID)
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
        /// Adiciona um produto à fatura e atualiza o estoque e os totais.
        /// </summary>
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            Produto produtoSelecionado = cmbProdutos.SelectedItem as Produto;
            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto antes de adicionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidadeDesejada = (int)nudQtd.Value;

            int quantidadeTotalFatura = dgvFatura.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["Produto"].Value?.ToString() == produtoSelecionado.Nome)
                .Sum(row => Convert.ToInt32(row.Cells["Quantidade"].Value));

            int quantidadeDisponivel = (produtoSelecionado.QuantidadeEmStock - quantidadeTotalFatura);

            quantidadeDisponivel = quantidadeDisponivel < 0 ? 0 : quantidadeDisponivel;

            if (quantidadeDesejada <= 0 || quantidadeDesejada > quantidadeDisponivel)
            {
                MessageBox.Show($"Quantidade inválida ou insuficiente no stock! Disponível: {quantidadeDisponivel}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvFatura.Rows)
            {
                if (row.Cells["Produto"].Value?.ToString() == produtoSelecionado.Nome)
                {
                    int quantidadeAtual = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    row.Cells["Quantidade"].Value = quantidadeAtual + quantidadeDesejada;
                    produtoSelecionado.QuantidadeEmStock -= quantidadeDesejada;
                    AtualizarTotais();
                    return;
                }
            }

            dgvFatura.Rows.Add(produtoSelecionado.Id, produtoSelecionado.Nome, ObterNomeCategoria(produtoSelecionado.CategoriaID), ObterNomeMarca(produtoSelecionado.MarcaID), quantidadeDesejada, produtoSelecionado.Preco);
            AtualizarTotais();
            VerificarCampanhas();
        }
        

        private void btnAddProduto_MouseEnter(object sender, EventArgs e) => btnAddProduto.ForeColor = Color.DodgerBlue;
        private void btnAddProduto_MouseLeave(object sender, EventArgs e) => btnAddProduto.ForeColor = Color.Black;
        private void btnRemItem_MouseEnter(object sender, EventArgs e) => btnRemItem.ForeColor = Color.Red;
        private void btnRemItem_MouseLeave(object sender, EventArgs e) => btnRemItem.ForeColor = Color.Black;
        #endregion
    }
}
