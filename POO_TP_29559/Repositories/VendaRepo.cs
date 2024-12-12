using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class VendaRepo : BaseRepo<Venda>
    {
        private readonly UtilizadorRepo _clienteRepo;

        public VendaRepo(UtilizadorRepo clienteRepo) : base("Data/vendas.json")
        {
            _clienteRepo = clienteRepo;
        }

    }
}
