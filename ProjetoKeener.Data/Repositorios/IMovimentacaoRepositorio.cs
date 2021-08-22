using ProjetoKeener.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Dados.Repositorios
{
    public interface IMovimentacaoRepositorio : IRepositorio<Movimentacao>
    {
        IEnumerable<Movimentacao> ObterMovimentacoesProdutos();
        Movimentacao ObterMovimentacaoProduto(int id);
    }
}
