using AuthorizationMicroservice.Models;
using AuthorizationMicroservice.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationMicroservice.Service
{
   public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        { 
            _userRepo = userRepo;
        }
        public List<Agent> getuser()
        {
            return _userRepo.getuser();
        }

        public Boolean IsUserValid(User user)
        {
            return _userRepo.IsUserValid(user);
        }
    }
}
