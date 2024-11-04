using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;

public class ProdutoController : BaseController<Produto, ChildForm>, IController<Produto>
{

    public ProdutoController(ChildForm view)
        : base(view, "Data/produtos.json")
    {
        Initialize();
    }

    protected override void ExibeItensNaView(List<Produto> produtos)
    {
        // Create a temporary list to hold translated products
        var produtosComNomes = new List<ProdutoViewModel>();

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

            produtosComNomes.Add(produtoViewModel);
        }

        // Pass the list of translated products to the view
        _view.MostraItens(produtosComNomes);
    }

    public void FiltrarItens(string filtro, string coluna)
    {
        FiltrarItens(filtro, produto =>
        {
            if (string.IsNullOrEmpty(coluna)) return false;

            var prop = produto.GetType().GetProperty(coluna);
            if (prop != null)
            {
                var value = prop.GetValue(produto)?.ToString() ?? string.Empty;
                return value.Contains(filtro, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        });
    }

    public Produto GetById(int id)
    {
        return _repository.GetById(id);
    }

    protected override void RemoveItem(Produto item)
    {
        _repository.Remove(item);
    }

    // Mapeia DisplayName a PropertyName (Traduz)
    public Dictionary<string, string> GetColumnPropertyMappings()
    {
        var mappings = new Dictionary<string, string>();

        foreach (var prop in typeof(ProdutoViewModel).GetProperties())
        {
            var displayNameAttr = (DisplayNameAttribute?)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));
            string displayName = displayNameAttr != null ? displayNameAttr.DisplayName : prop.Name;
            mappings[displayName] = prop.Name;
        }

        return mappings;
    }


}
