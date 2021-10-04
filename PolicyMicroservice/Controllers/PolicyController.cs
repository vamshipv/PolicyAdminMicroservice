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
using PolicyMicroservice.Models;
using PolicyMicroservice.Service;

namespace PolicyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PolicyController));
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreatePolicy")]
        public async Task<string> CreatePolicy(int PropertyId)
        {
            _log4net.Info("CreatePolicy has been accessed");
            return await _policyService.CreatePolicy(PropertyId);
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("IssuePolicy")]
        public async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            _log4net.Info("IssuePolicy has been accessed");
            return await _policyService.IssuePolicy(PolicyId, PaymentDetails);
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("ViewConsumerPolicyById")]
        public dynamic ViewConsumerPolicyById(int PolicyId)
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var policy = _policyService.ViewPolicyById(PolicyId);
            return policy;
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetQuote")]
        public async Task<Quote> GetQuote(int BusinessValue, int PropertyValue)
        {
            _log4net.Info("GetQuote has been accessed");
            var quote = await _policyService.GetQuote(BusinessValue, PropertyValue);
            return quote;
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetPolicies")]
        public dynamic GetPolicies()
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var policies = _policyService.GetPolicies();
            return policies;
        }

        // [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetProperties")]
        public dynamic GetProperties()
        {
            _log4net.Info("ViewConsumerPolicyById has been accessed");
            var properties = _policyService.GetProperties();
            return properties;
        }
    }
}