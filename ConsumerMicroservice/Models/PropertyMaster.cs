using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumerMicroservice.Models
{
    public partial class PropertyMaster
    {
        public int PropertyMasterId { get; set; }
        public int CostOfAssest { get; set; }
        public int SalvageValue { get; set; }
        public int UsefulLifeOfAssest { get; set; }
        public int PropertyValue { get; set; }
    }
}
