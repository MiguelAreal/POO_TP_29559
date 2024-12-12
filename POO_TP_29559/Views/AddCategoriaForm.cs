﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddCategoriaForm : MetroForm
    {
        private readonly CategoriaController _controller;

        public AddCategoriaForm()
        {
            InitializeComponent();
            _controller = new CategoriaController();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            Control[] controls = { txtNome };
            Label[] labels = { lblNome };
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Valida os campos antes de adicionar o produto
            if (!allValid)
            {
                return;
            }

            var novaCategoria = new Categoria
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
            };

            // Adiciona o novo produto através do controlador
            _controller.AddItem(novaCategoria);


            this.Close();
        }

      
    }


}
