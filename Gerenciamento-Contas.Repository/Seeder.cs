using Gerenciamento.Contas.Models;

namespace Gerenciamento.Contas.Repository;

public static class Seeder
{
public static void Initialize(DbContextClass context)
{
   context.Database.EnsureCreated();

         // Verifique se a tabela de clientes está vazia
        if (!context.Customers.Any())
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Cliente 1",
                Email = "email1@test.com.br",
                Password = "123456"
            };

            var bankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, CustomerId = 1, Balance = 100.0m },
                new BankAccount { Id = 2, CustomerId = 1, Balance = 200.0m },
                new BankAccount { Id = 3, CustomerId = 1, Balance = 300.0m }
            };

            var financialAssets = new List<FinancialAssets>
            {
                new FinancialAssets {  Id = 1, Name = "Ações da XPT Magazine", Price = 150 },
                new FinancialAssets {  Id = 2, Name = "Títulos", Price = 174 },
                new FinancialAssets {  Id = 3, Name = "Moedas", Price = 133 },
                new FinancialAssets {  Id = 4, Name = "Fundos de Investimento", Price = 178 },
                new FinancialAssets {  Id = 5, Name = "Commodities", Price = 135 },
                new FinancialAssets {  Id = 6, Name = "Derivativos", Price = 145 },
                new FinancialAssets {  Id = 7, Name = "Imóveis", Price = 150000 }
            };

             var financialTransaction = new List<FinancialTransaction>
            {
                new FinancialTransaction {  Id = 1, AccountId = 1, Type = "Buy", AssetID = 1, Quantity = 1, TotalValue = 100, Date = new DateTime(1, 1, 2000)  },
                new FinancialTransaction {  Id = 2, AccountId = 1, Type = "Sell", AssetID = 1, Quantity = 1, TotalValue = 101, Date = new DateTime(1, 1, 2000)  },
                new FinancialTransaction {  Id = 3, AccountId = 1, Type = "Buy", AssetID = 1, Quantity = 1, TotalValue = 102, Date = new DateTime(1, 1, 2000)  },
                new FinancialTransaction {  Id = 4, AccountId = 1, Type = "Buy", AssetID = 2, Quantity = 22, TotalValue = 103, Date = new DateTime(1, 1, 2000)  },
                new FinancialTransaction {  Id = 5, AccountId = 1, Type = "Sell", AssetID = 3, Quantity = 100, TotalValue = 104, Date = new DateTime(1, 1, 2000)  },
                new FinancialTransaction {  Id = 6, AccountId = 1, Type = "Buy", AssetID = 1, Quantity = 1, TotalValue = 105, Date = new DateTime(1, 1, 2000)  },
                new FinancialTransaction {  Id = 7, AccountId = 1, Type = "Sell", AssetID = 1, Quantity = 1, TotalValue = 106, Date = new DateTime(1, 1, 2000)  }
            };

            context.Customers.Add(customer);
            context.BankAccounts.AddRange(bankAccounts);
            context.FinancialTransaction.AddRange(financialTransaction);

            context.SaveChanges();
        }
        }

}