using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.ServiceLayer
{
    public interface IConsumerService
    {
        // For Consumer
        IEnumerable<Consumer> GetConsumers();
        Consumer GetConsumer(int ConsumerId);
        bool CreateConsumer(Consumer consumer);
        bool UpdateConsumer(int ConsumerId, Consumer consumer);
        bool DeleteConsumer(int ConsumerId);
        bool ConsumerExists(int ConsumerId);

        // For Business
        IEnumerable<Business> GetBusiness();
        Business GetBusinesss(int BusinessId);
        bool CreateBusiness(Business business);
        bool UpdateBusiness(int ConsumerId, Business business);
        bool DeleteBusiness(int BusinessId);
        bool BusinessExists(int BusinessId);

        // For PRoperty
        IEnumerable<Property> GetProperty();
        Property GetProperties(int PropertyId);
        bool CreateProperty(Property property);
        bool UpdateProperty(int PropertyId, Property property);
        bool DeleteProperty(int PropertyId);
        bool PropertyExists(int PropertyId);

        // Business Master and Property Master
        IEnumerable<BusinessMaster> GetBusienssMaster();
        IEnumerable<PropertyMaster> GetPropertyMaster();
        bool Save();
    }
}
