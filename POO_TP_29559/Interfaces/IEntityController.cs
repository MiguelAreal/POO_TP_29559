/// <summary>
/// Interface para a definição de operações de controle de entidades genéricas.
/// </summary>
/// <remarks>
/// Esta interface define os métodos básicos para a gestão de entidades, como filtrar, obter, atualizar e remover itens.  
/// É genérica e pode ser usada com diferentes tipos de entidades na aplicação.
/// </remarks>
public interface IEntityController
{
    /// <summary>
    /// Obtém um item pelo seu identificador único.
    /// </summary>
    /// <param name="id">Identificador único do item a ser recuperado.</param>
    /// <returns>O item correspondente ao identificador fornecido, ou <c>null</c> se não encontrado.</returns>
    object GetById(int? id);

    /// <summary>
    /// Remove um item do sistema.
    /// </summary>
    /// <param name="item">O item a ser removido. Será excluído permanentemente.</param>
    void RemoveItem(object item);

    /// <summary>
    /// Atualiza os dados de um item existente no sistema.
    /// </summary>
    /// <param name="item">O item a ser atualizado com as novas informações fornecidas.</param>
    void UpdateItem(object item);

    /// <summary>
    /// Obtém todos os itens armazenados no sistema.
    /// </summary>
    /// <returns>Uma lista de todos os itens armazenados.</returns>
    List<object> GetItems();

    /// <summary>
    /// Filtra itens com base em critérios específicos.
    /// </summary>
    /// <param name="items">A lista de itens a ser filtrada.</param>
    /// <param name="filtro">O valor de filtro usado para realizar a busca.</param>
    /// <param name="coluna">A coluna ou propriedade opcional pela qual os itens serão filtrados. Pode ser <c>null</c>.</param>
    /// <returns>Uma lista de itens que correspondem aos critérios de filtro.</returns>
    List<object> FiltrarItens(List<object> items, string filtro, string? coluna);
}
