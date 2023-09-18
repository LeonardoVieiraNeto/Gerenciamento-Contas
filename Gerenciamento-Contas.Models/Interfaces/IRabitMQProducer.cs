using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento.Contas.Models.Interfaces
{
    public interface IRabitMQProducer
    {
        public void SendCustomerMessage < T > (T message);
    }
}