using poo_tp_29559.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa uma categoria de produtos no sistema.
    /// </summary>
    /// <remarks>
    /// A classe <c>Categoria</c> armazena informações como o nome, descrição e data de criação de uma categoria. 
    /// Também oferece funcionalidade para verificar se a categoria pode ser eliminada, garantindo que não esteja associada a nenhum produto.
    /// </remarks>
    public class Categoria : IIdentifiable
    {
        /// <summary>
        /// Identificador único da categoria.
        /// </summary>
        /// <remarks>
        /// Utilizado para referenciar a categoria no sistema.
        /// </remarks>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria.
        /// </summary>
        /// <remarks>
        /// Nome que identifica a categoria e é exibido ao utilizador.
        /// </remarks>
        [DisplayName("Nome")]
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição da categoria.
        /// </summary>
        /// <remarks>
        /// Fornece detalhes adicionais sobre os produtos pertencentes à categoria.
        /// </remarks>
        [DisplayName("Descrição")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Data de criação da categoria.
        /// </summary>
        /// <remarks>
        /// A data é automaticamente atribuída no momento da criação da instância.
        /// </remarks>
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <c>Categoria</c>.
        /// </summary>
        /// <remarks>
        /// A propriedade <c>DataCriacao</c> é automaticamente definida com a data e hora atuais.
        /// </remarks>
        public Categoria()
        {
            DataCriacao = DateTime.Now;
        }

        /// <summary>
        /// Verifica se a categoria pode ser eliminada.
        /// </summary>
        /// <param name="produtos">Lista de produtos do sistema.</param>
        /// <returns>
        /// <c>true</c> se a categoria não estiver associada a nenhum produto, permitindo sua eliminação; 
        /// caso contrário, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Este método garante que a eliminação de categorias só ocorra se elas não estiverem associadas a nenhum produto.
        /// </remarks>
        public bool PodeSerEliminada(List<Produto> produtos)
        {
            return !produtos.Any(p => p.CategoriaID == this.Id);
        }
    }
}
