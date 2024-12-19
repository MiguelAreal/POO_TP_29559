using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
     /**
     * @class ProdutoViewModel
     * @brief Classe que tem como objetivo ser exibida ao utilizador, de produtos.
     * 
     *  Através da classe original `Produto`, esta é utilizada para exibir ao utilizador os detalhes do produto, 
     *  incluindo o nome da categoria e da marca associadas ao produto.
     *  Esta classe serve como um modelo de visualização, proporcionando uma representação mais amigável para o utilizador
     *  com as informações relevantes sobre os produtos disponíveis.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */
    public class ProdutoViewModel
    {
        /**
         * @brief Identificador único do produto.
         * 
         * Este campo armazena o identificador único do produto.
         */
        public int Id { get; set; }

        /**
         * @brief Nome do produto.
         * 
         * Este campo armazena o nome do produto.
         */
        public string? Nome { get; set; }

        /**
         * @brief Preço do produto.
         * 
         * Este campo armazena o preço unitário do produto.
         */
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        /**
         * @brief Quantidade disponível em stock do produto.
         * 
         * Este campo armazena a quantidade disponível do produto no stock.
         */
        [DisplayName("Stock")]
        public int QuantidadeEmStock { get; set; }

        /**
         * @brief Nome da categoria associada ao produto.
         * 
         * Este campo armazena o nome da categoria à qual o produto pertence.
         */
        [DisplayName("Categoria")]
        public string? CategoriaNome { get; set; }

        /**
         * @brief Nome da marca associada ao produto.
         * 
         * Este campo armazena o nome da marca à qual o produto pertence.
         */
        [DisplayName("Marca")]
        public string? MarcaNome { get; set; }

        /**
         * @brief Data de adição do produto.
         * 
         * Este campo armazena a data em que o produto foi adicionado ao sistema, representada como uma string.
         */
        [DisplayName("Data de Adição")]
        public string? DataAdicao { get; set; }
    }
}
