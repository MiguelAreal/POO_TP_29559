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

    public new void FiltrarItens(string filtro, string coluna)
    {
        if (string.IsNullOrEmpty(coluna) || _produtosComNomes == null)
        {
            // Call base if no column is provided or no items to filter
            return;
        }

        // Filter the _produtosComNomes based on the provided filter
        var itensFiltrados = _produtosComNomes.Where(vm =>
        {
            var prop = vm.GetType().GetProperty(coluna);
            if (prop != null)
            {
                var value = prop.GetValue(vm)?.ToString() ?? string.Empty;
                return value.Contains(filtro, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }).ToList();

        // Display the filtered list in the view
        _view.MostraItens(itensFiltrados);
    }
}
