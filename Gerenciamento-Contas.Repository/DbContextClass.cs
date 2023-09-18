using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gerenciamento.Contas.Models;
using Gerenciamento.Contas.Models.Interfaces;

namespace Gerenciamento.Contas.Repository
{
    public class DbContextClass : DbContext, IMyDbContext
    {
         public DbSet <Customer> Customers { get; set; }
         public DbSet <BankAccount> BankAccounts { get; set; }
         public DbSet <FinancialAssets> FinancialAssets { get; set; }
         public DbSet <FinancialTransaction> FinancialTransaction { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
            optionsBuilder.EnableSensitiveDataLogging(); // Isso habilitará logs detalhados
         }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
        .ToTable("Customers") // Especifica o nome da tabela
        .HasKey(c => c.Id); // Especifica a chave primária


            /*// Configura o relacionamento entre Customer e Account
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Accounts) // Um cliente pode ter várias contas
                .WithOne(a => a.Customer) // Uma conta pertence a um único cliente
                .HasForeignKey(a => a.CustomerId); // Chave estrangeira para CustomerId em Account


            modelBuilder.Entity<BankAccount>()
                .HasOne(b => b.Customer) // Uma conta pertence a um único cliente
                .WithMany(c => c.Accounts) // Um cliente pode ter várias contas
                .HasForeignKey(b => b.CustomerId); // Chave estrangeira em BankAccount
                */

            modelBuilder.Entity<BankAccount>()
                .HasOne(b => b.Customer)       // Define a relação de 1 para muitos
                .WithMany(c => c.Accounts) // Define a propriedade de navegação em Customer
                .HasForeignKey(b => b.CustomerId); // Define a chave estrangeira em BankAccount


            // Chama o método que preenche o banco de dados com dados iniciais, para facilitar o teste da aplicação por vocês.
            //DataSeeder.SeedData(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

    }
}