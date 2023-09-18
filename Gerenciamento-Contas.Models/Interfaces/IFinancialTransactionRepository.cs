using Gerenciamento.Contas.Models;

namespace Gerenciamento.Contas.Models.Interfaces;

public interface IFinancialTransactionRepository : IGenericRepository<FinancialTransaction>
{
     FinancialTransaction? GetAccountStatementInquiry(int id);
}