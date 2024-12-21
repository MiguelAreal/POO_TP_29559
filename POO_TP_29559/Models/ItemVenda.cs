using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    /// <summary>
    /// Representa um item de venda no sistema.
    /// </summary>
    /// <remarks>
    /// A classe <c>ItemVenda</c> armazena as informações de um produto específico vendido, incluindo dados como o nome do produto, 
    /// categoria, marca, preço unitário, unidades vendidas e o desconto aplicado. 
    /// Esta classe é usada para representar os produtos vendidos em uma transação.
    /// </remarks>
    public class ItemVenda
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador do produto associado ao item de venda.
        /// </remarks>
        public int ProdutoID { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome do produto no momento da venda.
        /// </remarks>
        public string ProdutoNome { get; set; }

        /// <summary>
        /// Preço unitário do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o preço unitário do produto no momento da venda.
        /// </remarks>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Identificador da categoria do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o identificador da categoria associada ao produto no momento da venda.
        /// </remarks>
        public int CategoriaID { get; set; }

        /// <summary>
        /// Nome da categoria do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome da categoria associada ao produto no momento da venda.
        /// </remarks>
        public string CategoriaNome { get; set; }

        /// <summary>
        /// Nome da marca do produto.
        /// </summary>
        /// <remarks>
        /// Este campo armazena o nome da marca associada ao produto no momento da venda.
        /// </remarks>
        public string MarcaNome { get; set; }

        /// <summary>
        /// Quantidade de unidades vendidas.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a quantidade de unidades vendidas de um determinado produto.
        /// </remarks>
        public int Unidades { get; set; }

        /// <summary>
        /// Percentagem de desconto aplicada ao item.
        /// </summary>
        /// <remarks>
        /// Este campo armazena a percentagem de desconto aplicada ao item na venda. Pode ser <c>null</c> caso não haja desconto.
        /// </remarks>
        public int? PercentagemDesc { get; set; }

        /// <summary>
        /// Construtor da classe <c>ItemVenda</c>.
        /// </summary>
        /// <param name="produtoID">Identificador único do produto.</param>
        /// <param name="produtoNome">Nome do produto.</param>
        /// <param name="precoUnitario">Preço unitário do produto.</param>
        /// <param name="categoriaID">Identificador da categoria do produto.</param>
        /// <param name="categoriaNome">Nome da categoria do produto.</param>
        /// <param name="marcaNome">Nome da marca do produto.</param>
        /// <param name="unidades">Quantidade de unidades vendidas.</param>
        /// <param name="percentagemDesc">Percentagem de desconto aplicada ao item, se houver.</param>
        [JsonConstructor]
        public ItemVenda(int produtoID, string produtoNome, decimal precoUnitario, int categoriaID,
                         string categoriaNome, string marcaNome, int unidades, int? percentagemDesc)
        {
            ProdutoID = produtoID;
            ProdutoNome = produtoNome;
            PrecoUnitario = precoUnitario;
            CategoriaID = categoriaID;
            CategoriaNome = categoriaNome;
            MarcaNome = marcaNome;
            Unidades = unidades;
            PercentagemDesc = percentagemDesc;
        }
    }
}
