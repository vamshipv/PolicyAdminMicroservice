using QuoteMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteMicroservice.servicelayer
{
    public interface Iquoteservice
    {
        public IEnumerable<Quote> GetQuote();
        public Quote GetQuoteById(int QuoteId);
    }
}
