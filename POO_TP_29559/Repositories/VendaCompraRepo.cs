using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class VendaCompraRepo : BaseRepo<VendaCompra>
    {
        private readonly UtilizadorRepo _clienteRepo;

        public VendaCompraRepo(UtilizadorRepo clienteRepo) : base("Data/vendas.json")
        {
            _clienteRepo = clienteRepo;
        }

    }
}
