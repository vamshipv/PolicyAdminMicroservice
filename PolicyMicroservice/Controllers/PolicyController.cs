using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using PolicyMicroservice.Repository;
using Microsoft.Extensions.Logging;

namespace Policy_Microservice.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        private readonly IPolicyRepo _policyRepo;

        public PolicyController(IPolicyRepo policyRepo)
        {
            _policyRepo = policyRepo;
        }

        [HttpPost("CreatePolicy")]
        public async Task<string> CreatePolicy(int PropertyId)//int BusinessId, int PolicyMasterId, int QuoteId)
        {
            _log4net.Info("CreatePolicy has been accessed");
            // string policyStatus = ;
            return await _policyRepo.CreatePolicy(PropertyId);  //, PolicyMasterId, QuoteId);
            // return policyStatus;
        }

        [HttpPut("IssuePolicy")]
        public async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            _log4net.Info("IssuePolicy has been accessed");
            // string policyStatus = ;
            return await _policyRepo.IssuePolicy(PolicyId, PaymentDetails);
            // return policyStatus;
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("ViewConsumerPolicyById")]
        public dynamic ViewConsumerPolicyById(int PolicyId)  //async Task<ActionResult<
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var policy = _policyRepo.ViewPolicyById(PolicyId);
            return policy;
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetQuote")]
        public async Task<dynamic> GetQuote(int BusinessValue, int PropertyValue)
        {
            _log4net.Info("GetQuote has been accessed");
            var quote = await _policyRepo.GetQuote(BusinessValue, PropertyValue);
            if (quote == null)
            {
                return "Quote Not Found";
            }
            return quote;
        }

        [HttpGet("ViewPolicies")]
        public dynamic ViewPolicies()  //async Task<ActionResult<
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var policies = _policyRepo.ListOfPolicies();
            return policies;
        }

        [HttpGet("ViewProperties")]
        public dynamic ViewProperties()  //async Task<ActionResult<
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var properties = _policyRepo.ListOfProperties();
            return properties;
        }
    }
}