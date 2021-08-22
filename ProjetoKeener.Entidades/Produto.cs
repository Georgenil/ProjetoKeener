using ProjetoKeener.Entidades.Tipos;
using System;
using System.Collections.Generic;

namespace ProjetoKeener.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public int IdFornecedor { get; set; }
        public int IdMovimentacao { get; set; }
        public string Nome { get; set; }
        public string Obs { get; set; }
        public string Imagem { get; set; }

       // public EnumTamanho Tamanho { get; set; }
        public decimal Preco { get; set; }
        public bool Disponivel { get; set; }

        /* EF Relations */
        public Fornecedor Fornecedor { get; set; }
        //public Movimentacao Movimentacao { get; set; }
        public IEnumerable<Movimentacao> Movimentacoes { get; set; }
    }
}
