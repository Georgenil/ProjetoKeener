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
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Obs)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Disponivel)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // N : 1 => Movimentaçoes : produto
            builder.HasMany(x => x.Movimentacoes).WithOne(x => x.Produto);
            //builder.HasOne(p => p.Movimentacao)
            //    .WithMany(m => m.Produtos)
            //    .HasForeignKey(p => p.IdMovimentacao);

            builder.ToTable("Produtos");

        }
    }
}
