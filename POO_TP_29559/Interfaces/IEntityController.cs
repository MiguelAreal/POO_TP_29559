/**
 * @file IEntityController.cs
 * @brief Interface para a definição de operações de controlo de entidades genéricas.
 * 
 * Esta interface define os métodos básicos para a gestão de entidades, permitindo
 * a filtragem, obtenção, atualização e remoção de itens. A interface é genérica,
 * permitindo ser utilizada com diferentes tipos de entidades na aplicação.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public interface IEntityController
{
    /**
     * @brief Obtém um item pelo seu identificador.
     * 
     * Método responsável por obter um item do tipo genérico com base no seu identificador único.
     * 
     * @param id Identificador único do item a ser recuperado.
     * @return O item correspondente ao identificador fornecido, ou null se não encontrado.
     */
    object GetById(int? id);

    /**
     * @brief Remove um item.
     * 
     * Método responsável por remover um item do sistema. O item será excluído permanentemente.
     * 
     * @param item O item a ser removido.
     */
    void RemoveItem(object item);

    /**
     * @brief Atualiza um item.
     * 
     * Método responsável por atualizar os dados de um item existente no sistema.
     * O item será atualizado com as novas informações fornecidas.
     * 
     * @param item O item a ser atualizado.
     */
    void UpdateItem(object item);

    /**
     * @brief Obtém todos os itens.
     * 
     * Método responsável por obter todos os itens armazenados, retornando-os
     * como uma lista ou coleção.
     * 
     * @return A lista ou coleção de itens armazenados.
     */
    List<object> GetItems();
}
