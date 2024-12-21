using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /// <summary>
    /// Repositório para a manipulação de campanhas.
    /// </summary>
    /// <remarks>
    /// A classe <c>CampanhaRepo</c> herda de <c>BaseRepo&lt;Campanha&gt;</c> e é especializada na manipulação
    /// de objetos do tipo <c>Campanha</c>. Oferece métodos para verificar a validade de uma campanha
    /// com base nas suas datas de início e fim.
    /// </remarks>
    /// <seealso cref="BaseRepo{Campanha}" />
    public class CampanhaRepo : BaseRepo<Campanha>
    {
        #region Constructor
        /// <summary>
        /// Construtor da classe <c>CampanhaRepo</c>.
        /// </summary>
        /// <remarks>
        /// Inicializa o repositório de campanhas com o caminho do ficheiro JSON onde os dados
        /// serão armazenados. O ficheiro pré-definido utilizado é <c>Data/campanhas.json</c>.
        /// </remarks>
        public CampanhaRepo() : base("Data/campanhas.json") { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Verifica se a campanha está dentro do período de validade.
        /// </summary>
        /// <remarks>
        /// Este método verifica se a campanha fornecida está dentro do intervalo de datas válido
        /// (entre a data de início e a data de fim). A validade é determinada com base na data
        /// atual do sistema.
        /// </remarks>
        /// <param name="campanha">A campanha a ser verificada.</param>
        /// <returns>
        /// <c>true</c> se a campanha estiver dentro do período de validade; <c>false</c> caso contrário.
        /// </returns>
        public bool IsCampanhaValida(Campanha campanha)
        {
            DateTime dataAtual = DateTime.Now;

            // Converte as datas para DateTime
            if (DateTime.TryParse(campanha.DataInicio, out DateTime dataInicio) &&
                DateTime.TryParse(campanha.DataFim, out DateTime dataFim))
            {
                // Verifica se a campanha está no período de validade
                return dataAtual >= dataInicio && dataAtual <= dataFim;
            }

            return false; // Caso as datas não sejam válidas
        }
        #endregion
    }
}
