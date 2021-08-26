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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public int Adicionar(Usuario t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Add<Usuario>(t);
                return _connection.SaveChanges();
            }
        }

        public int Alterar(Usuario t)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Entry(t).State = EntityState.Modified;
                return _connection.SaveChanges();
            }
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Usuarios.AsEnumerable().ToList();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                return _connection.Usuarios.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Excluir(int id)
        {
            using (SqlContext _connection = new SqlContext())
            {
                _connection.Remove(_connection.Usuarios.Single(x => x.Id == id));
                _connection.SaveChanges();
            }
        }
    }
}

