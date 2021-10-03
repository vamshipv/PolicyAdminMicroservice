using ConsumerMicroservice.Models;
using ConsumerMicroservice.RepositoryLayer.IRepositoryLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.RepositoryLayer
{
    public class ConsumerBusinessRepository : IConsumerBusinessRepository
    {
        private readonly InsureityPortalDBContext _dbContext;

        public ConsumerBusinessRepository(InsureityPortalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Business> GetBusiness()
        {
            return _dbContext.Business.Include(c => c.BusinessMaster).ToList();
        }

        // Get Business by Id
        public Business GetBusinesss(int BusinessId)
        {
            return _dbContext.Business.FirstOrDefault(x => x.BusinessId == BusinessId);
        }

        // Create Business 
        public bool CreateBusiness(Business? business)
        {
            _dbContext.Business.Add(business);
            return Save();
        }

        // Update business
        public bool UpdateBusiness(int ConsumerId, Business business)
        {
            _dbContext.Business.Update(business);
            return Save();
        }

        // delete business
        public bool DeleteBusiness(int BusinessId)
        {
            Business business = _dbContext.Business.FirstOrDefault(x => x.BusinessId == BusinessId);
            if (business != null)
            {
                _dbContext.Business.Remove(business);
            }
            return Save();
        }

        // check if Business Id exicts
        public bool BusinessExists(int BusinessId)
        {
            return _dbContext.Business.Any(a => a.BusinessId == BusinessId);
        }

        // return true if there is a insertion into database else false
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
    }
}
