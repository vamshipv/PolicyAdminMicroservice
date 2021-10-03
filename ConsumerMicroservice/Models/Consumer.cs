using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumerMicroservice.Models
{
    public partial class Consumer
    {

        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PanNumber { get; set; }
        public int AgentId { get; set; }

    }
}
