using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Entidades.Tipos
{
    public enum TipoMovimentacao
    {
        [Description("Entrada")]
        Entrada = 0,

        [Description("Saída")]
        Saida = 1
    }
}
