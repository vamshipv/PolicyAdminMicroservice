using ConsumerMicroservice.Models;
using ConsumerMicroservice.RepositoryLayer.IRepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.ServiceLayer
{
    public class ConsumerService 
    {
        private readonly IConsumerRepository _consumerRepository;
        private readonly IConsumerBusinessRepository _consumerBusinessRepository;
        private readonly IBusinessPropertyRepository _businessPropertyRepository;
        public ConsumerService(IConsumerRepository consumerRepository, IConsumerBusinessRepository consumerBusinessRepository,IBusinessPropertyRepository businessPropertyRepository)
        {
            _consumerRepository = consumerRepository;
            _consumerBusinessRepository = consumerBusinessRepository;
            _businessPropertyRepository = businessPropertyRepository; 
        }

        public bool BusinessExists(int BusinessId)
        {
            return _consumerBusinessRepository.BusinessExists(BusinessId);
        }

        public bool ConsumerExists(int ConsumerId)
        {
            return _consumerRepository.ConsumerExists(ConsumerId);
        }

        public bool CreateBusiness(Business business)
        {
            return _consumerBusinessRepository.CreateBusiness(business);
        }

        public bool CreateConsumer(Consumer consumer)
        {
            return _consumerRepository.CreateConsumer(consumer);
        }

        public bool CreateProperty(Property property)
        {
            return _businessPropertyRepository.CreateProperty(property);
        }

        public bool DeleteBusiness(int BusinessId)
        {
            return _consumerBusinessRepository.DeleteBusiness(BusinessId);
        }

        public bool DeleteConsumer(int ConsumerId)
        {
            return _consumerRepository.DeleteConsumer(ConsumerId);
        }

        public bool DeleteProperty(int PropertyId)
        {
            return _businessPropertyRepository.DeleteProperty(PropertyId);
        }

        public IEnumerable<Business> GetBusiness()
        {
            return _consumerBusinessRepository.GetBusiness();
        }

        public Business GetBusinesss(int BusinessId)
        {
            return _consumerBusinessRepository.GetBusinesss(BusinessId);
        }

        public Consumer GetConsumer(int ConsumerId)
        {
            return _consumerRepository.GetConsumer(ConsumerId);
        }

        public IEnumerable<Consumer> GetConsumers()
        {
            return _consumerRepository.GetConsumers();
        }

        public Property GetProperties(int PropertyId)
        {
            return _businessPropertyRepository.GetProperties(PropertyId);
        }

        public IEnumerable<Property> GetProperty()
        {
            return _businessPropertyRepository.GetProperty();
        }

        public bool PropertyExists(int PropertyId)
        {
            return _businessPropertyRepository.PropertyExists(PropertyId);
        }

        public bool Save()
        {
            return _consumerRepository.Save();
        }

        public bool UpdateBusiness(int ConsumerId, Business business)
        {
            return _consumerBusinessRepository.UpdateBusiness(ConsumerId, business);
        }

        public bool UpdateConsumer(int ConsumerId, Consumer consumer)
        {
            return _consumerRepository.UpdateConsumer(ConsumerId, consumer);
        }

        public bool UpdateProperty(int PropertyId, Property property)
        {
            return _businessPropertyRepository.UpdateProperty(PropertyId, property);
        }
    }
}
