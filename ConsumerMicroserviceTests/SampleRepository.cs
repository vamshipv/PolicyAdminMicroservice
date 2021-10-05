using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMicroserviceTests
{
    public class SampleRepository
    {
        public List<Consumer> ConsumerData()
        {
            List<Consumer> consumers = new List<Consumer>()
            {
                new Consumer
                {
                ConsumerId = 1,
                ConsumerName = "Test Name",
                DateOfBirth = Convert.ToDateTime("01 oct 2021"),
                Email = "Test@gmail.com",
                PanNumber = "ADIJD#IHJD",
                AgentId = 1
                }
            };
            return consumers;
        }

        public List<Business> BusinessData()
        {
            List<Business> businesses = new List<Business>()
            {
                new Business
                {
                    BusinessId = 1,
                    BusinessName = "Test Business",
                    BusinessType = "Test Factory",
                    TotalEmployees =  1,
                    BusinessMasterId = 1,
                    ConsumerId = 1,
                    BusinessMaster = new BusinessMaster()
                    {
                        BusinessMasterId  = 1,
                        BusinessValue = 1,
                        BusinessTurnOver = 1,
                        CapitalInvest = 1
                    }
                }
            };
            return businesses;
        }

        public List<Property> PropertyData()
        {
            List<Property> properties = new List<Property>
            {
                new Property
                {
                    PropertyId = 1,
                    BuildingType = "Test Factory",
                    BuildingStoreys = 1,
                    BuildingAge = 1,
                    BusinessId = 1,
                    PropertyMasterId = 1,
                    PropertyMaster = new PropertyMaster()
                    {
                        PropertyMasterId = 1,
                        CostOfAssest = 1,
                        SalvageValue = 1,
                        UsefulLifeOfAssest = 1,
                        PropertyValue = 1
                    }
                }
            };
            return properties;
        }
    }
}
