using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class ProdutoController : BaseController<Produto, ChildForm>, IEntityController
{
    private List<ProdutoViewModel> _produtosComNomes; // Hold the list of translated products

    public ProdutoController(ChildForm view)
        : base(view, "Data/produtos.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Produto> produtos)
    {
        // Create a temporary list to hold translated products
        _produtosComNomes = new List<ProdutoViewModel>();

        foreach (var produto in produtos)
        {
            // Translate IDs to names
            Categoria? categoria = new CategoriaRepo().GetById(produto.CategoriaID);
            Marca? marca = new MarcaRepo().GetById(produto.MarcaID);

            // Create a view model for the product with names instead of IDs
            var produtoViewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                QuantidadeEmStock = produto.QuantidadeEmStock,
                CategoriaNome = categoria?.Nome,
                MarcaNome = marca?.Nome,
                DataAdicao = produto.DataAdicao
            };

            _produtosComNomes.Add(produtoViewModel);
        }

        // Pass the list of translated products to the view
        _view.MostraItens(_produtosComNomes);
    }

    protected override void RemoveItem(Produto item)
    {
        _repository.Remove(item);
    }

    protected override void UpdateItem(Produto item)
    {
        throw new NotImplementedException();
    }
}
