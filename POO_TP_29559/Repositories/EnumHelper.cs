using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace poo_tp_29559.Repositories
{
    /// <summary>
    /// Classe utilitária para manipulação de enums.
    /// </summary>
    /// <remarks>
    /// A classe <c>EnumHelper</c> fornece métodos úteis para trabalhar com tipos enumerados (enums),
    /// especialmente para recuperar as descrições associadas a cada valor de um enum. Este utilitário
    /// é útil para obter as descrições de enums com o atributo <c>Description</c>.
    /// </remarks>
    public static class EnumHelper
    {
        #region Public Methods
        /// <summary>
        /// Obtém as descrições associadas aos valores de um enum.
        /// </summary>
        /// <remarks>
        /// Este método percorre todos os valores de um enum e retorna uma lista de pares chave-valor,
        /// onde a chave é a descrição (definida pelo atributo <c>Description</c>) e o valor é o valor
        /// correspondente do enum. Caso o atributo <c>Description</c> não esteja presente, o valor do enum
        /// será utilizado como a descrição.
        /// </remarks>
        /// <typeparam name="T">Tipo do enum que será processado. O tipo <c>T</c> deve ser um enum.</typeparam>
        /// <returns>
        /// Uma lista de pares chave-valor, onde a chave é a descrição do valor e o valor é o valor do enum.
        /// </returns>
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
        #endregion
    }
}
