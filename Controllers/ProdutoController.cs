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
        
        // Armazena a lista completa de produtos
        private List<Produto> _produtos;

        public ProdutoController(ProdutosForm view)
        {
            _view = view;
            _repository = new ProdutoRepo();
            CarregaProdutos();
        }

        // Carrega produtos e exibe na view
        private void CarregaProdutos()
        {
            _produtos = _repository.GetProdutos();
            _view.MostraProdutos(_produtos);
        }

        // Filtra produtos com base no nome e atualiza a view
        public void FiltrarProdutos(string filtro)
        {
            var produtosFiltrados = _produtos
                .Where(p => !string.IsNullOrEmpty(p.Nome) && p.Nome.ToLower().Contains(filtro.ToLower()))
                .ToList();

            _view.MostraProdutos(produtosFiltrados);
        }

        // Adiciona novo produto, e atualiza a view
        public void AddProduto(Produto produto)
        {
            _repository.AddProduto(produto);
            CarregaProdutos();
        }

        // Remove produto, e atualiza a view
        public void RemProduto(Produto produto)
        {
            _repository.RemProduto(produto);
            CarregaProdutos();
        }

        // Altera o produto, e atualiza a view
        public void UpdProduto(Produto produto)
        {
            _repository.UpdProduto(produto);
            CarregaProdutos();
        }
    }

}
