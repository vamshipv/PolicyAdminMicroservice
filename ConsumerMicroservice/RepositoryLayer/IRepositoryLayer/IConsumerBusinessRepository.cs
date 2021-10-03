using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.RepositoryLayer.IRepositoryLayer
{
    public interface IConsumerBusinessRepository
    {
        // Return a Bool value when opertions are done , this is Business 
        IEnumerable<Business> GetBusiness();
        Business GetBusinesss(int BusinessId);
        bool CreateBusiness(Business business);
        bool UpdateBusiness(int ConsumerId, Business business);
        bool DeleteBusiness(int BusinessId);
        bool BusinessExists(int BusinessId);
        bool Save();
    }
}
