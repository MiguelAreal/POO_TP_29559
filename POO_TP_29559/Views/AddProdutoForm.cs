using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddProdutoForm : MetroForm
    {
        private readonly ProdutoController _controller;

        // Parâmetro opcional
        public AddProdutoForm()
        {
            InitializeComponent();
            var categoriaRepo = new CategoriaRepo();
            var marcaRepo = new MarcaRepo();
            _controller = new ProdutoController();
        }

        private void AddProdutoForm_Load(object sender, EventArgs e)
        {
            CarregaMarcas();
            CarregaCategorias();
        }

        private void CarregaMarcas()
        {
            // Use BaseRepo diretamente para carregar marcas
            MarcaRepo marcaRepo = new();
            List<Marca> marcas = marcaRepo.GetAll();

            marcas = marcas.OrderBy(m => m.Nome).ToList();

            if (marcas != null)
            {
                cmbMarca.DataSource = marcas;
                cmbMarca.DisplayMember = "Nome";
                cmbMarca.ValueMember = "Id";
            }
        }

        private void CarregaCategorias()
        {
            // Use BaseRepo diretamente para carregar marcas
            CategoriaRepo categoriaRepo = new();
            List<Categoria> categorias = categoriaRepo.GetAll();

            categorias = categorias.OrderBy(m => m.Nome).ToList();

            if (categorias != null)
            {
                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, cmbCategoria, cmbMarca, nudPreco, nudStock };
            Label[] labels = { lblNome, lblCategoria, lblMarca, lblPreco, lblStock };
            bool allValid = FieldValidator.ValidateFields(controls, labels);


            var categoriaSelecionada = cmbCategoria.SelectedItem as Categoria;
            var marcaSelecionada = cmbMarca.SelectedItem as Marca;

            var novoProduto = new Produto
            {
                Nome = txtNome.Text,
                CategoriaID = categoriaSelecionada.Id,
                MarcaID = marcaSelecionada.Id,
                Preco = nudPreco.Value,
                QuantidadeEmStock = Convert.ToInt32(nudStock.Value)
            };

            _controller.AddItem(novoProduto);
            this.Close();
        }
    }
}
