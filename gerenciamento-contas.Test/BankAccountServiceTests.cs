using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Gerenciamento.Contas.Repository;
using Gerenciamento.Contas.Models;
using Gerenciamento.Contas.Services;
using Gerenciamento.Contas.Models.Interfaces;
using Microsoft.Extensions.Logging;

namespace gerenciamento_contas.Test
{
    [TestFixture]
    public class BankAccountServiceTests
    {
        [SetUp]
        public void TestInitialize()
        {
           
        }
        /*
        [Test]
        public async Task GetSomatorioSaldoPorCliente_ShouldCalculateTotalBalance()
        {
            // Arrange
            var customerId = 1;
            
            // Crie um objeto Customer simulado com uma lista de contas bancárias fictícias
            var customer = new Customer
            {
                Id = customerId,
                Accounts = new List<BankAccount>
                {
                    new BankAccount { Id = 1, CustomerId = customerId, Balance = 100.0m },
                    new BankAccount { Id = 2, CustomerId = customerId, Balance = 200.0m },
                    new BankAccount { Id = 3, CustomerId = customerId, Balance = 300.0m }
                }
            };

            var customerService = new ICustomerService();
            var abitMQProducer = new Mock<IRabitMQProducer>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var loggerMock = new Mock<ILogger<CustomerService>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            // Configure o mock para retornar o objeto Customer simulado
            customerRepositoryMock.Setup(m => m.GetById(customerId)).ReturnsAsync(customer);
            //unitOfWorkMock.Setup(m => m.Customers).Returns(customerRepositoryMock.Object);

            // Crie uma instância de CustomerService usando o mock de IUnitOfWork
            customerService = new CustomerService(unitOfWorkMock.Object, loggerMock.Object, customerRepositoryMock.Object);

            // Act
            decimal somatorioSaldo = await customerService.GetSomatorioSaldoPorCliente(customerId);

            // Assert
            decimal expectedTotalBalance = 600.0m; // O saldo total esperado
            Assert.AreEqual(expectedTotalBalance, somatorioSaldo);
            */
        }
    }

