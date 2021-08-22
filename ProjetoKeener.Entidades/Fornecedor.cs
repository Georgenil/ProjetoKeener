using ProjetoKeener.Entidades.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Entidades
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //public string Endereco { get; set; }
        //public string Numero { get; set; }
        //public string Bairro { get; set; }
        //public string Cep { get; set; }
        //public string Cidade { get; set; }
        public EnumFornecedor TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
       //public EnumEstado Estado { get; set; }
       //public string CNPJ { get; set; }

        /* EF Relations */
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
