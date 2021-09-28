using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumerMicroservice.Models
{
    public partial class Consumer
    {
        //public Consumer()
        //{
        //    Businesses = new HashSet<Business>();
        //}

        public int ConsumerId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PanNumber { get; set; }
        public int AgentId { get; set; }
        public string AgentName { get; set; }

        //public virtual ICollection<Business> Businesses { get; set; }
    }
}
