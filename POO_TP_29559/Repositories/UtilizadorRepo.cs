using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    #region Class UtilizadorRepo
    /// <summary>
    /// Repositório especializado na manipulação de utilizadores.
    /// </summary>
    /// <remarks>
    /// A classe <c>UtilizadorRepo</c> é uma especialização da classe base <c>BaseRepo&lt;Utilizador&gt;</c>,
    /// responsável pela persistência e manipulação de utilizadores. A classe lida com operações específicas
    /// para objetos do tipo <c>Utilizador</c>, incluindo a busca por NIF, contacto e a obtenção
    /// de todos os utilizadores clientes.
    /// </remarks>
    /// <author>Miguel Areal</author>
    /// <date>12/2024</date>
    public class UtilizadorRepo : BaseRepo<Utilizador>
    {
        #region Constructor
        /// <summary>
        /// Construtor da classe <c>UtilizadorRepo</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório de utilizadores com o caminho do ficheiro JSON onde os dados
        /// serão armazenados. O ficheiro pré-definido utilizado é <c>Data/utilizadores.json</c>.
        /// </remarks>
        public UtilizadorRepo() : base("Data/utilizadores.json") { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Obtém um utilizador pelo NIF.
        /// </summary>
        /// <remarks>
        /// Este método permite buscar um utilizador através do seu NIF.
        /// </remarks>
        /// <param name="nif">O NIF do utilizador a procurar.</param>
        /// <returns>O utilizador se encontrado; caso contrário, null.</returns>
        public Utilizador? ObterPorNIF(int nif)
        {
            return GetByProperty(u => u.Nif, nif);
        }

        /// <summary>
        /// Obtém um utilizador pelo Contacto.
        /// </summary>
        /// <remarks>
        /// Este método permite buscar um utilizador através do seu Contacto.
        /// Caso o Contacto fornecido seja inválido, o método retorna `null`.
        /// </remarks>
        /// <param name="contacto">O Contacto do utilizador a procurar.</param>
        /// <returns>O utilizador se encontrado; caso contrário, null.</returns>
        public Utilizador? ObterPorContacto(string contacto)
        {
            if (string.IsNullOrWhiteSpace(contacto))
            {
                return null; // Retorna null se o contacto for inválido
            }

            return GetByProperty(u => u.Contacto, contacto); // Busca o utilizador com o contacto fornecido
        }

        /// <summary>
        /// Obtém todos os utilizadores clientes.
        /// </summary>
        /// <remarks>
        /// Este método retorna uma lista de todos os utilizadores que não são administradores.
        /// </remarks>
        /// <returns>Uma lista de utilizadores clientes encontrados.</returns>
        public List<Utilizador> GetAllClientes()
        {
            return items.Where(u => !u.IsAdmin).ToList();
        }
        #endregion
    }
    #endregion
}
