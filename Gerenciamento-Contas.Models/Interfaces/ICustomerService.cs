using Gerenciamento.Contas.Models;

namespace Gerenciamento.Contas.Models.Interfaces {
    public interface ICustomerService {
        Task<bool> AddCustomer(Customer customerDetails);

        Task<Customer> GetCustomerById(int customerId);

        Task<bool> UpdateCustomer(Customer customer);

        Task<bool> DeleteCustomer(int customerId);

        Task<decimal> GetBalanceSumByCustomer(int id);

        Task<bool> BuyingAndSellingAssets(BuyingAndSellingAssetsDTO input);
    }
}