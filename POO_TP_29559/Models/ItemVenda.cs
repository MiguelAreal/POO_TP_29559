using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    public class ItemVenda
    {
        // Informação do produto na altura da venda
        public int? ProdutoID { get; set; }                
        public string? ProdutoNome { get; set; }           
        public decimal? PrecoUnitario { get; set; }        

        // ID de categoria, nome de categoria no momento da venda
        public int? CategoriaID { get; set; }              
        public string? CategoriaNome { get; set; }         

        // ID de marca, nome de marca no momento da venda   
        public string? MarcaNome { get; set; }              

        // Unidades vendidas
        public int? Unidades { get; set; }

        // Percentagem de desconto dado
        public int? PercentagemDesc { get;set; }

        // Constructor
        public ItemVenda(int produtoID, string produtoNome, decimal precoUnitario, int categoriaID,
                         string categoriaNome, string marcaNome, int unidades)
        {
            ProdutoID = produtoID;
            ProdutoNome = produtoNome;
            PrecoUnitario = precoUnitario;
            CategoriaID = categoriaID;
            CategoriaNome = categoriaNome;
            MarcaNome = marcaNome;
            Unidades = unidades;
        }
    }

}
