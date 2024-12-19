using poo_tp_29559.Interfaces;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Windows.Forms;

/**
 * @class CampanhaController
 * @brief Controlador para a gestão de campanhas.
 * 
 * A classe `CampanhaController` implementa a lógica para a gestão de campanhas, incluindo operações de leitura
 * e manipulação de dados. Herda de `BaseController<Campanha>` e implementa a interface `IEntityController`, 
 * oferecendo funcionalidades específicas para o trabalho com campanhas, incluindo a tradução de identificadores
 * para nomes legíveis na interface de utilizador.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class CampanhaController : BaseController<Campanha>, IEntityController
{
    /// @brief Lista de campanhas com nomes, usada para exibição na interface gráfica.
    private List<CampanhaViewModel>? _campanhasComNomes;

    /**
     * @brief Construtor da classe `CampanhaController`.
     * 
     * Inicializa o controlador com o caminho do ficheiro de dados onde as campanhas serão armazenadas.
     */
    public CampanhaController() : base("Data/campanhas.json") { }

    /**
     * @brief Obtém todas as campanhas, traduzindo os IDs para nomes legíveis.
     * 
     * Este método recupera todas as campanhas do repositório e cria uma lista de modelos de visualização
     * (`CampanhaViewModel`), substituindo os identificadores das categorias pelos seus respectivos nomes.
     * 
     * @return Uma lista de objetos `CampanhaViewModel` com as campanhas e os nomes das categorias.
     */
    public override List<object> GetItems()
    {
        List<Campanha> campanhas = _repository.GetAll();

        _campanhasComNomes = new List<CampanhaViewModel>();

        foreach (var campanha in campanhas)
        {
            // Traduz IDs para nomes
            Categoria? categoria = new CategoriaRepo().GetById(campanha.CategoriaId);

            // Cria view model com campanhas em vez de IDs para visualização
            var campanhaViewModel = new CampanhaViewModel
            {
                Id = campanha.Id,
                Nome = campanha.Nome,
                PercentagemDesc = campanha.PercentagemDesc,
                DataInicio = campanha.DataInicio,
                DataFim = campanha.DataFim,
                CategoriaNome = categoria?.Nome,
            };

            _campanhasComNomes.Add(campanhaViewModel);
        }

        // Passa a lista de campanhas com nomes para a vista
        return _campanhasComNomes.Cast<object>().ToList();
    }
}
