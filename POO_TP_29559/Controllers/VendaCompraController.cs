using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

public class VendaCompraController : BaseController<VendaCompra>, IEntityController
{
    private List<VendaCompraViewModel> _vendasComprasViewItems; 

    public VendaCompraController() : base("Data/vendas.json") { }


    public override object GetItems()
    {
        List<VendaCompra> vendas =  _repository.GetAll();

        _vendasComprasViewItems = new List<VendaCompraViewModel>();

        foreach (var venda in vendas)
        {
            // Busca cliente por ID
            Utilizador? cliente = (Utilizador?)new UtilizadorController().GetById(venda.ClienteID);

            // VendaViewModel para exibição
            var vendaCompraViewModel = new VendaCompraViewModel
            {
                Id = venda.Id,
                ClienteNome = cliente?.Nome,
                NIF = venda.NIF,
                DataVenda = venda.DataVenda,
                TotalLiquido = venda.TotalLiquido,
                MetodoPagamento = venda.MetodoPagamento.ToString()
            };

            _vendasComprasViewItems.Add(vendaCompraViewModel);
        }

        return _vendasComprasViewItems;

    }

    public override void RemoveItem(VendaCompra item)
    {
        ProdutoController produtoController;
        produtoController = new ProdutoController();
        // Verifica se a venda está dentro do período de garantia
        if (DateTime.TryParse(item.FimDataGarantia, out DateTime dataFimGarantia))
        {
            if (DateTime.Now <= dataFimGarantia)
            {
                // Itera pelos itens da venda
                foreach (ItemVenda itemVenda in item.Itens)
                {
                    // Busca o produto correspondente no repositório
                    Produto produto = (Produto)produtoController.GetById(itemVenda.ProdutoID);

                    if (produto != null)
                    {
                        // Atualiza o stock do produto, devolvendo as unidades compradas
                        produto.QuantidadeEmStock += itemVenda.Unidades;

                        // Salva as alterações no repositório de produtos
                        produtoController.UpdateItem(produto);
                    }
                }
            }
        }
        else
        {
            throw new InvalidOperationException("A data de fim da garantia é inválida.");
        }

        // Remove a venda após atualizar o stock
        _repository.Remove(item);
    }



}
