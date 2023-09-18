using Gerenciamento.Contas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Gerenciamento.Contas.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gerenciamento.Contas.Repository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DbContextClass dbContext) : base(dbContext)
    {
        
    }

    public Customer? GetBalanceAllCounts(int id)
    {
        var customer = _dbContext.Customers
            .FromSql(@$"SELECT
                                    c.Id AS Id,
                                    c.Name AS Name,
                                    c.Password as Password, 
                                    c.Email as Email,
                                    SUM(bk.Balance) AS TotalBalance
                                FROM
                                    customers c
                                INNER JOIN
                                    BankAccounts bk ON c.Id = bk.CustomerId
                                WHERE
                                    c.Id = {id}")
                    .SingleOrDefault();                    
        
            return customer;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        return await _dbContext.Customers.FindAsync(id);
    }

    public async Task<bool> AddBuyingAndSellingAssets(BuyingAndSellingAssetsDTO input)
    {
        var inputTransactionDB = new FinancialTransaction { 
            AccountId = 1,
            Type = input.Type,
            AssetID = input.AssetID,
            Quantity = input.Quantity,
            TotalValue = input.TotalValue,
            Date = DateTime.Now
         };

        var result =  await _dbContext.FinancialTransaction.AddAsync(inputTransactionDB);

        

        return true;
    }
}
