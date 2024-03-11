using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Log>(new LogMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }
    }
}
