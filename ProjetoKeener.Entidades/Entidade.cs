using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Entidades
{
    public class Entidade
    {
        protected Entidade()
        {
            Id = new int();
        }
        public int Id { get; set; }
    }
}
