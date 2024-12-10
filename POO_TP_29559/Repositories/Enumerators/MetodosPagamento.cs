using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_tp_29559.Repositories.Enumerators
{
    // Métodos de pagamento fixos.
    public enum MetodoPagamento
    {
        [Description("Débito")]
        Debito,

        [Description("Crédito")]
        Credito,

        [Description("Numerário")]
        Numerario
    }
}
