using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyMicroservice.Models
{
    public partial class Quote
    {
        public Quote()
        {
            ConsumerPolicies = new HashSet<ConsumerPolicy>();
        }

        public int QuoteId { get; set; }
        public int PropertyValueFrom { get; set; }
        public int PropertyValueTo { get; set; }
        public int BusinesssValueFrom { get; set; }
        public int BusinesssValueTo { get; set; }
        public string PropertyType { get; set; }
        public decimal QuoteValue { get; set; }

        public virtual ICollection<ConsumerPolicy> ConsumerPolicies { get; set; }
    }
}
