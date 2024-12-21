using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class ProdutoController : BaseController<Produto>, IEntityController
{
    #region Fields

    /// <summary>
    /// Lista de produtos com nomes traduzidos para exibição mais legível.
    /// </summary>
    private List<ProdutoViewModel> _produtosComNomes;

    #endregion

    #region Constructor

    /// <summary>
    /// Construtor da classe <see cref="ProdutoController"/>.
    /// Inicializa o controlador com o caminho do ficheiro de dados onde os produtos são armazenados.
    /// </summary>
    public ProdutoController() : base("Data/produtos.json") { }

    #endregion

    #region Get Items

    /// <summary>
    /// Obtém todos os produtos com os IDs de categoria e marca traduzidos para os respetivos nomes.
    /// Este método retorna uma lista de modelos de visualização com informações mais legíveis para apresentação.
    /// </summary>
    /// <returns>Uma lista de produtos com nomes traduzidos.</returns>
    public override List<object> GetItems()
    {
        List<Produto> produtos = _repository.GetAll();
        _produtosComNomes = new List<ProdutoViewModel>();

        foreach (var produto in produtos)
        {
            // Traduz IDs para nomes
            Categoria? categoria = new CategoriaRepo().GetById(produto.CategoriaID);
            Marca? marca = new MarcaRepo().GetById(produto.MarcaID);

            // Cria um modelo de visualização para o produto
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

        // Retorna a lista de produtos traduzidos
        return _produtosComNomes.Cast<object>().ToList();
    }

    #endregion

    #region Get Normal Products

    /// <summary>
    /// Obtém todos os produtos diretamente do modelo sem tradução para nomes.
    /// Este método retorna uma lista de produtos diretamente do repositório, sem modificação dos dados.
    /// </summary>
    /// <returns>Uma lista de produtos ordenados por nome.</returns>
    public List<Produto> GetRawProdutos()
    {
        var produtos = _repository.GetAll();
        return produtos.OrderBy(c => c.Nome).ToList();
    }

    #endregion
}
