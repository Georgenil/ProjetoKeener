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
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        public int Adicionar(Fornecedor t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Add<Fornecedor>(t);
                return _connection.SaveChanges();
            }
        }

        public int Alterar(Fornecedor t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Entry(t).State = EntityState.Modified;
                return _connection.SaveChanges();
            }
        }

        public IEnumerable<Fornecedor> BuscarTodos()
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Fornecedores.AsEnumerable().ToList();
            }
        }

        public Fornecedor BuscarPorId(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Fornecedores.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Excluir(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Remove(_connection.Fornecedores.Single(x => x.Id == id));
                _connection.SaveChanges();
            }
        }
    }
}
