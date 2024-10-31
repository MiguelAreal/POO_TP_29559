using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class ClienteRepo : BaseRepo<Cliente>
    {
        public ClienteRepo() : base("Data/clientes.json") { }


    }
}