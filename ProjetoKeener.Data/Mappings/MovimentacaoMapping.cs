using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoKeener.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKeener.Dados.Mappings
{
    public class MovimentacaoMapping : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(f => f.Id);

            // 1 : N => Produto : Movimentações
            builder.HasOne(x => x.Produto).WithMany(x => x.Movimentacoes);//Outra forma de dizer ao EF que essa é a chave estrageira
                                                                          //.HasForeignKey(mov=>mov.ProdutoId)
            //builder.HasMany(m => m.Produtos)
            //    .WithOne(p => p.Movimentacao)
            //    .HasForeignKey(p => p.IdMovimentacao);

            builder.ToTable("Movimentacoes");

        }
    }
}
