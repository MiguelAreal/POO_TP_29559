using poo_tp_29559.Repositories;
using poo_tp_29559.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutosForm _view;
        private readonly ProdutoRepo _repository;

        public ProdutoController(ProdutosForm view)
        {
            _view = view;
            _repository = new ProdutoRepo();
            CarregaProdutos();
        }

        // Carrega produtos e exibe na view
        private void CarregaProdutos()
        {
            var produtos = _repository.GetProdutos();
            _view.MostraProdutos(produtos);
        }

        // Adiciona novo produto
        public void AddProduto(Produto produto)
        {
            _repository.AddProduto(produto);
            CarregaProdutos(); // Atualiza a view com a lista de produtos
        }
    }

}
