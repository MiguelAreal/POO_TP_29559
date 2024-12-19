/**
 * @file ProdutoRepo.cs
 * @brief Repositório especializado na manipulação de produtos.
 * 
 * A classe `ProdutoRepo` é uma especialização da classe base `BaseRepo<Produto>`,
 * responsável pela persistência e manipulação de produtos. A classe lida com operações
 * específicas para objetos do tipo `Produto`.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /**
     * @class ProdutoRepo
     * @brief Repositório para a manipulação de produtos.
     * 
     * A classe `ProdutoRepo` herda de `BaseRepo<Produto>` e é especializada na manipulação
     * de objetos do tipo `Produto`. Ela oferece as funcionalidades básicas de um repositório,
     * como a adição, remoção, atualização e obtenção de produtos a partir de um ficheiro JSON.
     * 
     * @see BaseRepo
     */
    public class ProdutoRepo : BaseRepo<Produto>
    {
        /**
         * @brief Construtor da classe `ProdutoRepo`.
         * 
         * Inicializa o repositório de produtos com o caminho do ficheiro JSON onde os dados
         * serão armazenados. O ficheiro pré-definido utilizado é `Data/produtos.json`.
         */
        public ProdutoRepo() : base("Data/produtos.json") { }
    }
}
