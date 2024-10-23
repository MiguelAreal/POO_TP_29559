using MetroFramework.Forms;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            // Valida os campos antes de adicionar o produto
            if (!ValidateFields())
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
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
            _controller.AtualizaProdutos();
            
            

            this.Close();
        }


        private bool ValidateFields()
        {
            // Variável para verificar se todos os campos estão válidos
            bool isValid = true;

            // Valida os campos
            isValid &= ValidateField(txtNome, lblNome);
            isValid &= ValidateField(cmbCategoria, lblCategoria);
            isValid &= ValidateField(cmbMarca, lblMarca);
            isValid &= ValidateField(nudPreco, lblPreco);
            isValid &= ValidateField(nudStock, lblStock);

            return isValid;
        }

        // Método auxiliar para validar um campo e seu respectivo label
        private bool ValidateField(Control control, Label label)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                label.ForeColor = Color.Red;
                return false;
            }
            else
            {
                label.ForeColor = Color.Black; 
                return true;
            }
        }



    }
}
