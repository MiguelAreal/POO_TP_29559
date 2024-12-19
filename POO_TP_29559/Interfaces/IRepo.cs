/**
 * @file IRepo.cs
 * @brief Interface para a definição de operações de repositório genérico.
 * 
 * Esta interface define os métodos básicos que devem ser implementados para
 * a gestão de dados de uma entidade do tipo genérico `T`. As operações incluem
 * a obtenção, adição, remoção e atualização de itens no repositório.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

namespace poo_tp_29559.Interfaces
{
    /**
     * @interface IRepo
     * @brief Interface para a definição de operações de um repositório genérico.
     * 
     * A interface `IRepo<T>` define os métodos essenciais para a manipulação de dados de
     * um repositório genérico, onde `T` representa o tipo de entidade armazenada. A
     * interface pode ser implementada por repositórios que armazenam dados em diferentes
     * fontes, como base de dados ou ficheiros.
     * 
     * @tparam T Tipo genérico que representa a entidade armazenada no repositório.
     */
    public interface IRepo<T> where T : class
    {
        /**
         * @brief Obtém todos os itens do repositório.
         * 
         * Método responsável por obter todos os itens armazenados no repositório.
         * 
         * @return Uma lista de objetos do tipo `T`, representando todos os itens
         *         armazenados.
         */
        List<T> GetAll();

        /**
         * @brief Adiciona um item ao repositório.
         * 
         * Método para adicionar um novo item ao repositório. O item será guardado
         * no repositório para operações futuras.
         * 
         * @param item O item a ser adicionado ao repositório.
         */
        void Add(T item);

        /**
         * @brief Remove um item do repositório.
         * 
         * Método para remover um item existente do repositório. O item será excluído
         * e não estará mais disponível nas operações subsequentes.
         * 
         * @param item O item a ser removido do repositório.
         */
        void Remove(T item);

        /**
         * @brief Atualiza um item no repositório.
         * 
         * Método responsável por atualizar os dados de um item existente no repositório.
         * As alterações no item são persistidas no repositório.
         * 
         * @param item O item com as alterações a serem aplicadas.
         */
        void Update(T item);
    }
}
