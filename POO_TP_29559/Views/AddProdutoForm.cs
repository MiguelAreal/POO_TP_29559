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
        private MarcaController marcaController;
        private CategoriaController categoriaController;

        private List<Marca> _marcas;
        private List<Categoria> _categorias;

        public AddProdutoForm()
        {
            InitializeComponent();
            _controller = new ProdutoController();
            marcaController = new MarcaController();
            categoriaController = new CategoriaController();
        }

        private void AddProdutoForm_Load(object sender, EventArgs e)
        {
            CarregaMarcas();
            CarregaCategorias();
        }

      
        private void CarregaMarcas()
        {
            _marcas = (List<Marca>)marcaController.GetItems();
            _marcas = _marcas.OrderBy(m => m.Nome).ToList();

            if (_marcas != null)
            {
                cmbMarca.DataSource = _marcas;
                cmbMarca.DisplayMember = "Nome";
                cmbMarca.ValueMember = "Id";
            }
        }

        private void CarregaCategorias()
        {
            _categorias = (List<Categoria>)categoriaController.GetItems();
            _categorias = _categorias.OrderBy(m => m.Nome).ToList();

            if (_categorias != null)
            {
                cmbCategoria.DataSource = _categorias;
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
