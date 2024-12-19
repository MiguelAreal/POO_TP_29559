using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    /**
     * @class ItemVenda
     * @brief Representa um item de venda.
     * 
     * A classe `ItemVenda` armazena as informações de um item específico vendido, incluindo o produto, categoria,
     * marca, preço unitário, unidades vendidas e o desconto aplicado. Esta classe é utilizada para representar
     * os produtos vendidos em uma transação.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */
    public class ItemVenda
    {
        /**
         * @brief Identificador único do produto.
         * 
         * Este campo armazena o identificador do produto associado ao item de venda.
         */
        public int ProdutoID { get; set; }

        /**
         * @brief Nome do produto.
         * 
         * Este campo armazena o nome do produto no momento da venda.
         */
        public string ProdutoNome { get; set; }

        /**
         * @brief Preço unitário do produto.
         * 
         * Este campo armazena o preço unitário do produto no momento da venda.
         */
        public decimal PrecoUnitario { get; set; }

        /**
         * @brief Identificador da categoria do produto.
         * 
         * Este campo armazena o identificador da categoria associada ao produto no momento da venda.
         */
        public int CategoriaID { get; set; }

        /**
         * @brief Nome da categoria do produto.
         * 
         * Este campo armazena o nome da categoria associada ao produto no momento da venda.
         */
        public string CategoriaNome { get; set; }

        /**
         * @brief Nome da marca do produto.
         * 
         * Este campo armazena o nome da marca associada ao produto no momento da venda.
         */
        public string MarcaNome { get; set; }

        /**
         * @brief Quantidade de unidades vendidas.
         * 
         * Este campo armazena a quantidade de unidades vendidas de um determinado produto.
         */
        public int Unidades { get; set; }

        /**
         * @brief Percentagem de desconto aplicada ao item.
         * 
         * Este campo armazena a percentagem de desconto aplicada ao item na venda, se houver. Pode ser nulo.
         */
        public int? PercentagemDesc { get; set; }

        /**
         * @brief Construtor da classe ItemVenda.
         * 
         * Este construtor inicializa os campos da classe `ItemVenda` com os valores fornecidos, representando um item de venda
         * com todos os detalhes necessários, como produto, categoria, marca, unidades e desconto.
         * 
         * @param produtoID Identificador único do produto.
         * @param produtoNome Nome do produto.
         * @param precoUnitario Preço unitário do produto.
         * @param categoriaID Identificador da categoria do produto.
         * @param categoriaNome Nome da categoria do produto.
         * @param marcaNome Nome da marca do produto.
         * @param unidades Quantidade de unidades vendidas.
         * @param percentagemDesc Percentagem de desconto aplicada ao item, se houver.
         */
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
