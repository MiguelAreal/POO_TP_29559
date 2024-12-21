using System.ComponentModel;

namespace poo_tp_29559.Repositories.Enumerators
{
    /// <summary>
    /// Enumeração que representa os métodos de pagamento na aplicação.
    /// </summary>
    /// <remarks>
    /// A enumeração <c>MetodoPagamento</c> define os métodos de pagamento disponíveis para
    /// as transações na aplicação, incluindo pagamentos através de débito, crédito e numerário.
    /// </remarks>
    public enum MetodoPagamento
    {
        /// <summary>
        /// Método de pagamento por débito.
        /// </summary>
        /// <remarks>
        /// Representa o pagamento através de cartão de débito.
        /// </remarks>
        [Description("Débito")]
        Debito,

        /// <summary>
        /// Método de pagamento por crédito.
        /// </summary>
        /// <remarks>
        /// Representa o pagamento através de cartão de crédito.
        /// </remarks>
        [Description("Crédito")]
        Credito,

        /// <summary>
        /// Método de pagamento por numerário.
        /// </summary>
        /// <remarks>
        /// Representa o pagamento realizado em dinheiro (numerário).
        /// </remarks>
        [Description("Numerário")]
        Numerario
    }
}
