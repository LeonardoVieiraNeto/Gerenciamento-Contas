using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerConsumerRabbitMQ
{
    public class ParametrosExecucao
    {
        // Exemplo de Connection String do RabbitMQ:
        // amqp://testes:RabbitMQ2020!@localhost:5672/
        public string ConnectionString { get; init; }
        public string Queue { get; init; }
    }
}