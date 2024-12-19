/**
 * @file MarcaRepo.cs
 * @brief Repositório especializado na manipulação de marcas.
 * 
 * A classe `MarcaRepo` é uma especialização da classe base `BaseRepo<Marca>`,
 * responsável pela persistência e manipulação de marcas. A classe lida com operações
 * específicas para objetos do tipo `Marca`.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /**
     * @class MarcaRepo
     * @brief Repositório para a manipulação de marcas.
     * 
     * A classe `MarcaRepo` herda de `BaseRepo<Marca>` e é especializada na manipulação
     * de objetos do tipo `Marca`. Ela oferece as funcionalidades básicas de um repositório,
     * como a adição, remoção, atualização e obtenção de marcas a partir de um ficheiro JSON.
     * 
     * @see BaseRepo
     */
    public class MarcaRepo : BaseRepo<Marca>
    {
        /**
         * @brief Construtor da classe `MarcaRepo`.
         * 
         * Inicializa o repositório de marcas com o caminho do ficheiro JSON onde os dados
         * serão armazenados. O ficheiro pré-definido utilizado é `Data/marcas.json`.
         */
        public MarcaRepo() : base("Data/marcas.json") { }
    }
}
