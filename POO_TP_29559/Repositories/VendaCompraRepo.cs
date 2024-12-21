using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    #region Class VendaCompraRepo
    /// <summary>
    /// Repositório especializado na manipulação de vendas e compras.
    /// </summary>
    /// <remarks>
    /// A classe <c>VendaCompraRepo</c> é uma especialização da classe base <c>BaseRepo&lt;VendaCompra&gt;</c>,
    /// responsável pela persistência e manipulação de objetos <c>VendaCompra</c>. A classe lida com operações
    /// específicas para vendas e compras, armazenando os dados em um ficheiro JSON.
    /// </remarks>
    /// <author>Miguel Areal</author>
    /// <date>12/2024</date>
    public class VendaCompraRepo : BaseRepo<VendaCompra>
    {
        #region Constructor
        /// <summary>
        /// Construtor da classe <c>VendaCompraRepo</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório de vendas e compras com o caminho do ficheiro JSON onde os dados
        /// serão armazenados. O ficheiro pré-definido utilizado é <c>Data/vendas.json</c>.
        /// </remarks>
        public VendaCompraRepo() : base("Data/vendas.json") { }
        #endregion
    }
    #endregion
}
