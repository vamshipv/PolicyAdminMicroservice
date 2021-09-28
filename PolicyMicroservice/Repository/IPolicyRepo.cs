using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public interface IPolicyRepo
    {
        public Task<string> CreatePolicy(int PropertyId); //, int PolicyMasterId, int QuoteId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);

        public dynamic ListOfProperties();

        public dynamic ListOfPolicies();

        public dynamic ViewPolicyById(int PolicyId);

        public Task<Quote> GetQuote(int BusinessValue, int PropertyValue);
    }
}
