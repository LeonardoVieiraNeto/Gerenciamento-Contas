using Gerenciamento.Contas.Repository;
using Gerenciamento.Contas.Models;
using Gerenciamento.Contas.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Gerenciamento.Contas.Services {

public class FinancialTransactionService: IFinancialTransactionService {
        
        readonly IUnitOfWork _unitOfWork;
        readonly IFinancialTransactionRepository _financialTransactionRepository;
        readonly ILogger<FinancialTransactionService> _logger;

        public FinancialTransactionService(IUnitOfWork unitOfWork, ILogger<FinancialTransactionService> logger, // Correção aqui
        IFinancialTransactionRepository financialTransactionRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _financialTransactionRepository = financialTransactionRepository;
        }


         public FinancialTransaction?  GetAccountStatementInquiry(int id)
         {
            return _financialTransactionRepository.GetAccountStatementInquiry(id);
         }


        
    }
}