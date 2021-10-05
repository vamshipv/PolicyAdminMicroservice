using ConsumerMicroservice.Models;
using ConsumerMicroservice.RepositoryLayer.IRepositoryLayer;
using ConsumerMicroservice.ServiceLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConsumerMicroserviceTests
{
    public class Tests
    {
        private Mock<IConsumerRepository> consumerMock;
        private Mock<IConsumerBusinessRepository> cosumerBusinessMock;
        private Mock<IBusinessPropertyRepository> businessPropertyMock;
        private ConsumerService consumerService;
        private SampleRepository sampleRepository;

        [SetUp]
        public void Setup()
        {
            consumerMock = new Mock<IConsumerRepository>();
            cosumerBusinessMock = new Mock<IConsumerBusinessRepository>();
            businessPropertyMock = new Mock<IBusinessPropertyRepository>();
            sampleRepository = new SampleRepository();
        }

        [TestCase(1, "Test Name", "01 oct 2021", "Test@gmail.com", "ADIJD#IHJD", 1, "Test", true)]
        [TestCase(4, "Test Name", "01 oct 2021", "Test@gmail.com", "ADIJD#IHJD", 1, "Test", false)]
        public void CreateConsumerTest(int ConsumerId, string ConsumerName, DateTime DateOfBirth, string Email, string PanNumber,
            int AgentId, string AgentName, bool expectedResult)
        {
            Consumer consumer = new Consumer()
            {
                ConsumerId = ConsumerId,
                ConsumerName = ConsumerName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                PanNumber = PanNumber,
                AgentId = AgentId
            };
            List<Consumer> consumers = sampleRepository.ConsumerData();

            if (consumers.Exists(c => c.ConsumerId == consumer.ConsumerId))
            {
                consumerMock.Setup(c => c.CreateConsumer(consumer)).Returns(true);
            }
            else
            {
                consumerMock.Setup(c => c.CreateConsumer(consumer)).Returns(false);
            }
            consumerService = new ConsumerService(consumerMock.Object, cosumerBusinessMock.Object, businessPropertyMock.Object);
            Assert.AreEqual(expectedResult, consumerService.CreateConsumer(consumer));
        }

        [TestCase(1, "Test Factory", 4, 5, 1, 1, 1, 1, 1, 1, true)]
        [TestCase(2, "Test Factory", 4, 5, 1, 1, 1, 1, 1, 1, false)]
        public void CreatePropertyTest(int PropertyId, string BuildingType, int BuildingStoreys, int BuildingAge, int BusinessId, int PropertyMasterId,
            int CostOfAssest, int SalvageValue, int UsefulLifeOfAssest, int PropertyValue, bool expectedResult)
        {
            Property property = new Property()
            {
                PropertyId = PropertyId,
                BuildingType = BuildingType,
                BuildingStoreys = BuildingStoreys,
                BuildingAge = BuildingAge,
                BusinessId = BusinessId,
                PropertyMasterId = PropertyMasterId,
                PropertyMaster = new PropertyMaster()
                {
                    PropertyMasterId = PropertyMasterId,
                    CostOfAssest = CostOfAssest,
                    SalvageValue = SalvageValue,
                    UsefulLifeOfAssest = UsefulLifeOfAssest,
                    PropertyValue = PropertyValue
                }
            };
            List<Property> properties = sampleRepository.PropertyData();

            if (properties.Exists(c => c.PropertyId == property.PropertyId))
            {
                businessPropertyMock.Setup(c => c.CreateProperty(property)).Returns(true);
            }
            else
            {
                businessPropertyMock.Setup(c => c.CreateProperty(property)).Returns(false);
            }

            consumerService = new ConsumerService(consumerMock.Object, cosumerBusinessMock.Object, businessPropertyMock.Object);
            Assert.AreEqual(expectedResult, consumerService.CreateProperty(property));
        }

        [TestCase(1, "Test Business", "Test Factory", 1, 1, 1, 1, 1, 1, true)]
        [TestCase(2, "Test Business", "Test Factory", 1, 1, 1, 1, 1, 1, false)]
        public void CreateBusinessTest(int BusinessId, string BusinessName, string BusinessType, int TotalEmployees,
            int BusinessMasterId, int ConsumerId, int BusinessValue, int BusinessTurnOver, int CapitalInvest, bool expectedResult)
        {
            Business business = new Business()
            {
                BusinessId = BusinessId,
                BusinessName = BusinessName,
                BusinessType = BusinessType,
                TotalEmployees = TotalEmployees,
                BusinessMasterId = BusinessMasterId,
                ConsumerId = ConsumerId,
                BusinessMaster = new BusinessMaster()
                {
                    BusinessMasterId = BusinessMasterId,
                    BusinessValue = BusinessValue,
                    BusinessTurnOver = BusinessTurnOver,
                    CapitalInvest = CapitalInvest
                }
            };

            List<Business> businesses = sampleRepository.BusinessData();

            if (businesses.Exists(b => b.BusinessId == business.BusinessId))
            {
                cosumerBusinessMock.Setup(b => b.CreateBusiness(business)).Returns(true);
            }
            else
            {
                cosumerBusinessMock.Setup(b => b.CreateBusiness(business)).Returns(false);
            }

            consumerService = new ConsumerService(consumerMock.Object, cosumerBusinessMock.Object, businessPropertyMock.Object);
            Assert.AreEqual(expectedResult, consumerService.CreateBusiness(business));
        }

        [TestCase(1, "Test Name", "01 oct 2021", "Test@gmail.com", "ADIJD#IHJD", 1, "Test", true)]
        [TestCase(2, "Test Name", "01 oct 2021", "Test@gmail.com", "ADIJD#IHJD", 1, "Test", false)]
        public void UpdateConsumerTest(int ConsumerId, string ConsumerName, DateTime DateOfBirth, string Email, string PanNumber, int AgentId, string AgentName, bool expectedResult)
        {
            Consumer consumer = new Consumer()
            {
                ConsumerId = ConsumerId,
                ConsumerName = ConsumerName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                PanNumber = PanNumber,
                AgentId = AgentId
            };
            List<Consumer> consumers = sampleRepository.ConsumerData();

            if (consumers.Exists(c => c.ConsumerId == consumer.ConsumerId))
            {
                consumerMock.Setup(c => c.UpdateConsumer(consumer.ConsumerId, consumer)).Returns(true);
            }
            else
            {
                consumerMock.Setup(c => c.UpdateConsumer(consumer.ConsumerId, consumer)).Returns(false);
            }
            consumerService = new ConsumerService(consumerMock.Object, cosumerBusinessMock.Object, businessPropertyMock.Object);
            Assert.AreEqual(expectedResult, consumerService.UpdateConsumer(consumer.ConsumerId, consumer));
        }

        [TestCase(1, "Test Business", "Test Factory", 1, 1, 1, 1, 1, 1, true)]
        [TestCase(2, "Test Business", "Test Factory", 1, 1, 1, 1, 1, 1, false)]
        public void UpdateBusinessTest(int BusinessId, string BusinessName, string BusinessType, int TotalEmployees,
            int BusinessMasterId, int ConsumerId, int BusinessValue, int BusinessTurnOver, int CapitalInvest, bool expectedResult)
        {
            Business business = new Business()
            {
                BusinessId = BusinessId,
                BusinessName = BusinessName,
                BusinessType = BusinessType,
                TotalEmployees = TotalEmployees,
                BusinessMasterId = BusinessMasterId,
                ConsumerId = ConsumerId,
                BusinessMaster = new BusinessMaster()
                {
                    BusinessMasterId = BusinessMasterId,
                    BusinessValue = BusinessValue,
                    BusinessTurnOver = BusinessTurnOver,
                    CapitalInvest = CapitalInvest
                }
            };

            List<Business> businesses = sampleRepository.BusinessData();

            if (businesses.Exists(b => b.BusinessId == business.BusinessId))
            {
                cosumerBusinessMock.Setup(b => b.UpdateBusiness(business.BusinessId, business)).Returns(true);
            }
            else
            {
                cosumerBusinessMock.Setup(b => b.UpdateBusiness(business.BusinessId, business)).Returns(false);
            }

            consumerService = new ConsumerService(consumerMock.Object, cosumerBusinessMock.Object, businessPropertyMock.Object);
            Assert.AreEqual(expectedResult, consumerService.UpdateBusiness(business.BusinessId, business));
        }

        [TestCase(1, "Test Factory", 4, 5, 1, 1, 1, 1, 1, 1, true)]
        [TestCase(2, "Test Factory", 4, 5, 1, 1, 1, 1, 1, 1, false)]
        public void UpdatePropertyTest(int PropertyId, string BuildingType, int BuildingStoreys, int BuildingAge, int BusinessId, int PropertyMasterId,
            int CostOfAssest, int SalvageValue, int UsefulLifeOfAssest, int PropertyValue, bool expectedResult)
        {
            Property property = new Property()
            {
                PropertyId = PropertyId,
                BuildingType = BuildingType,
                BuildingStoreys = BuildingStoreys,
                BuildingAge = BuildingAge,
                BusinessId = BusinessId,
                PropertyMasterId = PropertyMasterId,
                PropertyMaster = new PropertyMaster()
                {
                    PropertyMasterId = PropertyMasterId,
                    CostOfAssest = CostOfAssest,
                    SalvageValue = SalvageValue,
                    UsefulLifeOfAssest = UsefulLifeOfAssest,
                    PropertyValue = PropertyValue
                }
            };
            List<Property> properties = sampleRepository.PropertyData();

            if (properties.Exists(c => c.PropertyId == property.PropertyId))
            {
                businessPropertyMock.Setup(c => c.UpdateProperty(property.PropertyId, property)).Returns(true);
            }
            else
            {
                businessPropertyMock.Setup(c => c.UpdateProperty(property.PropertyId, property)).Returns(false);
            }

            consumerService = new ConsumerService(consumerMock.Object, cosumerBusinessMock.Object, businessPropertyMock.Object);
            Assert.AreEqual(expectedResult, consumerService.UpdateProperty(property.PropertyId, property));
        }

        [Test]
        public void GetConsumerByIdTest()
        {
            var consumerId = 1;
            Consumer consumer = new Consumer() { ConsumerId = consumerId };
            consumerMock.Setup(c => c.GetConsumer(consumerId)).Returns(consumer);
            var output = consumerMock.Object.GetConsumer(consumerId);
            Assert.AreEqual(output.ConsumerId, consumerId);
        }

        [Test]
        public void GetBusinessByIdTest()
        {
            var businessId = 1;
            Business business = new Business() { BusinessId = businessId };
            cosumerBusinessMock.Setup(c => c.GetBusinesss(businessId)).Returns(business);
            var output = cosumerBusinessMock.Object.GetBusinesss(businessId);
            Assert.AreEqual(output.BusinessId, businessId);
        }

        [Test]
        public void GetPropertyByIdTest()
        {
            var propertyId = 1;
            Property property = new Property() { PropertyId = propertyId };
            businessPropertyMock.Setup(c => c.GetProperties(propertyId)).Returns(property);
            var output = businessPropertyMock.Object.GetProperties(propertyId);
            Assert.AreEqual(output.PropertyId, propertyId);
        }

        [Test]
        public void GetConsumerTest()
        {
            IEnumerable<Consumer> consumer = new List<Consumer>() { };
            consumerMock.Setup(c => c.GetConsumers()).Returns(consumer);
            var output = consumerMock.Object.GetConsumers();
            Assert.AreEqual(output, consumer);
        }

        [Test]
        public void GetBusinessTest()
        {
            IEnumerable<Business> business = new List<Business>() { };
            cosumerBusinessMock.Setup(c => c.GetBusiness()).Returns(business);
            var output = cosumerBusinessMock.Object.GetBusiness();
            Assert.AreEqual(output, business);
        }

        [Test]
        public void GetPropertyTest()
        {
            IEnumerable<Property> property = new List<Property>() { };
            businessPropertyMock.Setup(c => c.GetProperty()).Returns(property);
            var output = businessPropertyMock.Object.GetProperty();
            Assert.AreEqual(output, property);
        }

        [Test]
        public void DeleteConsumerByIdTest()
        {
            var consumerId = 1;
            Consumer consumer = new Consumer() { ConsumerId = consumerId };
            consumerMock.Setup(c => c.DeleteConsumer(consumerId)).Returns(true);
            var output = consumerMock.Object.DeleteConsumer(consumerId);
            Assert.AreEqual(true, output);
        }

        [Test]
        public void DeleteBusinessByIdTest()
        {
            var businessId = 1;
            Business business = new Business() { BusinessId = businessId };
            cosumerBusinessMock.Setup(c => c.DeleteBusiness(businessId)).Returns(true);
            var output = cosumerBusinessMock.Object.DeleteBusiness(businessId);
            Assert.AreEqual(true, output);
        }

        [Test]
        public void DeletePropertyByIdTest()
        {
            var propertyId = 1;
            Property property = new Property() { PropertyId = propertyId };
            businessPropertyMock.Setup(c => c.DeleteProperty(propertyId)).Returns(true);
            var output = businessPropertyMock.Object.DeleteProperty(propertyId);
            Assert.AreEqual(true, output);
        }

        [Test]
        public void CheckForConsumerIdExistsTest()
        {
            var consumerId = 1;
            Consumer consumer = new Consumer() { ConsumerId = consumerId };
            consumerMock.Setup(c => c.ConsumerExists(consumerId)).Returns(false);
            var output = consumerMock.Object.ConsumerExists(consumerId);
            Assert.AreEqual(false, output);
        }

        [Test]
        public void CheckForBusinessIdExistsTest()
        {
            var businessId = 1;
            Business business = new Business() { BusinessId = businessId };
            cosumerBusinessMock.Setup(c => c.BusinessExists(businessId)).Returns(false);
            var output = cosumerBusinessMock.Object.BusinessExists(businessId);
            Assert.AreEqual(false, output);
        }

        [Test]
        public void CheckForPropertyIdExistsTest()
        {
            var propertyId = 1;
            Property property = new Property() { PropertyId = propertyId };
            businessPropertyMock.Setup(c => c.PropertyExists(propertyId)).Returns(false);
            var output = businessPropertyMock.Object.PropertyExists(propertyId);
            Assert.AreEqual(false, output);
        }
    }
}