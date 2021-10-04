using QuoteMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteMicroservice.Repository
{
    public class quoteRepository : IquoteRepository
    {
        private readonly InsureityPortalDBContext _dbContext;

        public quoteRepository(InsureityPortalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Quote> GetQuote()
        {
            return _dbContext.Quotes.ToList();
        }

        public Quote GetQuoteById(int QuoteId)
        {

            return _dbContext.Quotes.FirstOrDefault(x => x.QuoteId == QuoteId);
        }
    }
}
