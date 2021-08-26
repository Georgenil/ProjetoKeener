using ProjetoKeener.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Entidades
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public TipoMovimentacao tipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }

        /* EF Relations */
        //public virtual IEnumerable<Produto> Produtos { get; set; }
        public Produto Produto { get; set; }

    }
}
