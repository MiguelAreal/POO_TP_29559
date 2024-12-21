using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /// <summary>
    /// Repositório para a manipulação de categorias.
    /// </summary>
    /// <remarks>
    /// A classe <c>CategoriaRepo</c> herda de <c>BaseRepo&lt;Categoria&gt;</c> e é especializada na manipulação
    /// de objetos do tipo <c>Categoria</c>. Ela oferece as funcionalidades básicas de um repositório,
    /// como a adição, remoção, atualização e obtenção de categorias a partir de um ficheiro JSON.
    /// </remarks>
    /// <seealso cref="BaseRepo{Categoria}" />
    public class CategoriaRepo : BaseRepo<Categoria>
    {
        #region Constructor
        /// <summary>
        /// Construtor da classe <c>CategoriaRepo</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório de categorias com o caminho do ficheiro JSON onde os dados
        /// serão armazenados. O ficheiro pré-definido utilizado é <c>Data/categorias.json</c>.
        /// </remarks>
        public CategoriaRepo() : base("Data/categorias.json") { }
        #endregion
    }
}
