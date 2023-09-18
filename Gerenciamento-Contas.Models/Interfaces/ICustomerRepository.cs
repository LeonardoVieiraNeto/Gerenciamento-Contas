using Gerenciamento.Contas.Models;

namespace Gerenciamento.Contas.Models.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer>
{
     Task<Customer?> GetCustomerById(int id);
     Customer? GetBalanceAllCounts(int id);
     Task<bool> AddBuyingAndSellingAssets(BuyingAndSellingAssetsDTO input);
}