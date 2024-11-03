using poo_tp_29559;
using poo_tp_29559.Controllers;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using System.Collections.Generic;
using System.ComponentModel;

public class ProdutoController : BaseController<Produto, ProdutosForm>
{
    private readonly CategoriaRepo _categoriaRepo; // Repository for categories
    private readonly MarcaRepo _marcaRepo; // Repository for brands

    public ProdutoController(ProdutosForm view, CategoriaRepo categoriaRepo, MarcaRepo marcaRepo)
        : base(view, "Data/produtos.json")
    {

        _categoriaRepo = categoriaRepo;
        _marcaRepo = marcaRepo;
        Initialize();
    }

    protected override void ExibeItensNaView(List<Produto> produtos)
    {
        // Create a temporary list to hold translated products
        var produtosComNomes = new List<ProdutoViewModel>();

        foreach (var produto in produtos)
        {
            // Translate IDs to names
            Categoria? categoria = _categoriaRepo.GetById(produto.CategoriaID);
            Marca? marca = _marcaRepo.GetById(produto.MarcaID);

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
        _view.MostraProdutos(produtosComNomes);
    }

    public void FiltrarProdutos(string filtro, string coluna)
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



    public void RemoveProduto(Produto item)
    {
        RemoveItem(item);
    }

    protected override void RemoveItem(Produto item)
    {
       /* if (item == null)
            throw new ArgumentNullException(nameof(item), "Produto não pode ser nulo.");*/

        _repository.Remove(item);
        CarregaItens();
    }

    public Dictionary<string, string> GetColumnPropertyMappings()
    {
        var mappings = new Dictionary<string, string>();

        foreach (var prop in typeof(ProdutoViewModel).GetProperties())
        {
            var displayNameAttr = (DisplayNameAttribute?)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));
            string displayName = displayNameAttr != null ? displayNameAttr.DisplayName : prop.Name;
            mappings[displayName] = prop.Name; // Map DisplayName to PropertyName
        }

        return mappings;
    }


}
