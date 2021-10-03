using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Service
{
    public interface IUserService
    {
        public List<Agent> getuser();
        public Boolean IsUserValid(User user);
    }
}
