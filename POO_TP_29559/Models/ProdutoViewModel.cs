using System;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Classe que tem como objetivo ser exibida ao utilizador, de produtos.
    /// </summary>
    /// <remarks>
    /// A classe <c>ProdutoViewModel</c> é utilizada para exibir ao utilizador os detalhes de um produto,
    /// incluindo o nome da categoria e da marca associadas ao produto. Esta classe serve como um modelo de 
    /// visualização, proporcionando uma representação mais amigável para o utilizador com as informações 
    /// relevantes sobre os produtos disponíveis.
    /// </remarks>
    public class ProdutoViewModel
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único do produto.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome do produto.
        /// </remarks>
        public string? Nome { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o preço unitário do produto.
        /// </remarks>
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        /// <summary>
        /// Quantidade disponível em stock do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a quantidade disponível do produto no stock.
        /// </remarks>
        [DisplayName("Stock")]
        public int QuantidadeEmStock { get; set; }

        /// <summary>
        /// Nome da categoria associada ao produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome da categoria à qual o produto pertence.
        /// </remarks>
        [DisplayName("Categoria")]
        public string? CategoriaNome { get; set; }

        /// <summary>
        /// Nome da marca associada ao produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome da marca à qual o produto pertence.
        /// </remarks>
        [DisplayName("Marca")]
        public string? MarcaNome { get; set; }

        /// <summary>
        /// Data de adição do produto ao sistema.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data em que o produto foi adicionado ao sistema, representada como uma string.
        /// </remarks>
        [DisplayName("Data de Adição")]
        public string? DataAdicao { get; set; }
    }
}
