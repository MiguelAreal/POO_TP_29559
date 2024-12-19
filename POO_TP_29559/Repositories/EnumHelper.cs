/**
 * @file EnumHelper.cs
 * @brief Classe utilitária para manipulação de enums.
 * 
 * A classe `EnumHelper` fornece métodos úteis para trabalhar com tipos enumerados (enums),
 * especialmente para recuperar as descrições associadas a cada valor de um enum.
 * Este utilitário é útil para obter as descrições de enums com o atributo `Description`.
 * 
 * @author Miguel Areal
 * @date 12/2024
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Repositories
{
    /**
     * @class EnumHelper
     * @brief Classe utilitária para manipulação de enums.
     * 
     * A classe `EnumHelper` fornece métodos estáticos para facilitar a manipulação de tipos enumerados
     * (enums) em C#. Um dos métodos principais desta classe é o `GetEnumDescriptions`, que permite
     * obter as descrições associadas aos valores de um enum utilizando o atributo `DescriptionAttribute`.
     */
    public static class EnumHelper
    {
        /**
         * @brief Obtém as descrições associadas aos valores de um enum.
         * 
         * Este método percorre todos os valores de um enum e retorna uma lista de pares chave-valor,
         * onde a chave é a descrição (definida pelo atributo `Description`) e o valor é o valor
         * correspondente do enum. Caso o atributo `Description` não esteja presente, o valor do enum
         * será utilizado como a descrição.
         * 
         * @tparam T Tipo do enum que será processado. O tipo `T` deve ser um enum.
         * @return Uma lista de pares chave-valor, onde a chave é a descrição do valor e o valor é o valor do enum.
         */
        public static List<KeyValuePair<string, T>> GetEnumDescriptions<T>() where T : Enum
        {
            var type = typeof(T);
            return Enum.GetValues(type)
                       .Cast<T>()
                       .Select(value =>
                       {
                           var field = type.GetField(value.ToString());
                           var description = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                  .Cast<DescriptionAttribute>()
                                                  .FirstOrDefault()?.Description ?? value.ToString();
                           return new KeyValuePair<string, T>(description, value);
                       }).ToList();
        }
    }
}
