using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

/**
 * @class MarcaController
 * @brief Controlador para a gestão de marcas.
 * 
 * A classe `MarcaController` implementa a lógica para a gestão das marcas, incluindo operações de leitura, remoção e carregamento de dados externos, como a lista de países. Herda de `BaseController<Marca>` e implementa a interface `IEntityController`, fornecendo funcionalidades específicas para o trabalho com marcas.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class MarcaController : BaseController<Marca>, IEntityController
{
    /**
     * @brief Construtor da classe `MarcaController`.
     * 
     * Inicializa o controlador com o caminho do ficheiro de dados onde as marcas serão armazenadas.
     */
    public MarcaController() : base("Data/marcas.json") { }

    /**
     * @brief Remove uma marca do repositório.
     * 
     * Este método sobrepõe o método `RemoveItem` da classe base e tenta remover a marca fornecida do repositório,
     * mas apenas se a marca não estiver associada a nenhum produto. Caso contrário, é exibida uma mensagem de erro.
     * 
     * @param item A marca a ser removida.
     */
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

    /**
     * @brief Carrega a lista de países a partir de um ficheiro JSON.
     * 
     * Este método lê um ficheiro JSON contendo uma lista de países e retorna essa lista como uma lista de strings.
     * Caso o ficheiro não exista ou ocorra um erro ao lê-lo, retorna uma lista vazia e exibe uma mensagem de erro.
     * 
     * @return Uma lista de strings contendo os nomes dos países. Se houver erro, retorna uma lista vazia.
     */
    public List<string> CarregaPaises()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Data", "paises.json");  /**< Caminho do ficheiro JSON. */

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
}
