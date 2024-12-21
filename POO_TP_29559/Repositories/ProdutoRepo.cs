using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    #region Class ProdutoRepo
    /// <summary>
    /// Repositório especializado na manipulação de produtos.
    /// </summary>
    /// <remarks>
    /// A classe <c>ProdutoRepo</c> é uma especialização da classe base <c>BaseRepo&lt;Produto&gt;</c>,
    /// responsável pela persistência e manipulação de produtos. A classe lida com operações específicas
    /// para objetos do tipo <c>Produto</c>.
    /// </remarks>
    /// <author>Miguel Areal</author>
    /// <date>12/2024</date>
    public class ProdutoRepo : BaseRepo<Produto>
    {
        #region Constructor
        /// <summary>
        /// Construtor da classe <c>ProdutoRepo</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório de produtos com o caminho do ficheiro JSON onde os dados
        /// serão armazenados. O ficheiro pré-definido utilizado é <c>Data/produtos.json</c>.
        /// </remarks>
        public ProdutoRepo() : base("Data/produtos.json") { }
        #endregion
    }
    #endregion
}
