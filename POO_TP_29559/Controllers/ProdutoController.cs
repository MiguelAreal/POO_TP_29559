using poo_tp_29559;
using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/**
 * @class ProdutoController
 * @brief Controlador para a gestão de produtos.
 * 
 * A classe `ProdutoController` é responsável pela gestão dos produtos, incluindo operações de leitura e tradução dos dados (substituindo IDs por nomes de categorias e marcas). Herda de `BaseController<Produto>` e implementa a interface `IEntityController`, oferecendo funcionalidades específicas para o trabalho com produtos.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class ProdutoController : BaseController<Produto>, IEntityController
{
    private List<ProdutoViewModel> _produtosComNomes; /**< Lista de produtos com nomes traduzidos */

    /**
     * @brief Construtor da classe `ProdutoController`.
     * 
     * Inicializa o controlador com o caminho do ficheiro de dados onde os produtos são armazenados.
     */
    public ProdutoController() : base("Data/produtos.json") { }

    /**
     * @brief Obtém todos os produtos com os IDs traduzidos para nomes.
     * 
     * Este método retorna uma lista de produtos em que os IDs de categoria e marca foram substituídos pelos seus respetivos nomes, criando um modelo de visualização com informações mais legíveis para a apresentação.
     * 
     * @return Uma lista de produtos com nomes traduzidos.
     */
    public override List<object> GetItems()
    {
        List<Produto> produtos = _repository.GetAll();

        // Traduzir IDs para nomes e criar uma lista de Produto com a tradução
        foreach (var produto in produtos)
        {
            // Traduz IDs para nomes, mas mantém a estrutura de Produto
            Categoria? categoria = new CategoriaRepo().GetById(produto.CategoriaID);
            Marca? marca = new MarcaRepo().GetById(produto.MarcaID);

            produto.CategoriaID = categoria?.Id ?? produto.CategoriaID;
            produto.MarcaID = marca?.Id ?? produto.MarcaID;
        }

        // Devolve lista de produtos
        return produtos.Cast<object>().ToList();
    }


    /**
     * @brief Obtém todos os produtos diretamente do modelo, sem tradução para nomes.
     * 
     * Este método retorna uma lista de produtos diretamente do repositório, sem qualquer tradução ou modificação dos dados.
     * 
     * @return Uma lista de produtos ordenados por nome.
     */
    public List<Produto> GetRawProdutos()
    {
        var produtos = _repository.GetAll();
        return produtos.OrderBy(c => c.Nome).ToList();
    }
}
