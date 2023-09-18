using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Gerenciamento.Contas.Models.Interfaces;

namespace Gerenciamento.Contas.Services
{
    public class RabitMQProducer : IRabitMQProducer
    {
         public void SendCustomerMessage < T > (T message) {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("financial-assets", exclusive: false);
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the customer queue
            channel.BasicPublish(exchange: "", routingKey: "financial-assets", body: body);
        }
    }
}