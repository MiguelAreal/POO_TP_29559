using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class ItemVenda
    {
        // Informação do produto na altura da venda
        public int? ProdutoID { get; set; }                
        public string ProdutoNome { get; set; }           
        public decimal PrecoUnitario { get; set; }        

        // ID de categoria, nome de categoria no momento da venda
        public int CategoriaID { get; set; }              
        public string CategoriaNome { get; set; }         

        // Nome de marca no momento da venda   
        public string MarcaNome { get; set; }              

        // Unidades vendidas de cada item
        public int Unidades { get; set; }

        // Percentagem de desconto dado a este item
        public int? PercentagemDesc { get;set; }

        [JsonConstructor]
        public ItemVenda(int? produtoID, string produtoNome, decimal precoUnitario, int categoriaID,
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
