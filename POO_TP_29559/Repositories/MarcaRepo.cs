using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    #region Class MarcaRepo
    /// <summary>
    /// Repositório para a manipulação de marcas.
    /// </summary>
    /// <remarks>
    /// A classe <c>MarcaRepo</c> herda de <c>BaseRepo&lt;Marca&gt;</c> e é especializada na manipulação
    /// de objetos do tipo <c>Marca</c>. Ela oferece as funcionalidades básicas de um repositório, como a
    /// adição, remoção, atualização e obtenção de marcas a partir de um ficheiro JSON.
    /// </remarks>
    /// <seealso cref="BaseRepo{Marca}"/>
    public class MarcaRepo : BaseRepo<Marca>
    {
        #region Constructor
        /// <summary>
        /// Construtor da classe <c>MarcaRepo</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório de marcas com o caminho do ficheiro JSON onde os dados
        /// serão armazenados. O ficheiro pré-definido utilizado é <c>Data/marcas.json</c>.
        /// </remarks>
        public MarcaRepo() : base("Data/marcas.json") { }
        #endregion
    }
    #endregion
}
