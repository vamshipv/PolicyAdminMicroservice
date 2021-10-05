using Moq;
using NUnit.Framework;
using PolicyMicroservice.Models;
using PolicyMicroservice.Repository;
using PolicyMicroservice.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolicyMicroserviceTests
{
    [TestFixture]
    public class PolicyTest
    {
        private Mock<IPolicyRepo> repoMock;
        private PolicyService policyService;
        private SampleRepo samplePolicyRepo;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IPolicyRepo>();
            samplePolicyRepo = new SampleRepo();
        }

        [TestCase(1, 2, 2, "Policy has been created with Policy Status 'Initiated'")]
        [TestCase(2, 2, 2, "Policy has been created with Policy Status 'Initiated'")]
        [TestCase(3, 2, 2, "No such property exists. Hence, Policy was not created")]
        [TestCase(2, 7, 7, "No such PolicyMaster exists. Hence, Policy was not created")]
        public void CreatePolicy(int propertyId, int bvalue, int pvalue, string expectedRes)
        {
            List<Property> properties = samplePolicyRepo.GetSampleProperties();
            List<PolicyMaster> policyMasters = samplePolicyRepo.GetSamplePolicyMasters();
            Property pro = properties.Find(p => p.PropertyId == propertyId);
            string policyStatus = "";
            if (pro == null)
            {
                policyStatus = "No such property exists. Hence, Policy was not created";
                repoMock.Setup(p => p.CreatePolicy(propertyId)).Returns(Task.FromResult(policyStatus));
            }
            else if (samplePolicyRepo.GetQuote(bvalue, pvalue) == null)
            {
                policyStatus = "No such Quote exists. Hence, Policy was not created";
                repoMock.Setup(p => p.CreatePolicy(propertyId)).Returns(Task.FromResult(policyStatus));
            }
            else if (!policyMasters.Exists(pm => pm.BusinesssValue == bvalue))
            {
                policyStatus = "No such PolicyMaster exists. Hence, Policy was not created";
                repoMock.Setup(p => p.CreatePolicy(propertyId)).Returns(Task.FromResult(policyStatus));
            }
            else
            {
                policyStatus = "Initiated";
                repoMock.Setup(p => p.CreatePolicy(propertyId)).Returns(Task.FromResult("Policy has been created with Policy Status \'" + policyStatus + "\'"));
            }

            policyService = new PolicyService(repoMock.Object);
            string actualRes = policyService.CreatePolicy(propertyId).Result.ToString();
            Assert.AreEqual(actualRes.ToString(), expectedRes);
        }

        [TestCase(1, "Paid", "Policy has been Issued for Policy ID 1")]
        [TestCase(2, "Paids", "No Payment was made. Hence, Policy was not Issued")]
        [TestCase(2, "Paid", "Policy has already been Issued")]
        [TestCase(3, "Paid", "No Policy exists with ID 3")]
        public void IssuePolicyTest(int PolicyId, string PaymentDetails, string expectedRes)
        {
            List<ConsumerPolicy> policies = samplePolicyRepo.GetSamplePolicies();
            if (PaymentDetails == "Paid")
            {
                if (policies.Exists(p => p.PolicyId == PolicyId))
                {
                    ConsumerPolicy policy = policies.Find(p => p.PolicyId == PolicyId);
                    if (policy.PolicyStatus == "Issued")
                    {
                        repoMock.Setup(r => r.IssuePolicy(PolicyId, PaymentDetails))
                            .Returns(Task.FromResult("Policy has already been Issued"));
                    }
                    else
                    {
                        repoMock.Setup(r => r.IssuePolicy(PolicyId, PaymentDetails))
                            .Returns(Task.FromResult("Policy has been Issued for Policy ID " + PolicyId));
                    }
                }
                else
                {
                    repoMock.Setup(r => r.IssuePolicy(PolicyId, PaymentDetails))
                        .Returns(Task.FromResult("No Policy exists with ID " + PolicyId));
                }
            }
            else
            {
                repoMock.Setup(r => r.IssuePolicy(PolicyId, PaymentDetails))
                        .Returns(Task.FromResult("No Payment was made. Hence, Policy was not Issued"));
            }

            policyService = new PolicyService(repoMock.Object);
            string actuaRes = policyService.IssuePolicy(PolicyId, PaymentDetails).Result.ToString();
            Assert.That(actuaRes, Is.EqualTo(expectedRes));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void ViewPolicyByIdTest(int PolicyId)
        {
            List<ConsumerPolicy> policies = samplePolicyRepo.GetSamplePolicies();
            dynamic expectedRes;
            if (policies.Exists(p => p.PolicyId == PolicyId))
            {
                repoMock.Setup(p => p.ViewPolicyById(PolicyId)).Returns(policies.Find(po => po.PolicyId == PolicyId));
                expectedRes = samplePolicyRepo.GetSamplePolicies().Find(po => po.PolicyId == PolicyId);
            }
            else
            {
                repoMock.Setup(p => p.ViewPolicyById(PolicyId)).Returns(null);
                expectedRes = null;
            }

            policyService = new PolicyService(repoMock.Object);
            dynamic actualRes = policyService.ViewPolicyById(PolicyId);
            if (actualRes == null || expectedRes == null)
            {
                Assert.AreEqual(actualRes, expectedRes);
            }
            else
            {
                Assert.True(actualRes != null);
                Assert.That(expectedRes.PolicyId, Is.EqualTo(actualRes.PolicyId));
                Assert.That(expectedRes.PropertyId, Is.EqualTo(actualRes.PropertyId));
                Assert.That(expectedRes.QuoteId, Is.EqualTo(actualRes.QuoteId));
                Assert.That(expectedRes.PolicyStatus, Is.EqualTo(actualRes.PolicyStatus));
                Assert.That(expectedRes.PolicyMasterId, Is.EqualTo(actualRes.PolicyMasterId));
            }
        }

        [TestCase(2, 2)]
        [TestCase(0, 9)]
        [TestCase(2, 4)]
        public void GetQuoteTest(int BusinessValue, int PropertyValue)
        {
            List<Quote> quotes = samplePolicyRepo.GetSampleQuotes();
            Quote qu = null;
            dynamic expectedRes = Task.FromResult(qu);

            if (BusinessValue >= 0 && BusinessValue <= 10 && PropertyValue >= 0 && PropertyValue <= 10)
            {
                foreach (Quote q in quotes)
                {
                    if (BusinessValue >= q.BusinesssValueFrom && BusinessValue <= q.BusinesssValueTo &&
                        PropertyValue >= q.PropertyValueFrom && PropertyValue <= q.PropertyValueTo)
                    {
                        repoMock.Setup(p => p.GetQuote(BusinessValue, PropertyValue)).Returns(Task.FromResult(q));
                        expectedRes = Task.FromResult(q);
                    }
                }
                if (expectedRes == Task.FromResult(qu))
                {
                    repoMock.Setup(p => p.GetQuote(BusinessValue, PropertyValue)).Returns(Task.FromResult(qu));
                    expectedRes = Task.FromResult(qu);
                }
            }
            else
            {
                repoMock.Setup(p => p.GetQuote(BusinessValue, PropertyValue)).Returns(Task.FromResult(qu));
                expectedRes = Task.FromResult(qu);
            }

            policyService = new PolicyService(repoMock.Object);
            dynamic actualRes = policyService.GetQuote(BusinessValue, PropertyValue);

            if (actualRes == Task.FromResult(qu) || expectedRes == Task.FromResult(qu) ||
                actualRes == Task.FromResult(qu) && expectedRes == Task.FromResult(qu))
            {
                Assert.That(actualRes, Is.EqualTo(expectedRes));
            }
            else
            {
                Assert.True(actualRes != null);
                Assert.True(expectedRes != null);
            }
        }

        [Test]
        public void ViewPropertiesTest()
        {
            repoMock.Setup(p => p.GetProperties()).Returns(samplePolicyRepo.GetSampleProperties());
            policyService = new PolicyService(repoMock.Object);

            var expectedRes = samplePolicyRepo.GetSampleProperties();
            var actualRes = policyService.GetProperties();

            Assert.True(actualRes != null);
            Assert.AreEqual(actualRes.Count, expectedRes.Count);
            for (int i = 0; i < expectedRes.Count; i++)
            {
                Assert.That(expectedRes[i].PropertyId, Is.EqualTo(actualRes[i].PropertyId));
                Assert.That(expectedRes[i].BuildingType, Is.EqualTo(actualRes[i].BuildingType));
                Assert.That(expectedRes[i].BuildingStoreys, Is.EqualTo(actualRes[i].BuildingStoreys));
                Assert.That(expectedRes[i].BuildingAge, Is.EqualTo(actualRes[i].BuildingAge));
                Assert.That(expectedRes[i].BusinessId, Is.EqualTo(actualRes[i].BusinessId));
                Assert.That(expectedRes[i].PropertyMasterId, Is.EqualTo(actualRes[i].PropertyMasterId));
            }
        }

        [Test]
        public void ViewPoliciesTest()
        {
            repoMock.Setup(p => p.GetPolicies()).Returns(samplePolicyRepo.GetSamplePolicies());
            policyService = new PolicyService(repoMock.Object);

            var expectedRes = samplePolicyRepo.GetSamplePolicies();
            var actualRes = policyService.GetPolicies();

            Assert.True(actualRes != null);
            Assert.AreEqual(actualRes.Count, expectedRes.Count);
            for (int i = 0; i < expectedRes.Count; i++)
            {
                Assert.That(expectedRes[i].PolicyId, Is.EqualTo(actualRes[i].PolicyId));
                Assert.That(expectedRes[i].PropertyId, Is.EqualTo(actualRes[i].PropertyId));
                Assert.That(expectedRes[i].QuoteId, Is.EqualTo(actualRes[i].QuoteId));
                Assert.That(expectedRes[i].PolicyStatus, Is.EqualTo(actualRes[i].PolicyStatus));
                Assert.That(expectedRes[i].PolicyMasterId, Is.EqualTo(actualRes[i].PolicyMasterId));
            }
        }
    }
}