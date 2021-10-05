using PolicyMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyMicroserviceTests
{
    public class SampleRepo
    {
        public List<Property> GetSampleProperties()
        {
            List<Property> properties = new List<Property>
            {
                new Property
                {
                    PropertyId = 1,
                    BuildingType = "Office",
                    BuildingStoreys = 10,
                    BuildingAge = 10,
                    BusinessId = 1,
                    PropertyMasterId = 1
                },
                new Property
                {
                    PropertyId = 2,
                    BuildingType = "Factory",
                    BuildingStoreys = 5,
                    BuildingAge = 11,
                    BusinessId = 2,
                    PropertyMasterId = 2
                }
            };
            return properties;
        }

        public List<ConsumerPolicy> GetSamplePolicies()
        {
            List<ConsumerPolicy> policies = new List<ConsumerPolicy>
            {
                new ConsumerPolicy
                {
                    PolicyId = 1,
                    PropertyId = 1,
                    QuoteId = 1,
                    PolicyStatus = "Initiated",
                    PolicyMasterId = 1
                },
                new ConsumerPolicy
                {
                    PolicyId = 2,
                    PropertyId = 1,
                    QuoteId = 1,
                    PolicyStatus = "Issued",
                    PolicyMasterId = 1
                }
            };
            return policies;
        }


        public List<Quote> GetSampleQuotes()
        {
            List<Quote> quotes = new List<Quote>
            {
                new Quote
                {
                    QuoteId = 1,
                    PropertyValueFrom = 0,
                    PropertyValueTo = 2,
                    BusinesssValueFrom = 0,
                    BusinesssValueTo = 2,
                    PropertyType = "Office",
                    QuoteValue = 1000
                },
                new Quote
                {
                    QuoteId = 2,
                    PropertyValueFrom = 3,
                    PropertyValueTo = 5,
                    BusinesssValueFrom = 3,
                    BusinesssValueTo = 5,
                    PropertyType = "Office",
                    QuoteValue = 102010
                }
            };
            return quotes;
        }

        public List<PolicyMaster> GetSamplePolicyMasters()
        {
            List<PolicyMaster> policyMasters = new List<PolicyMaster>
            {
                new PolicyMaster
                {
                    PolicyMasterId = 1,
                    PropertyType = "Building",
                    PropertyValue = 2,
                    ConsumerType = "regular",
                    AssuredSum = 10000,
                    Tenure = 102910,
                    BusinesssValue = 2,
                    BaseLocation = "Kolkata",
                    PolicyType = "sample"
                },
                new PolicyMaster
                {
                    PolicyMasterId = 2,
                    PropertyType = "Building",
                    PropertyValue = 2,
                    ConsumerType = "regular",
                    AssuredSum = 10000,
                    Tenure = 102910,
                    BusinesssValue = 2,
                    BaseLocation = "Kolkata",
                    PolicyType = "sample"
                }
            };
            return policyMasters;
        }

        public async Task<Quote> GetQuote(int BusinessValue, int PropertyValue)
        {
            List<Quote> quotes = GetSampleQuotes();
            if (BusinessValue >= 0 && BusinessValue <= 10 && PropertyValue >= 0 && PropertyValue <= 10)
            {
                foreach (Quote q in quotes)
                {
                    if (BusinessValue >= q.BusinesssValueFrom && BusinessValue <= q.BusinesssValueTo &&
                        PropertyValue >= q.PropertyValueFrom && PropertyValue <= q.PropertyValueTo)
                    {
                        return q;
                    }
                }
            }
            return null;
        }
    }
}
