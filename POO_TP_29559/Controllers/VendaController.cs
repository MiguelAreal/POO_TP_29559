using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

public class VendaController : BaseController<Venda, ChildForm>, IEntityController
{
    private List<VendaViewModel> _vendasViewItems; // Hold the list of translated sales
    private readonly ClienteRepo _clienteRepo;

    public VendaController(ChildForm view)
        : base(view, "Data/vendas.json")
    {
        _clienteRepo = new ClienteRepo();
        Initialize();
    }

    protected override void ExibeItensNaView(List<Venda> vendas)
    {
        _vendasViewItems = new List<VendaViewModel>();

        foreach (var venda in vendas)
        {
            // Busca cliente por ID
            var cliente = _clienteRepo.GetById(venda.ClienteID);

            // Calcula meses restantes
            //int mesesRestantes = Math.Max(0, venda.GarantiaMeses - (int)((DateTime.Now - DateTime.Parse(venda.DataVenda)).TotalDays / 30));

            // VendaViewModel para exibição
            var vendaViewModel = new VendaViewModel
            {
                Id = venda.Id,
                ClienteNome = cliente?.Nome,
                NIF = cliente?.Nif,
                DataVenda = venda.DataVenda,
                PrecoTotal = venda.PrecoTotal,
                MetodoPagamento = venda.MetodoPagamento.ToString(),
                GarantiaMeses = 5,//venda.GarantiaMeses,
                GarantiaRestanteMeses = 5
            };

            _vendasViewItems.Add(vendaViewModel);
        }

        _view.MostraItens(_vendasViewItems);
    }

    protected override void RemoveItem(Venda item)
    {
        _repository.Remove(item);
    }

    protected override void UpdateItem(Venda item)
    {
        _repository.Remove(item);
    }
}
