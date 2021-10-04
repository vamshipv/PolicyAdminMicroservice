using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyMicroservice.Models
{
    public partial class PolicyMaster
    {
        public PolicyMaster()
        {
            ConsumerPolicies = new HashSet<ConsumerPolicy>();
        }

        public int PolicyMasterId { get; set; }
        public string PropertyType { get; set; }
        public string ConsumerType { get; set; }
        public decimal AssuredSum { get; set; }
        public int Tenure { get; set; }
        public int BusinesssValue { get; set; }
        public int PropertyValue { get; set; }
        public string BaseLocation { get; set; }
        public string PolicyType { get; set; }

        public virtual ICollection<ConsumerPolicy> ConsumerPolicies { get; set; }
    }
}
