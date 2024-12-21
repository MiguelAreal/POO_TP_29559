using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Controlador para a gestão de vendas e compras.
/// Gerencia operações como exibição de vendas, cálculo de garantias, remoção de vendas e atualização de estoque dos produtos.
/// </summary>
public class VendaCompraController : BaseController<VendaCompra>, IEntityController
{
    /// <summary>
    /// Lista de itens de vendas e compras formatados para exibição.
    /// </summary>
    private List<VendaCompraViewModel> _vendasComprasViewItems;

    /// <summary>
    /// Construtor da classe <see cref="VendaCompraController"/>.
    /// Inicializa o controlador com o caminho do ficheiro de dados onde as vendas são armazenadas.
    /// </summary>
    public VendaCompraController() : base("Data/vendas.json") { }

    /// <summary>
    /// Obtém os itens de vendas e compras formatados para exibição.
    /// </summary>
    /// <returns>Uma lista de objetos representando as vendas e compras formatadas para exibição.</returns>
    public override List<object> GetItems()
    {
        List<VendaCompra> vendas = _repository.GetAll();
        _vendasComprasViewItems = new List<VendaCompraViewModel>();

        foreach (var venda in vendas)
        {
            // Busca o cliente pelo ID
            Utilizador? cliente = (Utilizador?)new UtilizadorController().GetById(venda.ClienteID);

            // Criação de um ViewModel formatado para exibição
            var vendaCompraViewModel = new VendaCompraViewModel
            {
                Id = venda.Id,
                ClienteNome = cliente?.Nome,
                ClienteID = cliente?.Id,
                NIF = venda.NIF,
                DataVenda = venda.DataVenda,
                TotalLiquido = venda.TotalLiquido,
                MetodoPagamento = venda.MetodoPagamento.ToString()
            };

            _vendasComprasViewItems.Add(vendaCompraViewModel);
        }

        return _vendasComprasViewItems.Cast<object>().ToList();
    }

    /// <summary>
    /// Remove uma venda do sistema após verificar a garantia e atualizar o estoque.
    /// </summary>
    /// <param name="item">O item de venda a ser removido.</param>
    /// <exception cref="InvalidOperationException">Se a data de fim da garantia for inválida.</exception>
    public override void RemoveItem(object item)
    {
        if (item is VendaCompra specificItem)
        {
            ProdutoController produtoController = new ProdutoController();

            // Verifica a validade da garantia
            if (DateTime.TryParse(specificItem.FimDataGarantia, out DateTime dataFimGarantia))
            {
                if (DateTime.Now <= dataFimGarantia)
                {
                    foreach (ItemVenda itemVenda in specificItem.Itens)
                    {
                        Produto produto = (Produto)produtoController.GetById(itemVenda.ProdutoID);

                        if (produto != null)
                        {
                            // Reverte o estoque com base nas unidades vendidas
                            produto.QuantidadeEmStock += itemVenda.Unidades;
                            produtoController.UpdateItem(produto);
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("A data de fim da garantia é inválida.");
            }

            // Remove a venda do repositório
            _repository.Remove(specificItem);
        }
    }

    /// <summary>
    /// Calcula o período de garantia da compra com base no tipo de cliente.
    /// </summary>
    /// <param name="cliente">O objeto <see cref="Utilizador"/> representando o cliente.</param>
    /// <returns>O período de garantia em meses (36 para particulares, 12 para empresas).</returns>
    public int CalculaGarantia(Utilizador cliente)
    {
        string nifString = cliente.Nif.ToString();

        if (nifString.Length == 9)
        {
            // Clientes particulares têm NIF começando com '1', '2' ou '3'
            if (nifString.StartsWith("1") || nifString.StartsWith("2") || nifString.StartsWith("3"))
            {
                return 36; // Garantia de 36 meses
            }
            else
            {
                return 12; // Garantia de 12 meses para empresas
            }
        }

        // Garantia padrão em caso de NIF inválido
        return 36;
    }
}
