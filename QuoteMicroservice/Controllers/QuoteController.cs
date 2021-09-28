using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuoteMicroservice.Models;
using QuoteMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IquoteRepository _quoteRepository;

        public QuoteController(IquoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpGet("GetQuote")]
        public IEnumerable<Quote> GetConsumer()
        {
            return _quoteRepository.GetQuote();
        }
        [HttpGet("{Id:int}")]
        public ActionResult GetPropertyById(int Qid)
        {
            var obj = _quoteRepository.GetQuoteById(Qid);
            return Ok(obj);
        }
    }
}
