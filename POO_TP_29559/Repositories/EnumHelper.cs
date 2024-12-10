using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Repositories
{
    public static class EnumHelper
    {
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
