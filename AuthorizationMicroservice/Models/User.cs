using System;
using System.Collections.Generic;

#nullable disable

namespace AuthorizationMicroservice.Models
{
    public partial class User
    {
        //public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
    }
}
