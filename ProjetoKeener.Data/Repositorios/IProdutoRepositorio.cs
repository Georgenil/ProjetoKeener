using ProjetoKeener.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Dados.Repositorios
{
    public interface IProdutoRepositorio :IRepositorio<Produto>
    {
        IEnumerable<Produto> ObterProdutosPorFornecedor(int fornecedorId);
        IEnumerable<Produto> ObterProdutosFornecedores();
        Produto ObterProdutoFornecedor(int id);
    }
}
