using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

public class MarcaController : BaseController<Marca>, IEntityController
{
    public MarcaController() : base("Data/marcas.json") { }
    
    //Verifica se a marca pode ser eliminada antes de o fazer.
    public override void RemoveItem(Marca item)
    {
        var produtos = new ProdutoRepo().GetAll();

        if (item.PodeSerEliminada(produtos))
        {
            _repository.Remove(item);
        }
        else
        {
            MessageBox.Show("Esta marca não pode ser eliminada porque está associada a um ou mais produtos.");
        }
    }

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
