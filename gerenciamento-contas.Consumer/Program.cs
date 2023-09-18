using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gerenciamento.Contas.Services;
using Gerenciamento.Contas.Models.Interfaces;
using Gerenciamento.Contas.Repository;

namespace WorkerConsumerRabbitMQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "*** Testando o consumo de mensagens com RabbitMQ + Filas ***");

            if (args.Length != 2)
            {
                Console.WriteLine(
                    "Informe 2 parametros: " +
                    "no primeiro a string de conexao com o RabbitMQ, " +
                    "no segundo a Fila/Queue a ser utilizado no consumo das mensagens...");
                return;
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ParametrosExecucao>(
                        new ParametrosExecucao()
                        {
                            ConnectionString = args[0],
                            Queue = args[1]
                        });
                        services.AddScoped<ICustomerService, CustomerService>();
                        services.AddScoped<IFinancialTransactionService, FinancialTransactionService>();
                        services.AddScoped<IRabitMQProducer, RabitMQProducer>();
                        services.AddScoped<IUnitOfWork, UnitOfWork>();
                        services.AddScoped<ICustomerRepository, CustomerRepository>();
                        services.AddHostedService<Worker>();
                        services.AddDbContext<DbContextClass>();
                });
    }
}