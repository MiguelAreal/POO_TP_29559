/**
 * @file CampanhaRepo.cs
 * @brief Repositório especializado na manipulação de campanhas.
 * 
 * A classe `CampanhaRepo` é uma especialização da classe base `BaseRepo<Campanha>`,
 * responsável pela persistência e manipulação de campanhas. A classe oferece métodos
 * específicos para validar a data de validade das campanhas.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    /**
     * @class CampanhaRepo
     * @brief Repositório para a manipulação de campanhas.
     * 
     * A classe `CampanhaRepo` herda de `BaseRepo<Campanha>` e é especializada na manipulação
     * de objetos do tipo `Campanha`. Oferece métodos para verificar a validade de uma campanha
     * com base nas suas datas de início e fim.
     * 
     * @see BaseRepo
     */
    public class CampanhaRepo : BaseRepo<Campanha>
    {
        /**
         * @brief Construtor da classe `CampanhaRepo`.
         * 
         * Inicializa o repositório de campanhas com o caminho do ficheiro JSON onde os dados
         * serão armazenados. O ficheiro pré-definido utilizado é `Data/campanhas.json`.
         */
        public CampanhaRepo() : base("Data/campanhas.json") { }

        /**
         * @brief Verifica se a campanha está dentro do período de validade.
         * 
         * Este método verifica se a campanha fornecida está dentro do intervalo de datas válido
         * (entre a data de início e a data de fim). A validade é determinada com base na data
         * atual do sistema.
         * 
         * @param campanha A campanha a ser verificada.
         * @return `true` se a campanha estiver dentro do período de validade; `false` caso contrário.
         */
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
    }
}
