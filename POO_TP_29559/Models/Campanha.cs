using System;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa uma campanha de marketing ou promoção.
    /// </summary>
    /// <remarks>
    /// A classe <c>Campanha</c> contém informações sobre promoções, como nome, percentagem de desconto, 
    /// período de vigência e a categoria à qual está vinculada. Implementa a interface <c>IIdentifiable</c>, 
    /// assegurando que cada campanha possui um identificador único.
    /// </remarks>
    public class Campanha : IIdentifiable
    {
        /// <summary>
        /// Identificador único da campanha.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da campanha.
        /// </summary>
        /// <remarks>
        /// Este é o nome descritivo da campanha, exibido na interface do utilizador.
        /// </remarks>
        [DisplayName("Nome de Campanha")]
        public string? Nome { get; set; }

        /// <summary>
        /// Percentagem de desconto oferecida pela campanha.
        /// </summary>
        /// <remarks>
        /// O valor representa uma percentagem, por exemplo, <c>10.00</c> para 10% de desconto.
        /// </remarks>
        [DisplayName("Percentagem de Desconto")]
        public decimal? PercentagemDesc { get; set; }

        /// <summary>
        /// Data de início da campanha.
        /// </summary>
        /// <remarks>
        /// Representada como uma string no formato de data esperado pela aplicação.
        /// </remarks>
        [DisplayName("Data de Inicio")]
        public string? DataInicio { get; set; }

        /// <summary>
        /// Data de fim da campanha.
        /// </summary>
        /// <remarks>
        /// Representada como uma string no formato de data esperado pela aplicação.
        /// </remarks>
        [DisplayName("Data de Fim")]
        public string? DataFim { get; set; }

        /// <summary>
        /// Identificador da categoria associada à campanha.
        /// </summary>
        /// <remarks>
        /// Este campo vincula a campanha a uma categoria específica de produtos ou serviços.
        /// </remarks>
        [DisplayName("Categoria Aplicada")]
        public int CategoriaId { get; set; }
    }
}
