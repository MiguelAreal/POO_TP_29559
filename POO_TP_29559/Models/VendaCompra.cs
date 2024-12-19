using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Repositories.Enumerators;
using System.ComponentModel;

/**
 * @class VendaCompra
 * @brief Representa uma transação de venda ou compra realizada.
 * 
 * A classe `VendaCompra` armazena informações sobre a transação de compra ou venda de produtos, incluindo o cliente associado,
 * os itens vendidos, o valor total, as datas relevantes, o método de pagamento utilizado, entre outras informações.
 * Esta classe pode ser usada para representar tanto vendas de produtos quanto compras realizadas por um cliente.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

public class VendaCompra : IIdentifiable
{
    /**
     * @brief Identificador único da venda ou compra.
     * 
     * Este campo armazena o identificador único da transação. 
     */
    public int Id { get; set; }

    /**
     * @brief Identificador do cliente associado à venda ou compra.
     * 
     * Este campo armazena o identificador único do cliente que realizou a venda ou compra, se aplcável.
     */
    [DisplayName("Cliente")]
    public int? ClienteID { get; set; } // Cliente associado, se aplicável

    /**
     * @brief Número de Identificação Fiscal (NIF) associado à venda ou compra.
     * 
     * Este campo armazena o NIF do cliente que realizou a transação.
     */
    [DisplayName("NIF")]
    public int? NIF { get; set; } // NIF associado, se aplicável

    /**
     * @brief Lista de itens vendidos ou comprados na transação.
     * 
     * Este campo armazena uma lista de objetos `ItemVenda`, representando os produtos vendidos ou comprados na transação.
     */
    public List<ItemVenda>? Itens { get; set; } = new List<ItemVenda>();

    /**
     * @brief Total de unidades de produtos vendidos ou comprados.
     * 
     * Este campo calcula a soma de unidades de todos os itens vendidos ou comprados na transação.
     * Ele é calculado automaticamente com base na lista de itens.
     */
    public int ItensTotal => Itens?.Sum(item => item.Unidades) ?? 0;

    /**
     * @brief Total bruto da venda ou compra (sem descontos).
     * 
     * Este campo armazena o valor total da transação sem considerar qualquer desconto aplicado.
     */
    public decimal TotalBruto { get; set; }

    /**
     * @brief Total líquido da venda ou compra (com descontos).
     * 
     * Este campo armazena o valor total da transação após os descontos terem sido aplicados.
     */
    public decimal TotalLiquido { get; set; }

    /**
     * @brief Data em que a venda ou compra foi realizada.
     * 
     * Este campo armazena a data e hora em que a transação foi efetuada.
     */
    public string DataVenda { get; set; }

    /**
     * @brief Data de fim da garantia associada à transação.
     * 
     * Este campo armazena a data em que a garantia do produto vendido ou comprado termina. 
     * O valor é gerado automaticamente para ser 36 meses após a data da venda, se não for especificado.
     */
    public string? FimDataGarantia { get; set; }

    /**
     * @brief Método de pagamento utilizado na transação.
     * 
     * Este campo armazena o método de pagamento escolhido para a transação, com base no enumerador `MetodoPagamento`.
     */
    public MetodoPagamento? MetodoPagamento { get; set; }

    /**
     * @brief Construtor da classe `VendaCompra`.
     * 
     * Este construtor inicializa a data da venda com a data e hora atuais e define a data de fim da garantia como 36 meses após a data de venda.
     */
    public VendaCompra()
    {
        DataVenda = DateTime.Now.ToString();
        FimDataGarantia = DateTime.Now.AddMonths(36).ToString();
    }
}
