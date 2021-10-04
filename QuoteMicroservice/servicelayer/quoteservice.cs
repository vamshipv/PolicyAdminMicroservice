using QuoteMicroservice.Models;
using QuoteMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteMicroservice.servicelayer
{
    public class quoteservice :Iquoteservice
    {
        private readonly IquoteRepository _quoteRepo;
        public quoteservice(IquoteRepository quoteRepository)
        {
            _quoteRepo = quoteRepository;
        }

        public IEnumerable<Quote> GetQuote()
        {
            return _quoteRepo.GetQuote();
        }

        public Quote GetQuoteById(int QuoteId){
            return _quoteRepo.GetQuoteById(QuoteId);
        }
    }
}
