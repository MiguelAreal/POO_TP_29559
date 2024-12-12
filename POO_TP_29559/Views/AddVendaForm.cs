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
    public partial class AddVendaForm : MetroForm
    {
        private readonly VendaController _controllerVenda;
        private UtilizadorController utilizadorController;
        private ProdutoController produtoController;

        ProdutoRepo produtoRepo = new();
        UtilizadorRepo clienteRepo = new();
        CategoriaRepo categoriaRepo = new();
        MarcaRepo marcaRepo = new();

        private List<Utilizador> _clientes;
        private List<Produto>? _produtos;

        int mesesGarantia = 36;
        decimal totalBruto = 0, totalLiquido = 0;

        public AddVendaForm()
        {
            InitializeComponent();

            utilizadorController = new UtilizadorController();
            produtoController = new ProdutoController();


            CarregaProdutos();
            CarregaClientes();
            CarregaMetodosPagamento();

        }

        // Carrega produtos e ordena-os na combobox.
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

        private void CarregaClientes()
        {
            _clientes = utilizadorController.GetClientes(); // Chama o controlador para obter apenas os clientes.

            if (_clientes != null && _clientes.Count > 0)
            {
                cmbClientes.DataSource = _clientes;
                cmbClientes.DisplayMember = "Nome";
                cmbClientes.ValueMember = "Id";
            }          
        }

        // Carregar métodos de pagamento, do enumerador
        private void CarregaMetodosPagamento()
        {
            var metodosPagamento = EnumHelper.GetEnumDescriptions<MetodoPagamento>();

            cmbMetodoPagamento.DataSource = metodosPagamento;
            cmbMetodoPagamento.DisplayMember = "Key";
            cmbMetodoPagamento.ValueMember = "Value";
        }

        // Obter o NIF do cliente selecionado, ao mudar item selecionado na combobox.
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilizador? clienteSelecionado = cmbClientes.SelectedItem as Utilizador;
            txtNIF.Text = clienteSelecionado.Nif.ToString();
        }

        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            string enteredNif = txtNIF.Text;

            // Verifica se o NIF introduzido não está vazio e se é um número válido
            if (!string.IsNullOrWhiteSpace(enteredNif) && int.TryParse(enteredNif, out int nifParsed))
            {
                // Verifica se existe algum cliente correspondente com esse NIF
                
                var clienteCorrespondente = _clientes.FirstOrDefault(c => c.Nif == nifParsed);
                if (clienteCorrespondente != null)
                {
                    cmbClientes.SelectedItem = clienteCorrespondente;
                }
                else
                {
                    cmbClientes.SelectedIndex = -1;
                }


                // Sempre que o texto de NIF alterar, calcula a garantia de venda
                if (enteredNif.Length == 9) // Verifica se o NIF introduzido tem exatamente 9 caracteres
                {
                    // Se NIF começar com '1', '2' ou '3', é cliente particular
                    // Caso contrário, é empresa
                    if (enteredNif.StartsWith("1") || enteredNif.StartsWith("2") || enteredNif.StartsWith("3"))
                    {
                        mesesGarantia = 36; // Garantia de 36 meses para cliente particular
                    }
                    else
                    {
                        mesesGarantia = 12; // Garantia de 12 meses para empresas
                    }
                }
                else
                {
                    mesesGarantia = 36; // Valor padrão de garantia caso o NIF não tenha 9 caracteres
                }

            }
            else
            {
                // Se o NIF não for válido, desmarcar a seleção do cliente
                cmbClientes.SelectedIndex = -1;
            }


            // Atualiza o texto de garantia
            txtGarantia.Text = $"{mesesGarantia} meses";
        }

        // Quando um produto é adicionado à fatura
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


        // Atualizar o total bruto da venda e calcular o total líquido com descontos
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
                    Produto produto = produtoRepo.GetById(produtoId);
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



        // Obter o desconto aplicável à categoria de um produto
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


        // Verificar campanhas baseadas nos dados na dgvFatura
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
                    Produto produto = produtoRepo.GetById(Convert.ToInt32(idProduto));
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


        // Atualizar o ListView com as campanhas aplicáveis
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


        // Retorna nome de categoria através do ID
        private string ObterNomeCategoria(int? categoriaId) { return categoriaRepo.GetById(categoriaId).Nome ?? "Desconhecida"; }

        // Retorna nome de marca através do ID
        private string ObterNomeMarca(int? marcaId) { return marcaRepo.GetById(marcaId).Nome ?? "Desconhecida"; }
       

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



        private void dgvFatura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFatura.Columns["Quantidade"].Index)
            {
                AtualizarTotais();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validação de entrada
            if (!ValidarVenda())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios e adicione pelo menos um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Criar a venda
            Venda venda = CriarVenda();

            try
            {
                // Atualizar o stock dos produtos vendidos
                foreach (var itemVenda in venda.Itens)
                {
                    Produto produto = produtoRepo.GetById(itemVenda.ProdutoID);
                    if (produto != null)
                    {
                        // Subtrai a quantidade vendida do stock de cada produto
                        produto.QuantidadeEmStock -= itemVenda.Unidades;

                        // Atualiza o produto no repositório
                        produtoRepo.Update(produto);
                    }
                }

                // Guarda a venda no repositório
                VendaRepo vendaRepo = new(new UtilizadorRepo());
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


        // Validação da venda antes de gravar
        // Tem de ter valores na dgvFatura e método de pagamento.
        private bool ValidarVenda()
        {
            if (dgvFatura.Rows.Count == 0)
                return false;

            if (cmbMetodoPagamento.SelectedIndex < 0)
                return false;

            return true;
        }

        // Criar objeto Venda com os dados do formulário
        private Venda CriarVenda()
        {
            Venda venda = new()
            {
                ClienteID = (int?)cmbClientes.SelectedValue,
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

                    Produto produto = produtoRepo.GetById(produtoID);

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

       private void btnRemItem_Click_1(object sender, EventArgs e)
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

        private void btnAddProduto_Click_1(object sender, EventArgs e)
        {

            Produto produtoSelecionado = cmbProdutos.SelectedItem as Produto;
            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto antes de adicionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidadeDesejada = (int)nudQtd.Value;

            // Verificar stock disponível considerando o que já foi adicionado na fatura
            int quantidadeTotalFatura = dgvFatura.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["Produto"].Value?.ToString() == produtoSelecionado.Nome)
                .Sum(row => Convert.ToInt32(row.Cells["Quantidade"].Value));

            int quantidadeDisponivel = (produtoSelecionado.QuantidadeEmStock - quantidadeTotalFatura);

            // Operador ternário para se a quantidade disponível for negativa, mostrar apenas 0.
            quantidadeDisponivel = quantidadeDisponivel < 0 ? 0 : quantidadeDisponivel;

            if (quantidadeDesejada <= 0 || quantidadeDesejada > quantidadeDisponivel)
            {
                MessageBox.Show($"Quantidade inválida ou insuficiente no stock! Disponível: {quantidadeDisponivel}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar se o produto já está na fatura e atualizar a quantidade
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

            // Adicionar novo produto à fatura
            dgvFatura.Rows.Add(produtoSelecionado.Id, produtoSelecionado.Nome, ObterNomeCategoria(produtoSelecionado.CategoriaID), ObterNomeMarca(produtoSelecionado.MarcaID), quantidadeDesejada, produtoSelecionado.Preco);
            AtualizarTotais();

            // Verificar campanhas aplicáveis
            VerificarCampanhas();
        }



        private void btnAddProduto_MouseEnter(object sender, EventArgs e) => btnAddProduto.ForeColor = Color.DodgerBlue;
        private void btnAddProduto_MouseLeave(object sender, EventArgs e) => btnAddProduto.ForeColor = Color.Black;
        private void btnRemItem_MouseEnter(object sender, EventArgs e) => btnRemItem.ForeColor = Color.Red;
        private void btnRemItem_MouseLeave(object sender, EventArgs e) => btnRemItem.ForeColor = Color.Black;

    }
}
