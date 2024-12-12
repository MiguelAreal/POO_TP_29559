using MetroFramework.Forms;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using ValidationLibrary;

namespace poo_tp_29559.Views
{
    public partial class AddMarcaForm : MetroForm
    {
        private readonly MarcaController _controller;

        public AddMarcaForm()
        {
            InitializeComponent();
            _controller = new MarcaController();

            // Carrega os países na ComboBox ao iniciar o formulário
            CarregaPaises();
        }

        private void CarregaPaises()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Data", "paises.json");
            // Verifica se o arquivo existe
            if (File.Exists(filePath))
            {
                try
                {
                    // Lê o conteúdo do JSON e desserializa em uma lista de strings
                    string json = File.ReadAllText(filePath);
                    List<string> paises = JsonSerializer.Deserialize<List<string>>(json);

                    if (paises != null)
                    {
                        // Configura a ComboBox
                        cmbPais.DataSource = paises;
                        // Define o AutoComplete
                        cmbPais.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbPais.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        // Preenche o AutoCompleteCustomSource com a lista de países
                        AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                        autoCompleteData.AddRange(paises.ToArray());
                        cmbPais.AutoCompleteCustomSource = autoCompleteData;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar países: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("O ficheiro de países não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtNome, cmbPais };
            Label[] labels = { lblNome, lblPais };
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            if (!allValid)
            {
                return;
            }

            var novaMarca = new Marca
            {
                Nome = txtNome.Text,
                Descricao = txtDescricao.Text,
                PaisOrigem = cmbPais.Text
            };

            _controller.AddItem(novaMarca);

            this.Close();
        }
    }
}
