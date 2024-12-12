using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class UtilizadorRepo : BaseRepo<Utilizador>
    {
        public UtilizadorRepo() : base("Data/utilizadores.json") { }


    }
}