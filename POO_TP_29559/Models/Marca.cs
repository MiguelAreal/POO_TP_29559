using poo_tp_29559.Interfaces;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa uma marca no sistema.
    /// </summary>
    /// <remarks>
    /// A classe <c>Marca</c> armazena informações sobre uma marca, como seu nome, descrição, data de criação, 
    /// país de origem, e a sua relação com os produtos. Ela oferece funcionalidades para verificar se a marca 
    /// pode ser eliminada, com base na sua associação com produtos vendidos.
    /// </remarks>
    public class Marca : IIdentifiable
    {
        /// <summary>
        /// Identificador único da marca.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador único da marca.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome da marca.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome da marca.
        /// </remarks>
        [DisplayName("Nome da Marca")]
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição da marca.
        /// </summary>
        /// <remarks>
        /// Este campo armazena uma breve descrição sobre a marca.
        /// </remarks>
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Data de criação da marca.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a data em que a marca foi criada. A data é atribuída automaticamente 
        /// com a data e hora atuais quando a marca é instanciada.
        /// </remarks>
        [DisplayName("Data de Criação")]
        public string? DataCriacao { get; set; }

        /// <summary>
        /// País de origem da marca.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o país de origem da marca.
        /// </remarks>
        [DisplayName("País de Origem")]
        public string? PaisOrigem { get; set; }

        /// <summary>
        /// Construtor da classe <c>Marca</c>.
        /// </summary>
        /// <remarks>
        /// O construtor inicializa a propriedade <c>DataCriacao</c> com a data e hora atuais.
        /// </remarks>
        public Marca()
        {
            DataCriacao = DateTime.Now.ToString();
        }

        /// <summary>
        /// Verifica se a marca pode ser eliminada.
        /// </summary>
        /// <param name="produtos">Lista de produtos no sistema.</param>
        /// <returns>
        /// Retorna <c>true</c> se a marca não estiver associada a nenhum produto, 
        /// e portanto pode ser eliminada; caso contrário, retorna <c>false</c>.
        /// </returns>
        /// <remarks>
        /// A marca só pode ser eliminada se não estiver associada a nenhum produto.
        /// </remarks>
        public bool PodeSerEliminada(List<Produto> produtos)
        {
            return !produtos.Any(p => p.MarcaID == this.Id);
        }
    }
}
