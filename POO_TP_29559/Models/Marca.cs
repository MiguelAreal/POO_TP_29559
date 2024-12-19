using poo_tp_29559.Interfaces;
using System.ComponentModel;

/**
 * @class Marca
 * @brief Representa uma marca.
 * 
 * A classe `Marca` armazena as informações de uma marca, incluindo o nome, descrição, data de criação, 
 * país de origem e a sua relação com produtos. Esta classe permite gerir as marcas associadas a produtos
 * no sistema.
 * 
 * A classe oferece funcionalidades para verificar se a marca pode ser eliminada, com base na sua associação
 * com produtos vendidos, e permite a definição de uma data de criação automática.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */
public class Marca : IIdentifiable
{
    /**
     * @brief Identificador único da marca.
     * 
     * Este campo armazena o identificador único da marca.
     */
    public int Id { get; set; }

    /**
     * @brief Nome da marca.
     * 
     * Este campo armazena o nome da marca.
     */
    [DisplayName("Nome da Marca")]
    public string? Nome { get; set; }

    /**
     * @brief Descrição da marca.
     * 
     * Este campo armazena uma breve descrição da marca.
     */
    [DisplayName("Descrição")]
    public string? Descricao { get; set; }

    /**
     * @brief Data de criação da marca.
     * 
     * Este campo armazena a data de criação da marca, representada como uma string.
     */
    [DisplayName("Data de Criação")]
    public string? DataCriacao { get; set; }

    /**
     * @brief País de origem da marca.
     * 
     * Este campo armazena o país de origem da marca.
     */
    [DisplayName("País de Origem")]
    public string? PaisOrigem { get; set; }

    /**
     * @brief Construtor da classe Marca.
     * 
     * Este construtor inicializa a propriedade `DataCriacao` com a data e hora atuais.
     */
    public Marca()
    {
        DataCriacao = DateTime.Now.ToString();
    }

    /**
     * @brief Verifica se a marca pode ser eliminada.
     * 
     * Este método verifica se a marca pode ser eliminada com base na sua associação a produtos. 
     * A marca só pode ser eliminada se não estiver associada a nenhum produto.
     * 
     * @param produtos Lista de produtos para verificar se algum está associado a esta marca.
     * @return Retorna `true` se a marca pode ser eliminada, ou `false` caso contrário.
     */
    public bool PodeSerEliminada(List<Produto> produtos)
    {
        return !produtos.Any(p => p.MarcaID == this.Id);
    }
}
