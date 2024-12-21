/// <summary>
/// Classe base abstrata para controlo de entidades genéricas.
/// Implementa operações CRUD (Criar, Ler, Atualizar e Apagar) sobre um repositório genérico.
/// </summary>
/// <typeparam name="T">Tipo genérico que deve implementar a interface IIdentifiable.</typeparam>
public abstract class BaseController<T> where T : class, IIdentifiable
{
    /// <summary>
    /// Referência ao repositório base utilizado para operações nos itens.
    /// </summary>
    protected readonly BaseRepo<T> _repository;

    /// <summary>
    /// Lista local de itens atualmente carregados.
    /// </summary>
    protected List<T> _items;

    /// <summary>
    /// Construtor da classe BaseController.
    /// Inicializa o repositório com base no caminho de ficheiro fornecido.
    /// </summary>
    /// <param name="filePath">Caminho do ficheiro onde os dados serão armazenados.</param>
    public BaseController(string filePath) => _repository = new BaseRepo<T>(filePath);

    /// <summary>
    /// Adiciona um novo item ao repositório.
    /// </summary>
    /// <param name="item">O item a ser adicionado.</param>
    public void AddItem(T item)
    {
        _repository.Add(item);
    }

    /// <summary>
    /// Obtém um item pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador único do item a ser obtido.</param>
    /// <returns>O item correspondente ao identificador, ou null se não existir.</returns>
    public object GetById(int? id)
    {
        return _repository.GetById(id);
    }

    /// <summary>
    /// Remove um item específico.
    /// Este método pode ser re-implementado pelas classes derivadas para definir a lógica de remoção.
    /// </summary>
    /// <param name="item">O item a ser removido.</param>
    public virtual void RemoveItem(object item)
    {
        if (item is T specificItem)
        {
            _repository.Remove(specificItem);
        }
    }

    /// <summary>
    /// Atualiza um item específico.
    /// Este método pode ser re-implementado pelas classes derivadas para definir a lógica de atualização.
    /// </summary>
    /// <param name="item">O item a ser atualizado.</param>
    public virtual void UpdateItem(object item)
    {
        if (item is T specificItem)
        {
            _repository.Update(specificItem);
        }
    }

    /// <summary>
    /// Obtém todos os itens do repositório.
    /// </summary>
    /// <returns>Uma lista de objetos do tipo T.</returns>
    public virtual List<object> GetItems()
    {
        _items = _repository.GetAll();
        return _items.Cast<object>().ToList(); // Default implementation
    }

    /// <summary>
    /// Filtra itens com base em uma propriedade e um filtro.
    /// </summary>
    /// <param name="items">Lista de itens a ser filtrada.</param>
    /// <param name="filtro">Texto usado para filtrar os itens.</param>
    /// <param name="coluna">Nome da propriedade a ser filtrada.</param>
    /// <returns>Lista de itens filtrados.</returns>
    public List<object> FiltrarItens(List<object> items, string filtro, string coluna)
    {
        // Verifique se o filtro e a coluna são válidos
        if (string.IsNullOrEmpty(filtro) || string.IsNullOrEmpty(coluna))
        {
            return new List<object>();
        }

        try
        {
            // Filtra os itens com base no nome da propriedade (coluna) e no texto de busca
            var itensFiltrados = items.Where(model =>
            {
                // Obtém a propriedade correspondente à coluna
                var prop = model.GetType().GetProperty(coluna);
                if (prop != null)
                {
                    // Obtém o valor da propriedade
                    var value = prop.GetValue(model)?.ToString() ?? string.Empty;

                    // Retorna verdadeiro se o valor da propriedade contiver o filtro (de forma case-insensitive)
                    return value.StartsWith(filtro, StringComparison.OrdinalIgnoreCase);
                }
                return false; // Caso a propriedade não exista, retorna false
            }).ToList();

            return itensFiltrados.Cast<object>().ToList();
        }
        catch (Exception ex)
        {
            // Trata qualquer exceção de forma adequada (pode ser uma exceção de reflexão ou outro erro)
            MessageBox.Show($"Erro ao aplicar filtro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<object>(); // Retorna uma lista total em caso de erro
        }
    }
}
