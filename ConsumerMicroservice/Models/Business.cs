using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumerMicroservice.Models
{
    public partial class Business
    {
        //public Business()
        //{
        //    Properties = new HashSet<Property>();
        //}

        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public int TotalEmployees { get; set; }
        public int BusinessMasterId { get; set; }
        public int ConsumerId { get; set; }

        public virtual BusinessMaster BusinessMaster { get; set; }
        //public virtual Consumer Consumer { get; set; }
        //public virtual ICollection<Property> Properties { get; set; }
    }
}
