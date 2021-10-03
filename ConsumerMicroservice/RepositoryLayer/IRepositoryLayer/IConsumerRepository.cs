using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.RepositoryLayer.IRepositoryLayer
{
    public interface IConsumerRepository
    {
        // Return a Bool value when opertions are done , this is Consumer 
        IEnumerable<Consumer> GetConsumers();
        Consumer GetConsumer(int ConsumerId);
        bool CreateConsumer(Consumer consumer);
        bool UpdateConsumer(int ConsumerId, Consumer consumer);
        bool DeleteConsumer(int ConsumerId);
        bool ConsumerExists(int ConsumerId);
        bool Save();
    }
}
