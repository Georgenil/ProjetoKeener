using Microsoft.AspNetCore.Http;
using ProjetoKeener.Entidades.Tipos;
using ProjetoKeener.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoKeener.Models
{
    public class ProdutoViewModel
    {        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}", MinimumLength = 2)]
        [DisplayName("Observação")]
        public string Obs { get; set; }

     //   public EnumTamanho Tamanho { get; set; }

        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        public bool Disponivel { get; set; }

        [DisplayName("Imagem")]
        public IFormFile ImagemUpload { get; set; }

        public string Imagem { get; set; }

        /* EF Relations */
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}