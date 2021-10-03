using AuthorizationMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthorizationMicroservice.Repo;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationMicroservice.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly InsureityPortalDBContext context;

        public UserRepo(InsureityPortalDBContext authContext)
        {
            context = authContext;

        }
        public List<Agent> getuser()  
        {
            List<Agent> users = context.Agent.ToList();
            return users;
        }

        public Boolean IsUserValid(User user)
        {
            List<Agent> users = getuser();
            foreach (Agent u in users)
            {
                if (user.AgentName == u.AgentName && user.Password == u.Password)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
