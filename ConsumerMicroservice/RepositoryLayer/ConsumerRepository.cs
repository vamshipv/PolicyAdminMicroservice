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
        private readonly InsureityPortalDBContext _dbContext;

        public ConsumerRepository(InsureityPortalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create Consumer, passing Consumer Class from Model Folder
        public bool CreateConsumer(Consumer consumer)
        {
            _dbContext.Consumer.Add(consumer);
            return Save();
        }

         // Delete Consumer with Id
        public bool DeleteConsumer(int ConsumerId)
        {
            Consumer consumer = _dbContext.Consumer.FirstOrDefault(x => x.ConsumerId == ConsumerId);
            if (consumer != null)
            {
                _dbContext.Consumer.Remove(consumer);
            }
            return Save();
        }

        // Get Consumer by Id
        public Consumer GetConsumer(int ConsumerId)
        {
            return _dbContext.Consumer.FirstOrDefault(x => x.ConsumerId == ConsumerId);
        }

        // get all consumer from the database
        public IEnumerable<Consumer> GetConsumers()
        {
            return _dbContext.Consumer.ToList();
        }

        // Update consumer
        public bool UpdateConsumer(int ConsumerId, Consumer consumer)
        {
            _dbContext.Consumer.Update(consumer);
            return Save();
        }

        // Check for if consumer already exixts
        public bool ConsumerExists(int ConsumerId)
        {
            return _dbContext.Consumer.Any(a => a.ConsumerId == ConsumerId);
        }

        // return True if there is a insertion into the database else false 
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }

        public IEnumerable<BusinessMaster> GetBusienssMaster()
        {
            return _dbContext.BusinessMaster.ToList();
        }

        public IEnumerable<PropertyMaster> GetPropertyMaster()
        {
            return _dbContext.PropertyMaster.ToList();
        }
    }
}
