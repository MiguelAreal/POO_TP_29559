using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Models
{
    /**
     * @class CampanhaViewModel
     * @brief Representa a visão de uma campanha para o utilizador.
     * 
     * A classe `CampanhaViewModel` é utilizada para exibir ao utilizador as informações relativas a uma campanha, 
     * traduzindo as propriedades da classe `Campanha` para uma forma mais acessível. Além disso, esta classe inclui
     * a tradução do identificador da categoria para o nome da categoria, proporcionando uma experiência de utilizador
     * mais amigável.
     * 
     * @author Miguel Areal
     * @date 12/2024
     */
    public class CampanhaViewModel
    {
        /**
         * @brief Identificador único da campanha.
         * 
         * Este campo armazena o identificador único de cada campanha, utilizado para referenciar a campanha
         * na aplicação.
         */
        public int Id { get; set; }

        /**
         * @brief Nome da campanha.
         * 
         * Este campo armazena o nome da campanha, que será exibido na interface de utilizador.
         */
        public string? Nome { get; set; }

        /**
         * @brief Percentagem de desconto da campanha.
         * 
         * Este campo armazena o valor do desconto da campanha, representado como uma percentagem (por exemplo, 10.00
         * para um desconto de 10%).
         */
        [DisplayName("Percentagem de Desconto")]
        public decimal? PercentagemDesc { get; set; }

        /**
         * @brief Data de início da campanha.
         * 
         * Este campo armazena a data de início da campanha, que será exibida na interface de utilizador. A data é fornecida
         * como uma string no formato apropriado.
         */
        [DisplayName("Data de Início")]
        public string? DataInicio { get; set; }

        /**
         * @brief Data de fim da campanha.
         * 
         * Este campo armazena a data de fim da campanha, que será exibida na interface de utilizador. A data é fornecida
         * como uma string no formato apropriado.
         */
        [DisplayName("Data de Fim")]
        public string? DataFim { get; set; }

        /**
         * @brief Nome da categoria associada à campanha.
         * 
         * Este campo armazena o nome da categoria à qual a campanha está associada. 
         * Ao invés de exibir o identificador da categoria, o nome da categoria é mostrado ao utilizador.
         */
        [DisplayName("Categoria Aplicada")]
        public string? CategoriaNome { get; set; }
    }
}
