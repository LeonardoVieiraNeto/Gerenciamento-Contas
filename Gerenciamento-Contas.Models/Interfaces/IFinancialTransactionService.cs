using Gerenciamento.Contas.Models;

namespace Gerenciamento.Contas.Models.Interfaces {
    public interface IFinancialTransactionService {
        FinancialTransaction?  GetAccountStatementInquiry(int id);
    }
}