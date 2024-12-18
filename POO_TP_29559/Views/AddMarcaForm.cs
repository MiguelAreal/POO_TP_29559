/** @file AddMarcaForm.cs
* @brief Formulário para adicionar uma nova marca.
*
* Este formulário permite ao utilizador adicionar uma nova marca ao sistema. Ele solicita informações sobre o nome da marca, 
* a descrição e o país de origem. Utiliza o `MarcaController` para adicionar a marca ao sistema e carrega uma lista de países 
* a partir de um ficheiro JSON para que o utilizador possa selecionar o país de origem.
*
* @author Miguel Areal
* @date 12/2024
*/


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
    /**
     * @class AddMarcaForm
     * @brief Formulário para a criação de uma nova marca.
     * 
     * Este formulário serve para criar e adicionar uma nova marca ao sistema. O utilizador preenche o nome, a descrição e o 
     * país de origem da marca. O formulário também inclui validação de campos e carrega os países disponíveis a partir de um 
     * ficheiro JSON.
     */
    public partial class AddMarcaForm : MetroForm
    {
        private readonly MarcaController _controller; /**< Controlador responsável pela manipulação de marcas. */

        /**
         * @brief Construtor do `AddMarcaForm`.
         * 
         * Inicializa o controlador de marcas e carrega a lista de países disponíveis para a seleção no combo box.
         */
        public AddMarcaForm()
        {
            InitializeComponent();

            _controller = new MarcaController();  /**< Inicializa o controlador de marcas. */

            CarregaPaises();  /**< Carrega a lista de países a partir de um ficheiro JSON. */
        }

        /**
         * @brief Carrega os países disponíveis a partir do controlador de marcas.
         * Exibe os países na combobox, e adiciona coleção de auto-completar.
         */
        private void CarregaPaises()
        {
            List<string> paises = _controller.CarregaPaises();
            // Verifica se o arquivo de países existe
            if (paises != null)
            {
                // Configura a ComboBox para exibir os países
                cmbPais.DataSource = paises;  /**< Define a fonte de dados da ComboBox. */
                cmbPais.AutoCompleteMode = AutoCompleteMode.SuggestAppend;  /**< Define o modo de auto-completar da ComboBox. */
                cmbPais.AutoCompleteSource = AutoCompleteSource.CustomSource;  /**< Define a fonte de auto-completar. */

                // Preenche o AutoCompleteCustomSource com os países
                AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
                autoCompleteData.AddRange(paises.ToArray());
                cmbPais.AutoCompleteCustomSource = autoCompleteData;  /**< Define a coleção de auto-completar. */
            }
        }

        /**
         * @brief Evento de clique no botão de confirmação.
         * 
         * Este evento é acionado quando o utilizador clica no botão de confirmação para adicionar uma nova marca.
         * Valida os campos do formulário e, caso todos os campos sejam válidos, cria uma nova marca e a adiciona ao sistema.
         * 
         * @param sender Objeto que disparou o evento.
         * @param e Dados do evento.
         */
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Array de controlos a serem validados
            Control[] controls = { txtNome, cmbPais };

            // Array de labels correspondentes aos controlos
            Label[] labels = { lblNome, lblPais };

            // Valida os campos utilizando a biblioteca de validação
            bool allValid = FieldValidator.ValidateFields(controls, labels);

            // Se algum campo for inválido, interrompe o processo
            if (!allValid)
            {
                return;
            }

            // Criação da nova marca com os dados fornecidos
            var novaMarca = new Marca
            {
                Nome = txtNome.Text,  /**< Nome da marca. */
                Descricao = txtDescricao.Text,  /**< Descrição da marca. */
                PaisOrigem = cmbPais.Text  /**< País de origem da marca. */
            };

            // Adiciona a nova marca ao sistema
            _controller.AddItem(novaMarca);

            // Fecha o formulário após a adição da marca
            this.Close();
        }
    }
}
