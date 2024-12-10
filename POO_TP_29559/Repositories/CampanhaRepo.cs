using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class CampanhaRepo : BaseRepo<Campanha>
    {
        public CampanhaRepo() : base("Data/campanhas.json") { }

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