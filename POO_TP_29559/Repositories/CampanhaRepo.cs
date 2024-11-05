using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class CampanhaRepo : BaseRepo<Campanha>
    {
        public CampanhaRepo() : base("Data/campanhas.json") { }

       

    }
}