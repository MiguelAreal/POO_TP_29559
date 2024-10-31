using poo_tp_29559.Models;

namespace poo_tp_29559.Repositories
{
    public class VendaRepo : BaseRepo<Venda>
    {
        private readonly ClienteRepo _clienteRepo;

        public VendaRepo(ClienteRepo clienteRepo) : base("Data/vendas.json")
        {
            _clienteRepo = clienteRepo;
        }

        public Cliente? GetClienteByVenda(Venda venda)
        {
            return _clienteRepo.GetById(venda.ClienteID);
        }
    }
}
