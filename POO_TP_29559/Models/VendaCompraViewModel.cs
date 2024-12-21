using System;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa a visualização de uma transação de venda ou compra para o utilizador.
    /// </summary>
    /// <remarks>
    /// A classe <c>VendaCompraViewModel</c> é usada para exibir os dados relacionados a uma transação de venda ou compra,
    /// incluindo informações do cliente, data da transação, preço total, e método de pagamento. 
    /// Esta classe é projetada para ser utilizada em interfaces de usuário.
    /// </remarks>
    public class VendaCompraViewModel
    {
        /// <summary>
        /// Identificador único da venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único da transação de venda ou compra.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente associado à venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome do cliente relacionado com a transação, se aplicável.
        /// </remarks>
        [DisplayName("Cliente")]
        public string? ClienteNome { get; set; }

        /// <summary>
        /// Identificador único do cliente associado à venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único do cliente relacionado à transação. Este campo está oculto 
        /// para o utilizador final, mas pode ser utilizado no backend para identificar o cliente.
        /// </remarks>
        [Browsable(false)]
        [DisplayName("ClienteID")]
        public int? ClienteID { get; set; }

        /// <summary>
        /// Número de Identificação Fiscal (NIF) associado à venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o NIF do cliente que realizou a transação.
        /// </remarks>
        [DisplayName("NIF")]
        public int? NIF { get; set; }

        /// <summary>
        /// Data em que a venda ou compra foi realizada.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data em que a transação foi efetuada.
        /// </remarks>
        [DisplayName("Data de Venda")]
        public string? DataVenda { get; set; }

        /// <summary>
        /// Preço total líquido da venda ou compra.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o valor total da transação após a aplicação de descontos, caso existam.
        /// </remarks>
        [DisplayName("Preço Total")]
        public decimal TotalLiquido { get; set; }

        /// <summary>
        /// Método de pagamento utilizado na transação.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o método de pagamento escolhido para a transação, como "Cartão", "Dinheiro", etc.
        /// </remarks>
        [DisplayName("Método de Pagamento")]
        public string? MetodoPagamento { get; set; }
    }
}
