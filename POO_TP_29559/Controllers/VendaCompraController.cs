using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

/**
 * @class VendaCompraController
 * @brief Controlador para a gestão de vendas e compras.
 * 
 * A classe `VendaCompraController` é responsável pela gestão das vendas e compras. Ela lida com a exibição das informações de vendas, cálculo de garantias e a remoção de itens de vendas, além de atualizar o stock dos produtos vendidos.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class VendaCompraController : BaseController<VendaCompra>, IEntityController
{
    private List<VendaCompraViewModel> _vendasComprasViewItems; /**< Lista de itens de vendas e compras para exibição */

    /**
     * @brief Construtor da classe `VendaCompraController`.
     * 
     * Inicializa o controlador com o caminho do ficheiro de dados onde as vendas são armazenadas.
     */
    public VendaCompraController() : base("Data/vendas.json") { }

    /**
     * @brief Obtém os itens de vendas e compras para exibição.
     * 
     * Este método recupera todas as vendas do repositório, traduz os dados das vendas para um formato de exibição e retorna a lista de itens formatados.
     * 
     * @return Uma lista de `VendaCompraViewModel`, que contém as informações das vendas para exibição.
     */
    public override List<object> GetItems()
    {
        List<VendaCompra> vendas = _repository.GetAll();

        _vendasComprasViewItems = new List<VendaCompraViewModel>();

        foreach (var venda in vendas)
        {
            // Busca cliente por ID
            Utilizador? cliente = (Utilizador?)new UtilizadorController().GetById(venda.ClienteID);

            // Criação de um ViewModel para exibição
            var vendaCompraViewModel = new VendaCompraViewModel
            {
                Id = venda.Id,
                ClienteNome = cliente?.Nome,
                NIF = venda.NIF,
                DataVenda = venda.DataVenda,
                TotalLiquido = venda.TotalLiquido,
                MetodoPagamento = venda.MetodoPagamento.ToString()
            };

            _vendasComprasViewItems.Add(vendaCompraViewModel);
        }

        return _vendasComprasViewItems.Cast<object>().ToList();
    }

    /**
     * @brief Remove uma venda do sistema.
     * 
     * Este método remove uma venda do sistema após atualizar o stock dos produtos vendidos, considerando a validade da garantia do produto.
     * 
     * @param item O item de venda a ser removido.
     * @throws InvalidOperationException Se a data de fim de garantia for inválida.
     */
    public override void RemoveItem(object item)
    {
        ProdutoController produtoController;
        produtoController = new ProdutoController();

        if (item is VendaCompra specificItem)
        {
            // Verifica se a venda está dentro do período de garantia
            if (DateTime.TryParse(specificItem.FimDataGarantia, out DateTime dataFimGarantia))
            {
                if (DateTime.Now <= dataFimGarantia)
                {
                    // Itera pelos itens da venda
                    foreach (ItemVenda itemVenda in specificItem.Itens)
                    {
                        // Busca o produto correspondente no repositório
                        Produto produto = (Produto)produtoController.GetById(itemVenda.ProdutoID);

                        if (produto != null)
                        {
                            // Atualiza o stock do produto, devolvendo as unidades compradas
                            produto.QuantidadeEmStock += itemVenda.Unidades;

                            // Guarda as alterações no repositório de produtos
                            produtoController.UpdateItem(produto);
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("A data de fim da garantia é inválida.");
            }

            // Remove a venda após atualizar o stock
            _repository.Remove(specificItem);
        }


    }

    /**
     * @brief Calcula a garantia da compra.
     * 
     * Este método calcula a garantia de uma compra com base no NIF do cliente. Se o NIF começar com 1, 2 ou 3, é um cliente particular; caso contrário, é uma empresa. O cálculo de garantia varia dependendo do tipo de cliente.
     * 
     * @param cliente O objeto `Utilizador` que representa o cliente a efetuar a compra.
     * @return O número de meses de garantia (36 meses para clientes particulares, 12 meses para empresas).
     */
    public int CalculaGarantia(Utilizador cliente)
    {
        string nifString = cliente.Nif.ToString();

        if (nifString.Length == 9)
        {
            // Se o NIF começar com '1', '2' ou '3', é cliente particular
            // Caso contrário, é empresa
            if (nifString.StartsWith("1") || nifString.StartsWith("2") || nifString.StartsWith("3"))
            {
                return 36; // Garantia de 36 meses para cliente particular
            }
            else
            {
                return 12; // Garantia de 12 meses para empresas
            }
        }
        else
        {
            return 36; // Valor predefinido de garantia caso o NIF não tenha 9 caracteres
        }
    }
}
