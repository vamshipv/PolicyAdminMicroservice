using QuoteMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteMicroservice.Repository
{
    public class quoteRepository : IquoteRepository
    {
        private readonly PolicyAdminDBContext _dbContext;

        public quoteRepository(PolicyAdminDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Quote> GetQuote()
        {
            return _dbContext.Quotes.ToList();
        }

        public Quote GetQuoteById(int Qid)
        {

            return _dbContext.Quotes.FirstOrDefault(x => x.Qid == Qid);
        }
    }
}
