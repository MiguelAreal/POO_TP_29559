using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.Collections.Generic;

namespace poo_tp_29559.Controllers
{
    public class ProdutoController : BaseController<Produto, ProdutosForm, ProdutoRepo>
    {
        public ProdutoController(ProdutosForm view) : base(view)
        {
        }

        // Método implementado para mostrar os produtos na view
        protected override void ExibeItensNaView(List<Produto> produtos)
        {
            _view.MostraProdutos(produtos);
        }

        // Método específico para filtrar produtos pelo nome
        public void FiltrarProdutos(string filtro)
        {
            
            // Usa o método da classe BaseController, passando a função de filtro para procurar pelo nome
            FiltrarItens(filtro, produto => produto.Nome != null && produto.Nome.ToLower().Contains(filtro.ToLower()));
        }

    }
}
