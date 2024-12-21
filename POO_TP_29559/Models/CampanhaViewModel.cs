using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa a visão de uma campanha para o utilizador.
    /// </summary>
    /// <remarks>
    /// A classe <c>CampanhaViewModel</c> traduz as informações da entidade <c>Campanha</c> 
    /// para uma forma mais acessível e amigável, incluindo o nome da categoria em vez do seu identificador.
    /// </remarks>
    public class CampanhaViewModel
    {
        /// <summary>
        /// Identificador único da campanha.
        /// </summary>
        /// <remarks>
        /// Utilizado para referenciar a campanha no sistema.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome da campanha.
        /// </summary>
        /// <remarks>
        /// Nome descritivo exibido ao utilizador.
        /// </remarks>
        public string? Nome { get; set; }

        /// <summary>
        /// Percentagem de desconto da campanha.
        /// </summary>
        /// <remarks>
        /// Representado como uma percentagem (e.g., <c>10.00</c> para 10%).
        /// </remarks>
        [DisplayName("Percentagem de Desconto")]
        public decimal? PercentagemDesc { get; set; }

        /// <summary>
        /// Data de início da campanha.
        /// </summary>
        /// <remarks>
        /// Exibida na interface de utilizador no formato apropriado.
        /// </remarks>
        [DisplayName("Data de Início")]
        public string? DataInicio { get; set; }

        /// <summary>
        /// Data de fim da campanha.
        /// </summary>
        /// <remarks>
        /// Exibida na interface de utilizador no formato apropriado.
        /// </remarks>
        [DisplayName("Data de Fim")]
        public string? DataFim { get; set; }

        /// <summary>
        /// Nome da categoria associada à campanha.
        /// </summary>
        /// <remarks>
        /// Mostra o nome da categoria em vez do seu identificador, proporcionando uma experiência de utilizador mais amigável.
        /// </remarks>
        [DisplayName("Categoria Aplicada")]
        public string? CategoriaNome { get; set; }
    }
}
