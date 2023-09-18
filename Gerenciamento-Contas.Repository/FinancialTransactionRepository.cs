using Gerenciamento.Contas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Gerenciamento.Contas.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gerenciamento.Contas.Repository;

public class FinancialTransactionRepository : GenericRepository<FinancialTransaction>, IFinancialTransactionRepository
{
    public FinancialTransactionRepository(DbContextClass dbContext) : base(dbContext)
    {
        
    }
         
    public FinancialTransaction?  GetAccountStatementInquiry(int id)
    {
        var financialTransaction = _dbContext.FinancialTransaction
                        .FromSql(@$"SELECT
                                    ft.Id AS Id,
                                    ft.AccountID AS AccountID,
                                    ft.Type as Type, 
                                    ft.AssetID as AssetID,
                                    ft.Quantity AS Quantity,
                                    ft.TotalValue AS TotalValue,
                                    ft.Date AS Date
                                FROM
                                    FinancialTransaction ft
                                WHERE
                                    ft.AccountID = {id}")
                    .SingleOrDefault();                    
            
            return financialTransaction;
    }
}
