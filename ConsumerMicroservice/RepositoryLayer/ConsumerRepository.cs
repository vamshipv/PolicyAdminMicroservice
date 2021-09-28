using ConsumerMicroservice.Models;
using ConsumerMicroservice.RepositoryLayer.IRepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.RepositoryLayer
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly PolicyAdminDBContext _dbContext;

        public ConsumerRepository(PolicyAdminDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateConsumer(Consumer consumer)
        {
            _dbContext.Consumer.Add(consumer);
            return Save();
        }

        public bool DeleteConsumer(int ConsumerId)
        {
            Consumer consumer = _dbContext.Consumer.FirstOrDefault(x => x.ConsumerId == ConsumerId);
            if (consumer != null)
            {
                _dbContext.Consumer.Remove(consumer);
            }
            return Save();
        }

        public Consumer GetConsumer(int ConsumerId)
        {
            return _dbContext.Consumer.FirstOrDefault(x => x.ConsumerId == ConsumerId);
        }

        public IEnumerable<Consumer> GetConsumers()
        {
            return _dbContext.Consumer.ToList();
        }

        public bool UpdateConsumer(int ConsumerId, Consumer consumer)
        {
            _dbContext.Consumer.Update(consumer);
            return Save();
        }

        public bool ConsumerExists(int ConsumerId)
        {
            return _dbContext.Consumer.Any(a => a.ConsumerId == ConsumerId);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
        //---------------------------------------------------------
        public IEnumerable<Business> GetBusiness()
        {
            return _dbContext.Business.Include(c => c.BusinessMaster).ToList();
        }

        public Business GetBusinesss(int BusinessId)
        {
            return _dbContext.Business.FirstOrDefault(x => x.BusinessId == BusinessId);
        }

        public bool CreateBusiness(Business business)
        {
            _dbContext.Business.Add(business);
            return Save();
        }

        public bool UpdateBusiness(int ConsumerId, Business business)
        {
            _dbContext.Business.Update(business);
            return Save();
        }

        public bool DeleteBusiness(int BusinessId)
        {
            Business business = _dbContext.Business.FirstOrDefault(x => x.BusinessId == BusinessId);
            if (business != null)
            {
                _dbContext.Business.Remove(business);
            }
            return Save();
        }

        public bool BusinessExists(int BusinessId)
        {
            return _dbContext.Business.Any(a => a.BusinessId == BusinessId);
        }
        //--------------------------------------------------------------------------
        public IEnumerable<Property> GetProperty()
        {
            //Use Inculde to add businessMaster in Get Api Display
            return _dbContext.Property.Include(c => c.PropertyMaster).ToList();
        }

        public Property GetProperties(int PropertyId)
        {
            return _dbContext.Property.FirstOrDefault(x => x.PropertyId == PropertyId);
        }

        public bool CreateProperty(Property property)
        {
            _dbContext.Property.Add(property);
            return Save();
        }

        public bool UpdateProperty(int PropertyId, Property property)
        {
            _dbContext.Property.Update(property);
            return Save();
        }

        public bool DeleteProperty(int PropertyId)
        {
            Property property = _dbContext.Property.FirstOrDefault(x => x.PropertyId == PropertyId);
            if (property != null)
            {
                _dbContext.Property.Remove(property);
            }
            return Save();
        }

        public bool PropertyExists(int PropertyId)
        {
            return _dbContext.Property.Any(a => a.PropertyId == PropertyId);
        }
    }
}
