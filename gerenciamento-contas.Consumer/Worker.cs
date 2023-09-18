using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Gerenciamento.Contas.Services;
using Gerenciamento.Contas.Models.Interfaces;
using Gerenciamento.Contas.Models;
using Newtonsoft.Json;

namespace WorkerConsumerRabbitMQ
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly int _intervaloMensagemWorkerAtivo;
        private readonly ParametrosExecucao _parametrosExecucao;        
        private readonly ICustomerService _customerService;

        public Worker(ILogger<Worker> logger,
            IConfiguration configuration,
            ParametrosExecucao parametrosExecucao, 
            ICustomerService customerService
            )
        {
            logger.LogInformation(
                $"Queue = {parametrosExecucao.Queue}");

            _logger = logger;
            _intervaloMensagemWorkerAtivo =
                Convert.ToInt32(configuration["IntervaloMensagemWorkerAtivo"]);
            _parametrosExecucao = parametrosExecucao;
            _customerService = customerService;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Aguardando mensagens...");

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_parametrosExecucao.ConnectionString)
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _parametrosExecucao.Queue,
                                durable: false,
                                exclusive: false,
                                autoDelete: true,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(queue: _parametrosExecucao.Queue,
                autoAck: true,
                consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(
                    $"Worker ativo em: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                await Task.Delay(_intervaloMensagemWorkerAtivo, stoppingToken);
            }
        }

        private void Consumer_Received(
            object sender, BasicDeliverEventArgs e)
        {
            

            //_customerService.BuyingAndSellingAssets(e.Body.AccountID);

              //_logger.LogInformation($"Valor: {e.Body.ToArray().AccountID}");

            _logger.LogInformation(
                $"[Nova mensagem | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                Encoding.UTF8.GetString(e.Body.ToArray()));

            byte[] data = e.Body.ToArray(); // Substitua pela forma como você obtém os dados da fila

            // Desserializa os dados JSON para um objeto DTO
            var eventData = JsonConvert.DeserializeObject<BuyingAndSellingAssetsDTO>(Encoding.UTF8.GetString(data));

            var result = _customerService.BuyingAndSellingAssets(eventData);

            Console.WriteLine("BuyingAndSellingAssets inserido com sucesso.");
        }
    }
}