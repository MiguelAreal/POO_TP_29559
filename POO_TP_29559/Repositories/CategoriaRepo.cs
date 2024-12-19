/**
 * @file CategoriaRepo.cs
 * @brief Repositório especializado na manipulação de categorias.
 * 
 * A classe `CategoriaRepo` é uma especialização da classe base `BaseRepo<Categoria>`,
 * responsável pela persistência e manipulação de categorias. A classe lida com operações
 * específicas para objetos do tipo `Categoria`.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /**
     * @class CategoriaRepo
     * @brief Repositório para a manipulação de categorias.
     * 
     * A classe `CategoriaRepo` herda de `BaseRepo<Categoria>` e é especializada na manipulação
     * de objetos do tipo `Categoria`. Ela oferece as funcionalidades básicas de um repositório,
     * como a adição, remoção, atualização e obtenção de categorias a partir de um ficheiro JSON.
     * 
     * @see BaseRepo
     */
    public class CategoriaRepo : BaseRepo<Categoria>
    {
        /**
         * @brief Construtor da classe `CategoriaRepo`.
         * 
         * Inicializa o repositório de categorias com o caminho do ficheiro JSON onde os dados
         * serão armazenados. O ficheiro pré-definido utilizado é `Data/categorias.json`.
         */
        public CategoriaRepo() : base("Data/categorias.json") { }
    }
}
