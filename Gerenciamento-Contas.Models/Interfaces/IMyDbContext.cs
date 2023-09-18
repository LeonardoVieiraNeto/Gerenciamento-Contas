using Microsoft.EntityFrameworkCore;
using Gerenciamento.Contas.Models;

namespace Gerenciamento.Contas.Models.Interfaces;

public interface IMyDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<BankAccount> BankAccounts { get; set; }
    DbSet<FinancialAssets> FinancialAssets { get; set; }
    DbSet<FinancialTransaction> FinancialTransaction { get; set; }
}
