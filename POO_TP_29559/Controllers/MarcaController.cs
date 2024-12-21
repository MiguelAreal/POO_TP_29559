using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;
using System;

public class MarcaController : BaseController<Marca>, IEntityController
{
    #region Constructor

    /// <summary>
    /// Construtor da classe <see cref="MarcaController"/>.
    /// Inicializa o controlador com o caminho do ficheiro de dados onde as marcas serão armazenadas.
    /// </summary>
    public MarcaController() : base("Data/marcas.json") { }

    #endregion

    #region Remove Item

    /// <summary>
    /// Remove uma marca do repositório.
    /// Este método sobrepõe o método <see cref="BaseController{T}.RemoveItem"/> da classe base
    /// e tenta remover a marca fornecida do repositório, mas apenas se a marca não estiver associada a nenhum produto.
    /// Caso contrário, é exibida uma mensagem de erro.
    /// </summary>
    /// <param name="item">A marca a ser removida.</param>
    public override void RemoveItem(object item)
    {
        if (item is Marca specificItem)
        {
            var produtos = new ProdutoRepo().GetAll();

            if (specificItem.PodeSerEliminada(produtos))
            {
                _repository.Remove(specificItem);
            }
            else
            {
                MessageBox.Show("Esta marca não pode ser eliminada porque está associada a um ou mais produtos.");
            }
        }
    }

    #endregion

    #region Load Countries

    /// <summary>
    /// Carrega a lista de países a partir de um ficheiro JSON.
    /// Lê um ficheiro JSON contendo uma lista de países e retorna essa lista como uma lista de strings.
    /// Caso o ficheiro não exista ou ocorra um erro ao lê-lo, retorna uma lista vazia e exibe uma mensagem de erro.
    /// </summary>
    /// <returns>
    /// Uma lista de strings contendo os nomes dos países. Se houver erro, retorna uma lista vazia.
    /// </returns>
    public List<string> CarregaPaises()
    {
        // Caminho do ficheiro JSON contendo os países
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Data", "paises.json");

        // Verifica se o ficheiro de países existe
        if (File.Exists(filePath))
        {
            try
            {
                // Lê o conteúdo do JSON e desserializa em uma lista de strings
                string json = File.ReadAllText(filePath);
                List<string> paises = JsonSerializer.Deserialize<List<string>>(json);

                if (paises != null)
                {
                    return paises;
                }
                else
                {
                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar países: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
        else
        {
            MessageBox.Show("O ficheiro de países não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return new List<string>();
        }
    }

    #endregion
}
