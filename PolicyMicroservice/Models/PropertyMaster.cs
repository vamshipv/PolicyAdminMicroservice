using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyMicroservice.Models
{
    public partial class PropertyMaster
    {
        public PropertyMaster()
        {
            Properties = new HashSet<Property>();
        }

        public int PropertyMasterId { get; set; }
        public int CostOfAssest { get; set; }
        public int SalvageValue { get; set; }
        public int UsefulLifeOfAssest { get; set; }
        public int PropertyValue { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
