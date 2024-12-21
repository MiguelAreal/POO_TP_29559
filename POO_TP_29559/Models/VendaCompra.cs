using poo_tp_29559.Models;
using poo_tp_29559.Repositories;
using poo_tp_29559.Repositories.Enumerators;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa uma transação de venda ou compra realizada.
    /// </summary>
    /// <remarks>
    /// A classe <c>VendaCompra</c> armazena informações sobre a transação de compra ou venda de produtos,
    /// incluindo o cliente associado, os itens vendidos, o valor total, as datas relevantes, o método de pagamento
    /// utilizado, entre outras informações. Esta classe pode ser usada para representar tanto vendas de produtos quanto 
    /// compras realizadas por um cliente.
    /// </remarks>
    public class VendaCompra : IIdentifiable
    {
        /// <summary>
        /// Identificador único da venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único da transação.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Identificador do cliente associado à venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único do cliente que realizou a venda ou compra, se aplicável.
        /// </remarks>
        [DisplayName("Cliente")]
        public int? ClienteID { get; set; } // Cliente associado, se aplicável

        /// <summary>
        /// Número de Identificação Fiscal (NIF) associado à venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o NIF do cliente que realizou a transação.
        /// </remarks>
        [DisplayName("NIF")]
        public int? NIF { get; set; } // NIF associado, se aplicável

        /// <summary>
        /// Lista de itens vendidos ou comprados na transação.
        /// </summary>
        /// <remarks>
        /// Este campo armazena uma lista de objetos <c>ItemVenda</c>, representando os produtos vendidos ou comprados na transação.
        /// </remarks>
        public List<ItemVenda>? Itens { get; set; } = new List<ItemVenda>();

        /// <summary>
        /// Total de unidades de produtos vendidos ou comprados.
        /// </summary>
        /// <remarks>
        /// Este campo calcula a soma de unidades de todos os itens vendidos ou comprados na transação.
        /// Ele é calculado automaticamente com base na lista de itens.
        /// </remarks>
        public int ItensTotal => Itens?.Sum(item => item.Unidades) ?? 0;

        /// <summary>
        /// Total bruto da venda ou compra (sem descontos).
        /// </summary>
        /// <remarks>
        /// Este campo armazena o valor total da transação sem considerar qualquer desconto aplicado.
        /// </remarks>
        public decimal TotalBruto { get; set; }

        /// <summary>
        /// Total líquido da venda ou compra (com descontos).
        /// </summary>
        /// <remarks>
        /// Este campo armazena o valor total da transação após os descontos terem sido aplicados.
        /// </remarks>
        public decimal TotalLiquido { get; set; }

        /// <summary>
        /// Data em que a venda ou compra foi realizada.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data e hora em que a transação foi efetuada.
        /// </remarks>
        public string DataVenda { get; set; }

        /// <summary>
        /// Data de fim da garantia associada à transação.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data em que a garantia do produto vendido ou comprado termina.
        /// O valor é gerado automaticamente para ser 36 meses após a data da venda, se não for especificado.
        /// </remarks>
        public string? FimDataGarantia { get; set; }

        /// <summary>
        /// Método de pagamento utilizado na transação.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o método de pagamento escolhido para a transação, com base no enumerador <c>MetodoPagamento</c>.
        /// </remarks>
        public MetodoPagamento? MetodoPagamento { get; set; }

        /// <summary>
        /// Construtor da classe <c>VendaCompra</c>.
        /// </summary>
        /// <remarks>
        /// Este construtor inicializa a data da venda com a data e hora atuais e define a data de fim da garantia como 36 meses após a data de venda.
        /// </remarks>
        public VendaCompra()
        {
            DataVenda = DateTime.Now.ToString();
            FimDataGarantia = DateTime.Now.AddMonths(36).ToString();
        }
    }
}
