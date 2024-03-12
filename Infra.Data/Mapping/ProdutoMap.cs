using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Desciption)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Desciption")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Price)
               .HasConversion(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Price")
               .HasColumnType("decimal(18, 2)");

            builder.Property(prop => prop.Stock)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Stock")
                .HasColumnType("int");

            builder.Property(prop => prop.MinStock)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("MinStock")
                .HasColumnType("int");

            builder.HasMany(p => p.Logs)
           .WithOne(l => l.Produto)
           .HasForeignKey(l => l.IdProduto)
           .HasConstraintName("FK_Log_Produto");
        }
    }
}
