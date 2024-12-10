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
        private readonly VendaController _controller;
        private readonly ChildForm _view;
        ProdutoRepo produtoRepo = new();


        ClienteRepo clienteRepo = new();
        private List<Cliente> _clientes;

        public AddVendaForm(ChildForm view)
        {
            InitializeComponent();
            CarregaProdutos();
            CarregaClientes();
            CarregaMetodosPagamento();
        }

        // Carregar produtos da base de dados
        private void CarregaProdutos()
        {
            List<Produto> produtos = produtoRepo.GetAll();

            produtos = produtos.OrderBy(p => p.Nome).ToList();

            if (produtos != null)
            {
                cmbProdutos.DataSource = produtos;
                cmbProdutos.DisplayMember = "Nome";
                cmbProdutos.ValueMember = "Id";
            }
        }

        // Carregar clientes da base de dados
        private void CarregaClientes()
        {
            _clientes = clienteRepo.GetAll().OrderBy(c => c.Nome).ToList();

            if (_clientes != null)
            {
                cmbClientes.DataSource = _clientes;
                cmbClientes.DisplayMember = "Nome";
                cmbClientes.ValueMember = "Id";
            }
        }

        // Carregar métodos de pagamento
        private void CarregaMetodosPagamento()
        {
            var metodosPagamento = EnumHelper.GetEnumDescriptions<MetodoPagamento>();

            cmbMetodoPagamento.DataSource = metodosPagamento;
            cmbMetodoPagamento.DisplayMember = "Key";
            cmbMetodoPagamento.ValueMember = "Value";
        }

        // Obter o NIF do cliente selecionado
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = cmbClientes.SelectedItem as Cliente;
            getNIF(clienteSelecionado);
        }

        // Atualizar o campo de NIF baseado no cliente selecionado
        private void getNIF(Cliente selectedCliente)
        {
            if (selectedCliente != null && !string.IsNullOrWhiteSpace(selectedCliente.Nif))
            {
                txtNIF.Text = selectedCliente.Nif;
            }

        }

        // Atualiza  CMB Cliente baseado no NIF introduzido
        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            string enteredNif = txtNIF.Text;
            if (!string.IsNullOrWhiteSpace(enteredNif))
            {
                var clienteCorrespondente = _clientes.FirstOrDefault(c => c.Nif == enteredNif);
                if (clienteCorrespondente != null)
                    cmbClientes.SelectedItem = clienteCorrespondente;
                else
                    cmbClientes.SelectedIndex = -1;
            }

            //Sempre que o texto de NIF alterar, calcula garantia de venda
            if (txtNIF.TextLength == 9)
            {
                // Se NIF começar com '1', '2' ou '3', É cliente particular. Outrora, é Empresa.
                // Faz diferença no cálculo da garantia associada.
                if (txtNIF.Text.StartsWith("1") || txtNIF.Text.StartsWith("2") || txtNIF.Text.StartsWith("3"))
                {
                    txtGarantia.Text = "36 Meses";
                }
                else
                {
                    txtGarantia.Text = "12 Meses";
                }
            }
            else
            {
                txtGarantia.Text = "36 Meses";
            }
        }

        // Quando um produto é adicionado à venda
        // Quando um produto é adicionado à venda
        private void btnAddProduto_Click(object sender, EventArgs e)
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


        // Atualizar o total bruto da venda e calcular o total líquido com descontos
        private void AtualizarTotais()
        {
            decimal totalBruto = 0;
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
            decimal totalLiquido = totalBruto - totalDesconto;

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



        // Carregar categorias e marcas associadas aos produtos
        private string ObterNomeCategoria(int? categoriaId)
        {
            CategoriaRepo categoriaRepo = new();
            Categoria categoria = categoriaRepo.GetById(categoriaId);
            return categoria?.Nome ?? "Desconhecida";
        }

        private string ObterNomeMarca(int? marcaId)
        {
            MarcaRepo marcaRepo = new();
            Marca marca = marcaRepo.GetById(marcaId);
            return marca?.Nome ?? "Desconhecida";
        }

        private void txtNIF_Leave(object sender, EventArgs e)
        {
            if (txtNIF.Text.Length != 9)
            {
                MessageBox.Show("A proceder sem NIF. NIF inválido.");
                txtNIF.Clear();
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
    }
}
