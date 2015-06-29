using Fazenda.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("CustomerContext") { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Local> Locais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("TBCustomer");
            modelBuilder.Entity<Customer>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Local>().ToTable("TBLocal");
            modelBuilder.Entity<Local>()
                .Property(b => b.Entrada)
                .IsRequired();
            modelBuilder.Entity<Local>()
                .Property(b => b.Saida)
                .IsRequired();

        }

    }
}
