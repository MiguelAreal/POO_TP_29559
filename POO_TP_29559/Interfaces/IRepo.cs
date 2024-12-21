using System.Collections.Generic;

namespace poo_tp_29559.Interfaces
{
    /// <summary>
    /// Interface para a definição de operações de um repositório genérico.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo genérico que representa a entidade armazenada no repositório. Deve ser uma classe.
    /// </typeparam>
    /// <remarks>
    /// A interface <c>IRepo&lt;T&gt;</c> especifica os métodos essenciais para a manipulação de 
    /// dados em um repositório genérico. Pode ser implementada por repositórios que interagem com 
    /// diversas fontes de dados, como bases de dados ou ficheiros.
    /// </remarks>
    public interface IRepo<T> where T : class
    {
        /// <summary>
        /// Obtém todos os itens armazenados no repositório.
        /// </summary>
        /// <returns>
        /// Uma lista contendo todas as entidades do tipo <typeparamref name="T"/> armazenadas.
        /// </returns>
        List<T> GetAll();

        /// <summary>
        /// Adiciona um novo item ao repositório.
        /// </summary>
        /// <param name="item">O item a ser adicionado ao repositório.</param>
        void Add(T item);

        /// <summary>
        /// Remove um item existente do repositório.
        /// </summary>
        /// <param name="item">O item a ser removido do repositório.</param>
        void Remove(T item);

        /// <summary>
        /// Atualiza os dados de um item existente no repositório.
        /// </summary>
        /// <param name="item">O item com os dados atualizados a serem persistidos.</param>
        void Update(T item);
    }
}
