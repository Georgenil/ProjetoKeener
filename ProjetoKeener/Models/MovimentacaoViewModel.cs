using ProjetoKeener.Entidades;
using ProjetoKeener.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoKeener.Models
{
    public class MovimentacaoViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Produto")]
        public int IdProduto { get; set; }
        public DateTime Data { get; set; }

        [DisplayName("Tipo de Movimentação")]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }

        /* EF Relations */
        public ProdutoViewModel Produto { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
