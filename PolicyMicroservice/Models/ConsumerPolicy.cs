using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyMicroservice.Models
{
    public partial class ConsumerPolicy
    {
        public int PolicyId { get; set; }
        public int PropertyId { get; set; }
        public int QuoteId { get; set; }
        public string PolicyStatus { get; set; }
        public int PolicyMasterId { get; set; }

        public virtual PolicyMaster PolicyMaster { get; set; }
        public virtual Property Property { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
