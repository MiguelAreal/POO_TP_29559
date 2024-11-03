using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System.Collections.Generic;
using System.Linq;

public class VendaController
{
    private readonly VendaRepo _vendaRepo;
    private readonly ClienteRepo _clienteRepo;

    public VendaController(VendaRepo vendaRepo, ClienteRepo clienteRepo)
    {
        _vendaRepo = vendaRepo;
        _clienteRepo = clienteRepo;
    }

    public List<VendaViewModel> GetVendasWithClientNames()
    {
        var vendas = _vendaRepo.GetAll();
        var vendaViewModels = vendas.Select(v => new VendaViewModel
        {
            Id = v.Id,
            NomeCliente = _clienteRepo.GetById(v.ClienteID)?.Nome,
            DataVenda = v.DataVenda,
            PrecoTotal = v.PrecoTotal,
            MetodoPagamento = v.MetodoPagamento.ToString()
        }).ToList();

        return vendaViewModels;
    }

    public Venda GetVendaDetails(int vendaId)
    {
        return _vendaRepo.GetById(vendaId);
    }
}

public class VendaViewModel
{
    public int Id { get; set; }
    public string? NomeCliente { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal PrecoTotal { get; set; }
    public string? MetodoPagamento { get; set; }
}
