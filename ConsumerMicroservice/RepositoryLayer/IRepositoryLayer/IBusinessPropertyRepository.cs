using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.RepositoryLayer.IRepositoryLayer
{
    public interface IBusinessPropertyRepository
    {
        // Return a Bool value when opertions are done , this is Property 
        IEnumerable<Property> GetProperty();
        Property GetProperties(int PropertyId);
        bool CreateProperty(Property property);
        bool UpdateProperty(int PropertyId, Property property);
        bool DeleteProperty(int PropertyId);
        bool PropertyExists(int PropertyId);
        bool Save();
    }
}
