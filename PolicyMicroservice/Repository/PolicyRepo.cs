using Microsoft.EntityFrameworkCore;
using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyMicroservice.Repository
{
    public class PolicyRepo : IPolicyRepo
    {
        private readonly PolicyAdminDBContext context;

        public PolicyRepo(PolicyAdminDBContext policyDBContext)
        {
            context = policyDBContext;
        }

        public async Task<string> CreatePolicy(int PropertyId)//, int PolicyMasterId, int QuoteId)
        {
            string PolicyStatus;
            try
            {
                var property = context.Properties
                    .Include(b => b.Business)
                    .Include(b => b.Business.BusinessMaster)
                    .Include(b => b.PropertyMaster)
                    .SingleOrDefault(b => b.PropertyId == PropertyId);

                if (property == null)
                {
                    PolicyStatus = "Policy was not created";
                    return PolicyStatus;
                }

                var quote = GetQuote(property.Business.BusinessMaster.BusinessValue, property.PropertyMaster.PropertyValue);
                if (quote == null)
                {
                    PolicyStatus = "Policy was not created";
                    return PolicyStatus;
                }
                PolicyMaster pm = context.PolicyMasters
                    .Where(pm => pm.BusinesssValue == property.Business.BusinessMaster.BusinessValue)
                    .SingleOrDefault();
                if (pm == null)
                {
                    PolicyStatus = "Policy was not created";
                    return PolicyStatus;
                }
                PolicyStatus = "Initiated";

                ConsumerPolicy policy = new ConsumerPolicy
                {
                    PropertyId = PropertyId,
                    PolicyStatus = PolicyStatus,
                    QuoteId = quote.Result.Qid, // quote.Qid,
                    PolicyMasterid = pm.Pmid
                };

                context.ConsumerPolicies.Add(policy);
                await context.SaveChangesAsync();
                return "Policy has been created with Policy Status \'" + PolicyStatus + "\'";
            }
            catch
            {
                PolicyStatus = "Policy was not created";
                return PolicyStatus;
            }
        }

        public async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            try
            {
                if (PaymentDetails == "Paid")
                {
                    ConsumerPolicy policy = context.ConsumerPolicies.SingleOrDefault(p => p.PolicyId == PolicyId);
                    if (policy.PolicyStatus == "Issued")
                    {
                        return "Policy has already been Issued";
                    }
                    policy.PolicyStatus = "Issued";
                    await context.SaveChangesAsync();
                    return "Policy has been " + policy.PolicyStatus + " for Policy ID " + policy.PolicyId;
                }
                return "No Payment was made. Hence, Policy was not Issued";
            }
            catch
            {
                return "Policy was not Issued";
            }

        }

        public async Task<Quote> GetQuote(int BusinessValue, int PropertyValue)
        {
            List<Quote> quotes = context.Quotes.ToList();    // new List<Quote>();
            // If BusinessValue and PropertyValue in [0,10]
            if (BusinessValue >= 0 && BusinessValue <= 10 && PropertyValue >= 0 && PropertyValue <= 10)
            {
                foreach (Quote q in quotes)
                {
                    // 1 >= 0 && 1 <= 2 && 1 >= 0 && 1 <= 2
                    if (BusinessValue >= q.BusinesssValueFrom && BusinessValue <= q.BusinesssValueTo &&
                        PropertyValue >= q.PropertyValueFrom && PropertyValue <= q.PropertyValueTo)
                    {
                        return await context.Quotes.FindAsync(q.Qid);
                    }
                }
            }
            // No Quotes, Contact Insurance Provider
            return null;
        }


        public dynamic ViewPolicyById(int PolicyId)
        {
            try
            {
                var policy = context.ConsumerPolicies
                    .Include(c => c.Property).Include(c => c.PolicyMaster).Include(c => c.Quote)
                    .Where(cp => cp.PolicyId == PolicyId)
                    .Select(cp => new
                    {
                        PolicyId = cp.PolicyId,
                        BuildingType = cp.Property.BuildingType,
                        PolicyStatus = cp.PolicyStatus,
                        PropertyId = cp.PropertyId,
                        PropertyType = cp.PolicyMaster.PropertyType,
                        PropertyValue = cp.Property.PropertyMaster.PropertyValue,
                        BusinessValue = cp.Property.Business.BusinessMaster.BusinessValue,
                        QuoteValue = cp.Quote.QuoteValue,
                        ConsumerId = cp.Property.Business.ConsumerId,
                        ConsumerName = cp.Property.Business.Consumer.Name
                    }).FirstOrDefault();
                return policy;
            }
            catch
            {
                return "Policy was not found";
            }
        }

        public dynamic ListOfProperties()
        {
            try
            {
                var properties = context.Properties
                    .Include(p => p.Business).Include(p => p.PropertyMaster)
                    .Select(p => new
                    {
                        PropertyId = p.PropertyId,
                        BuildingType = p.BuildingType,
                        BuildingAge = p.BuildingAge,
                        BuildingStoreys = p.BuildingStoreys,
                        PropertyValue = p.PropertyMaster.PropertyValue,
                        BusinessId = p.BusinessId,
                        BusinessValue = p.Business.BusinessMaster.BusinessValue,
                        ConsumerId = p.Business.ConsumerId,
                        ConsumerName = p.Business.Consumer.Name
                    }).ToList();
                return properties;
            }
            catch
            {
                return "No Property was Found";
            }
        }

        public dynamic ListOfPolicies()
        {
            try
            {
                var policies = context.ConsumerPolicies
                    .Include(c => c.Property).Include(c => c.PolicyMaster).Include(c => c.Quote)
                    .Select(cp => new
                    {
                        PolicyId = cp.PolicyId,
                        BuildingType = cp.Property.BuildingType,
                        PolicyStatus = cp.PolicyStatus,
                        PropertyId = cp.PropertyId,
                        PropertyType = cp.PolicyMaster.PropertyType,
                        PropertyValue = cp.Property.PropertyMaster.PropertyValue,
                        BusinessValue = cp.Property.Business.BusinessMaster.BusinessValue,
                        QuoteValue = cp.Quote.QuoteValue,
                        ConsumerId = cp.Property.Business.ConsumerId,
                        ConsumerName = cp.Property.Business.Consumer.Name
                    }).ToList();
                return policies;
            }
            catch
            {
                return "No Policy was Found";
            }

        }
    }
}
