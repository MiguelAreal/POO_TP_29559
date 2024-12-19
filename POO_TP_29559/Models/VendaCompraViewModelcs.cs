using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    /**
     * @class VendaCompraViewModel
     * @brief Representa a visualização de uma transação de venda ou compra para o utilizador.
     * 
     * A classe `VendaCompraViewModel` é usada para exibir os dados relacionados a uma transação de venda ou compra, incluindo informações
     * do cliente, data da transação, preço total, e método de pagamento. Esta classe é projetada para ser utilizada em interfaces de usuário.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */

    public class VendaCompraViewModel
    {
        /**
         * @brief Identificador único da venda ou compra.
         * 
         * Este campo armazena o identificador único da transação de venda ou compra.
         */
        public int Id { get; set; }

        /**
         * @brief Nome do cliente associado à venda ou compra.
         * 
         * Este campo armazena o nome do cliente relacionado com a transação, se aplicável.
         */
        [DisplayName("Cliente")]
        public string? ClienteNome { get; set; }

        /**
         * @brief Número de Identificação Fiscal (NIF) associado à venda ou compra.
         * 
         * Este campo armazena o NIF do cliente que realizou a transação.
         */
        [DisplayName("NIF")]
        public int? NIF { get; set; }

        /**
         * @brief Data em que a venda ou compra foi realizada.
         * 
         * Este campo armazena a data em que a transação foi efetuada.
         */
        [DisplayName("Data de Venda")]
        public string? DataVenda { get; set; }

        /**
         * @brief Preço total líquido da venda ou compra.
         * 
         * Este campo armazena o valor total da transação após a aplicação de descontos, caso existam.
         */
        [DisplayName("Preço Total")]
        public decimal TotalLiquido { get; set; }

        /**
         * @brief Método de pagamento utilizado na transação.
         * 
         * Este campo armazena o método de pagamento escolhido para a transação, como "Cartão", "Dinheiro", etc.
         */
        [DisplayName("Método de Pagamento")]
        public string? MetodoPagamento { get; set; }
    }
}
