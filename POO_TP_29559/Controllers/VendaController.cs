using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

public class VendaController : BaseController<Venda>, IEntityController
{
    private List<VendaViewModel> _vendasViewItems; 

    public VendaController() : base("Data/vendas.json") { }


    public override object GetItems()
    {
        List<Venda> vendas =  _repository.GetAll();

        _vendasViewItems = new List<VendaViewModel>();

        foreach (var venda in vendas)
        {
            // Busca cliente por ID
            Utilizador? cliente = new UtilizadorRepo().GetById(venda.ClienteID);


            // VendaViewModel para exibição
            var vendaViewModel = new VendaViewModel
            {
                Id = venda.Id,
                ClienteNome = cliente?.Nome,
                NIF = venda.NIF,
                DataVenda = venda.DataVenda,
                TotalLiquido = venda.TotalLiquido,
                MetodoPagamento = venda.MetodoPagamento.ToString(),
                GarantiaRestanteMeses = 1
            };

            _vendasViewItems.Add(vendaViewModel);
        }

        return _vendasViewItems;

    }

    protected override void RemoveItem(Venda item)
    {
        _repository.Remove(item);
    }

    protected override void UpdateItem(Venda item)
    {
        _repository.Update(item);
    }
}
