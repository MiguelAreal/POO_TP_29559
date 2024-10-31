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

    public void FiltrarProdutos(string filtro)
    {
        FiltrarItens(filtro, produto => produto.Nome != null && produto.Nome.ToLower().Contains(filtro.ToLower()));
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


}


// ViewModel for Product with category and brand names
public class ProdutoViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    [DisplayName("Preço")]
    public decimal Preco { get; set; }
    [DisplayName("Stock")]
    public int QuantidadeEmStock { get; set; }
    [DisplayName("Categoria")]
    public string? CategoriaNome { get; set; }
    [DisplayName("Marca")]
    public string? MarcaNome { get; set; }
    [DisplayName("Data de Adição")]
    public string? DataAdicao { get; set; }
}
