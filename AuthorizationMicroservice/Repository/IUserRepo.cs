using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationMicroservice.Repo
{
    public interface IUserRepo
    {
        public Boolean IsUserValid(User user);
        public List<Agent> getuser();
       
    }
}