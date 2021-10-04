using System;
using System.Collections.Generic;

#nullable disable

namespace QuoteMicroservice.Models
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public int PropertyValueFrom { get; set; }
        public int PropertyValueTo { get; set; }
        public int BusinesssValueFrom { get; set; }
        public int BusinesssValueTo { get; set; }
        public string PropertyType { get; set; }
        public decimal QuoteValue { get; set; }
    }
}
