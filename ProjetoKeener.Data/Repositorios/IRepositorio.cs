using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Dados.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        public int Adicionar(T t);
        public int Alterar(T t);
        public void Excluir(int id);
        public IEnumerable<T> BuscarTodos();
        public T BuscarPorId(int id);
    }
}
