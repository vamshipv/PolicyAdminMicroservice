using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyMicroservice.Models
{
    public partial class Consumer
    {
        public Consumer()
        {
            Businesses = new HashSet<Business>();
        }

        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PanNumber { get; set; }
        public int AgentId { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
