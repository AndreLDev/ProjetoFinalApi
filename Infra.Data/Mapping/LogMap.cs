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
    public class LogMap : IEntityTypeConfiguration<Log>
    {

        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CodeRobot)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("CodeRobot")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.UserRobot)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("UserRobot")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.DateLog)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DateLog")
                .HasColumnType("date");

            builder.Property(prop => prop.Stage)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Stage")
                .HasColumnType("varchar(100)");


            builder.Property(prop => prop.InformationLog)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("InformationLog")
                .HasColumnType("varchar(100)");


            builder.Property(prop => prop.IdProduto)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("IdProduto")
                .HasColumnType("int");

            builder.HasOne(prop => prop.Produto)
                .WithMany()
                .HasForeignKey(prop => prop.IdProduto)
                .HasConstraintName("FK_Log_Produto");
        }
    }
}
