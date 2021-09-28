using QuoteMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteMicroservice.Repository
{
    public interface IquoteRepository
    {
        IEnumerable<Quote> GetQuote();
        Quote GetQuoteById(int QId);
    }
}
