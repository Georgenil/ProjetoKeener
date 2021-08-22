using Microsoft.EntityFrameworkCore;
using ProjetoKeener.Data;
using ProjetoKeener.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Dados.Repositorios.Imp
{
    public class MovimentacaoRepositorio : IMovimentacaoRepositorio
    {
        public int Adicionar(Movimentacao t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Add<Movimentacao>(t);
                return _connection.SaveChanges();
            }
        }

        public int Alterar(Movimentacao t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Entry(t).State = EntityState.Modified;
                return _connection.SaveChanges();
            }
        }

        public IEnumerable<Movimentacao> BuscarTodos()
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Movimentacoes.AsEnumerable().ToList();
            }
        }

        public Movimentacao BuscarPorId(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Movimentacoes.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Excluir(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Remove(_connection.Movimentacoes.Single(x => x.Id == id));
                _connection.SaveChanges();
            }
        }

        public IEnumerable<Movimentacao> ObterMovimentacoesProdutos()
        {
            using (SqlContext _connection = new SqlContext())
            {
               return _connection.Movimentacoes.Include(m => m.Produto).AsEnumerable().ToList();
            }
        }
        public Movimentacao ObterMovimentacaoProduto(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Movimentacoes.AsNoTracking().Include(m => m.Produto)
                    .FirstOrDefault(x=> x.Id == id);
            }
        }
    }
}



