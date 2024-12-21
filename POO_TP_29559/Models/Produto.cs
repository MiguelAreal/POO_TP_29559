using poo_tp_29559.Models;
using poo_tp_29559.Interfaces;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa um produto no sistema.
    /// </summary>
    /// <remarks>
    /// A classe <c>Produto</c> armazena informações detalhadas sobre um produto, como nome, categoria, 
    /// marca, preço, quantidade em estoque e data de adição. É usada para representar produtos dentro do sistema 
    /// e permite a gestão das informações associadas a eles.
    /// </remarks>
    public class Produto : IIdentifiable
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
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }

        /// <summary>
        /// Identificador da categoria à qual o produto pertence.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador da categoria a que o produto pertence.
        /// </remarks>
        [DisplayName("Categoria")]
        public int CategoriaID { get; set; }

        /// <summary>
        /// Identificador da marca do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador da marca associada ao produto.
        /// </remarks>
        [DisplayName("Marca")]
        public int MarcaID { get; set; }

        /// <summary>
        /// Preço unitário do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o preço unitário do produto.
        /// </remarks>
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        /// <summary>
        /// Quantidade em estoque do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a quantidade disponível do produto em estoque.
        /// </remarks>
        [DisplayName("Stock")]
        public int QuantidadeEmStock { get; set; }

        /// <summary>
        /// Data de adição do produto ao sistema.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data em que o produto foi adicionado ao sistema.
        /// </remarks>
        [DisplayName("Data de Adição")]
        public string DataAdicao { get; set; }

        /// <summary>
        /// Construtor da classe <c>Produto</c>.
        /// </summary>
        /// <remarks>
        /// Este construtor inicializa a propriedade <c>DataAdicao</c> com a data e hora atuais 
        /// e define o valor inicial de <c>QuantidadeEmStock</c> como 0.
        /// </remarks>
        public Produto()
        {
            DataAdicao = DateTime.Now.ToString();
            QuantidadeEmStock = 0;
        }
    }
}
