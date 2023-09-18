using Gerenciamento.Contas.Repository;
using Gerenciamento.Contas.Models;
using Gerenciamento.Contas.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Gerenciamento.Contas.Services {

public class CustomerService: ICustomerService {
        
        readonly IUnitOfWork _unitOfWork;
        readonly ICustomerRepository _customerRepository;
        readonly ILogger<CustomerService> _logger;

        public CustomerService(IUnitOfWork unitOfWork, ILogger<CustomerService> logger, ICustomerRepository customerRepository) {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _customerRepository = customerRepository;
        }

       public async Task<bool> AddCustomer(Customer customer)
        {
            throw new Exception("Method not implementation");
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            throw new Exception("Method not implementation");
        }

        public  async Task<IEnumerable<Customer>> GetAllCustomersWithAccounts()
        {
            throw new Exception("Method not implementation");
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            throw new Exception("Method not implementation");
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            throw new Exception("Method not implementation");
        }

        public async Task<decimal> GetBalanceSumByCustomer(int id)
        {
            decimal somatorioSaldo = 0;

            if (id != null)
            {
                Customer customerBD = _customerRepository.GetBalanceAllCounts(id);

                if(customerBD != null)
                {
                    somatorioSaldo = customerBD.TotalBalance;
                }
            }        

            return somatorioSaldo;
        }

        public async Task<bool> BuyingAndSellingAssets(BuyingAndSellingAssetsDTO input)
        {

            var result = _customerRepository.AddBuyingAndSellingAssets(input);
            
            return true;
        }


        
    }
}