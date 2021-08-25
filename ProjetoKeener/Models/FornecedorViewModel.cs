using ProjetoKeener.Entidades.Tipos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoKeener.Models
{
    public class FornecedorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caractéres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Tipo do fornecedor")]
        public EnumFornecedor TipoFornecedor { get; set; }
        public string Tipo { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
        //public EnumEstado Estado { get; set; }
    }
}
