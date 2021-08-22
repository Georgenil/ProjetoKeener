using Microsoft.EntityFrameworkCore;
using ProjetoKeener.Data;
using ProjetoKeener.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoKeener.Dados.Repositorios.Imp
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public int Adicionar(Produto t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Add<Produto>(t);
                return _connection.SaveChanges();
            }
        }

        public int Alterar(Produto t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Entry(t).State = EntityState.Modified;
                return _connection.SaveChanges();
            }
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Produtos.AsEnumerable().ToList();
            }
        }

        public Produto BuscarPorId(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Produtos.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Excluir(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Remove(_connection.Produtos.Single(x => x.Id == id));
                _connection.SaveChanges();
            }
        }

        public void Dispose()
        {
            using (SqlContext _connection = new SqlContext())
            {            
                _connection?.Dispose(); 
            }
        }
        public Produto ObterProdutoFornecedor(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<Produto> ObterProdutosFornecedores()
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome)
                .AsEnumerable().ToList();
            }
        }

        public IEnumerable<Produto> ObterProdutosPorFornecedor(int idFornecedor)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Produtos.AsEnumerable().Where(p => p.IdFornecedor == idFornecedor).ToList();
            }
        }
    }
}
