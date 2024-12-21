using poo_tp_29559.Models;
using poo_tp_29559.Repositories;

public class CampanhaController : BaseController<Campanha>, IEntityController
{
    #region Fields and Properties

    /// <summary>
    /// Lista de campanhas com nomes, usada para exibição na interface gráfica.
    /// </summary>
    private List<CampanhaViewModel>? _campanhasComNomes;

    #endregion

    #region Constructor

    /// <summary>
    /// Construtor da classe <see cref="CampanhaController"/>.
    /// Inicializa o controlador com o caminho do ficheiro de dados onde as campanhas serão armazenadas.
    /// </summary>
    public CampanhaController() : base("Data/campanhas.json") { }

    #endregion

    #region Data Retrieval

    /// <summary>
    /// Obtém todas as campanhas, traduzindo os IDs para nomes legíveis.
    /// Recupera todas as campanhas do repositório e cria uma lista de modelos de visualização
    /// (<see cref="CampanhaViewModel"/>) substituindo os identificadores das categorias pelos seus respectivos nomes.
    /// </summary>
    /// <returns>
    /// Uma lista de objetos <see cref="CampanhaViewModel"/> com as campanhas e os nomes das categorias.
    /// </returns>
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

    #endregion
}
