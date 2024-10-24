using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddProdutoForm : MetroForm
    {
        private readonly ProdutoController _controller;
        private readonly ProdutosForm _view;

        //Parametro opcional
        public AddProdutoForm(ProdutosForm view)
        {
            InitializeComponent();

            _view = view;
            _controller = new ProdutoController(_view);
        }

        private void AddProdutoForm_Load(object sender, EventArgs e)
        {
            CarregaMarcas();
        }


        //Carrega as Marcas disponíveis para a combobox de Marcas.
        private void CarregaMarcas()
        {
            // Instancia o repositório de marcas
            MarcaRepo marcaRepo = new MarcaRepo();
            List<Marca> marcas = marcaRepo.GetAll(); // Obtém todas as marcas

            // Ordena as marcas pelo nome em ordem ascendente
            marcas = marcas.OrderBy(m => m.Nome).ToList();

            // Preenche a ComboBox com os nomes das marcas
            // Nos Produtos, guarda o ID da Marca, não o Nome da Marca
            cmbMarca.DataSource = marcas;
            cmbMarca.DisplayMember = "Nome";
            cmbMarca.ValueMember = "Nome";
            cmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, cmbCategoria,cmbMarca,nudPreco,nudStock};
            Label[] labels = { lblNome, lblCategoria,lblMarca,lblPreco,lblStock };
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Valida os campos antes de adicionar o produto
            if (!allValid)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            var novoProduto = new Produto
            {
                Nome = txtNome.Text,
                Categoria = cmbCategoria.Text,
                Marca = cmbMarca.Text,
                Preco = nudPreco.Value,
                QuantidadeEmStock = Convert.ToInt32(nudStock.Value)
            };

            // Adiciona o novo produto através do controlador
            _controller.AddItem(novoProduto);

            // Atualiza a DataGridView no form principal
            _controller.CarregaItens();



            this.Close();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
