using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuoteMicroservice.Models;
using QuoteMicroservice.Repository;
using QuoteMicroservice.servicelayer;
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
        private readonly Iquoteservice _quoteservice;

        public QuoteController(Iquoteservice quoteservice)
        {
            _quoteservice = quoteservice;
        }

        [HttpGet("GetQuote")]
        public IEnumerable<Quote> GetQuote()
        {
            return _quoteservice.GetQuote();
        }

        [HttpGet("GetQuoteById")]
        public ActionResult GetQuoteById(int QuoteId)
        {
            var obj = _quoteservice.GetQuoteById(QuoteId);
            return Ok(obj);
        }
    }
}
