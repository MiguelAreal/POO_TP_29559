using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

public class ProdutoController : BaseController<Produto>, IEntityController
{
    private List<ProdutoViewModel> _produtosComNomes; // Hold the list of translated products

    public ProdutoController() : base("Data/produtos.json") { }


    public override object GetItems()
    {
        List<Produto> produtos = _repository.GetAll();
        // Criar lista temporária que contém produtos traduzidos

        _produtosComNomes = new List<ProdutoViewModel>();

        foreach (var produto in produtos)
        {
            //Traduz IDs para nomes
            Categoria? categoria = new CategoriaRepo().GetById(produto.CategoriaID);
            Marca? marca = new MarcaRepo().GetById(produto.MarcaID);

            // Criar view model para o produto com nomes em vez de IDs (marca, categoria)
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

        // Devolve lista de produtos traduzidos
        return _produtosComNomes;
    }

    protected override void RemoveItem(Produto item)
    {
        _repository.Remove(item);
    }

    protected override void UpdateItem(Produto item)
    {
        throw new NotImplementedException();
    }

    public List<Produto>? GetRawProdutos()
    {
        var produtos = _repository.GetAll();
        return produtos.OrderBy(c => c.Nome).ToList();
            
    }

    public Produto GetById(int? id)
    {
        return _repository.GetById(id);
    }
}
