

using System.ComponentModel;

/**
 * @file MetodoPagamento.cs
 * @brief Enumeração para os métodos de pagamento disponíveis na aplicação.
 * 
 * Esta enumeração define os métodos de pagamento que os utilizadores podem selecionar
 * na aplicação para realizar transações. Cada valor da enumeração é associado a um 
 * método de pagamento específico.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

namespace poo_tp_29559.Repositories.Enumerators
{
    /**
     * @enum MetodoPagamento
     * @brief Enumeração que representa os métodos de pagamento na aplicação.
     * 
     * A enumeração `MetodoPagamento` define os métodos de pagamento disponíveis
     * para as transações na aplicação, incluindo pagamentos através de débito,
     * crédito e numerário.
     */
    public enum MetodoPagamento
    {
        /**
         * @brief Método de pagamento por débito.
         * 
         * Representa o pagamento através de cartão de débito.
         */
        [Description("Débito")]
        Debito,

        /**
         * @brief Método de pagamento por crédito.
         * 
         * Representa o pagamento através de cartão de crédito.
         */
        [Description("Crédito")]
        Credito,

        /**
         * @brief Método de pagamento por numerário.
         * 
         * Representa o pagamento realizado em dinheiro (numerário).
         */
        [Description("Numerário")]
        Numerario
    }
}
