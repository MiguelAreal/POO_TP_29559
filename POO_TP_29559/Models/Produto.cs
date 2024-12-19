using poo_tp_29559.Models;
using poo_tp_29559.Interfaces;
using System.ComponentModel;

/**
 * @class Produto
 * @brief Representa um produto no sistema.
 * 
 * A classe `Produto` armazena informações detalhadas sobre um produto, incluindo o nome, a categoria, a marca, 
 * o preço, a quantidade em stock e a data de adição. Esta classe é usada para representar os produtos no sistema 
 * e permite a gestão das informações associadas a eles.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class Produto : IIdentifiable
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
    [DisplayName("Nome do Produto")]
    public string Nome { get; set; }

    /**
     * @brief Identificador da categoria a que o produto pertence.
     * 
     * Este campo armazena o identificador da categoria do produto.
     */
    [DisplayName("Categoria")]
    public int CategoriaID { get; set; }

    /**
     * @brief Identificador da marca do produto.
     * 
     * Este campo armazena o identificador da marca associada ao produto.
     */
    [DisplayName("Marca")]
    public int MarcaID { get; set; }

    /**
     * @brief Preço do produto.
     * 
     * Este campo armazena o preço unitário do produto.
     */
    [DisplayName("Preço")]
    public decimal Preco { get; set; }

    /**
     * @brief Quantidade em stock do produto.
     * 
     * Este campo armazena a quantidade disponível do produto em stock.
     */
    [DisplayName("Stock")]
    public int QuantidadeEmStock { get; set; }

    /**
     * @brief Data de adição do produto.
     * 
     * Este campo armazena a data em que o produto foi adicionado ao sistema, representada como uma string.
     */
    [DisplayName("Data de Adição")]
    public string DataAdicao { get; set; }

    /**
     * @brief Construtor da classe Produto.
     * 
     * Este construtor inicializa a propriedade `DataAdicao` com a data e hora atuais e define o 
     * valor inicial de `QuantidadeEmStock` como 0.
     */
    public Produto()
    {
        DataAdicao = DateTime.Now.ToString();
        QuantidadeEmStock = 0;
    }
}
