/**
 * @file VendaCompraRepo.cs
 * @brief Repositório especializado na manipulação de vendas e compras.
 * 
 * A classe `VendaCompraRepo` é uma especialização da classe base `BaseRepo<VendaCompra>`,
 * responsável pela persistência e manipulação de objetos `VendaCompra`. A classe lida com operações
 * específicas para vendas e compras, armazenando os dados em um ficheiro JSON.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /**
     * @class VendaCompraRepo
     * @brief Repositório para a manipulação de vendas e compras.
     * 
     * A classe `VendaCompraRepo` herda de `BaseRepo<VendaCompra>` e é especializada na manipulação
     * de objetos do tipo `VendaCompra`. Ela oferece as funcionalidades básicas de um repositório,
     * como a adição, remoção, atualização e obtenção de vendas e compras a partir de um ficheiro JSON.
     * 
     * @see BaseRepo
     */
    public class VendaCompraRepo : BaseRepo<VendaCompra>
    {
        /**
         * @brief Construtor da classe `VendaCompraRepo`.
         * 
         * Inicializa o repositório de vendas e compras com o caminho do ficheiro JSON onde os dados
         * serão armazenados. O ficheiro pré-definido utilizado é `Data/vendas.json`.
         */
        public VendaCompraRepo() : base("Data/vendas.json") { }
    }
}
