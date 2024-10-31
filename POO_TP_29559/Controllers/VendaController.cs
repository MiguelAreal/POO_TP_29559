using poo_tp_29559.Repositories;

public class VendaController
{
    private readonly VendaRepo _vendaRepo;
    private readonly ClienteRepo _clienteRepo;

    public VendaController(VendaRepo vendaRepo, ClienteRepo clienteRepo)
    {
        _vendaRepo = vendaRepo;
        _clienteRepo = clienteRepo;
    }

    public void CreateVenda(int? clienteID)
    {
        // Busca cliente pelo ID, caso haja
        Cliente? cliente = _clienteRepo.GetById(clienteID);

        var novaVenda = new Venda(cliente);

    }

    
}
