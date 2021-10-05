using System;
using System.Collections.Generic;

#nullable disable

namespace ConsumerMicroservice.Models
{
    public partial class BusinessMaster
    {
        public int BusinessMasterId { get; set; }
        public int BusinessValue { get; set; }
        public int BusinessTurnOver { get; set; }
        public int CapitalInvest { get; set; }

    }
}
