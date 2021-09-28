using ConsumerMicroservice.Models;
using ConsumerMicroservice.RepositoryLayer.IRepositoryLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerRepository _consumerRepository;
        //static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(ConsumerController));
        private readonly ILogger<Consumer> _log;

        public ConsumerController(ILogger<Consumer> log, IConsumerRepository consumerRepository)
        {
            _log = log;
            _consumerRepository = consumerRepository;
        }

        // Add logs here
        [HttpGet("GetConsumer")]
        public IEnumerable<Consumer> GetConsumer()
        {
            return _consumerRepository.GetConsumers();
        }

        [HttpGet("GetBusiness")]
        public IEnumerable<Business> GetBusiness()
        {
            return _consumerRepository.GetBusiness();
        }

        [HttpGet("GetProperty")]
        public IEnumerable<Property> GetProperty()
        {
            return _consumerRepository.GetProperty();
        }

        [HttpGet("{ConsumerId:int}")]
        public ActionResult GetConsumerById(int ConsumerId)
        {
            var obj = _consumerRepository.GetConsumer(ConsumerId);
            return Ok(obj);
        }

        [HttpGet("{BusinessId:int}")]
        public ActionResult GetBusinessById(int BusinessId)
        {
            var obj = _consumerRepository.GetBusinesss(BusinessId);
            return Ok(obj);
        }

        [HttpGet("{PropertyId:int}")]
        public ActionResult GetPropertyById(int PropertyId)
        {
            var obj = _consumerRepository.GetProperties(PropertyId);
            return Ok(obj);
        }

        [HttpPost("CreateConsumer")]
        //[EnableCors("AllowAllOrigins")]
        [ProducesResponseType(201, Type = typeof(Consumer))]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateConsumer([FromBody] Consumer consumer)
        {
            try
            {
                _log.LogInformation("Controller ready for creating new record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                if (!_consumerRepository.CreateConsumer(consumer) && !_consumerRepository.ConsumerExists(consumer.ConsumerId))
                {
                    return new ObjectResult("Database insertion Error") { StatusCode = 500 };
                }
                return new CreatedResult("GetConsumer", new { id = consumer.ConsumerId });
            }
            catch (Exception e)
            {
                _log.LogError("Error Creating the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpPost("CreateBusiness")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateBusiness(Business business)
        {
            try
            {
                _log.LogInformation("Controller ready for creating new record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                if (_consumerRepository.CreateBusiness(business))
                {
                    return new CreatedResult("GetBusiness", new { id = business.BusinessId });
                }
                return new ObjectResult("Database Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error Creating" + e.Message);
                return new ObjectResult("Database Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpPost("CreateProperty")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateProperty(Property property)
        {
            try
            {
                _log.LogInformation("Controller ready for creating new record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                if (_consumerRepository.CreateProperty(property))
                {
                    return new CreatedResult("GetProperty", new { id = property.PropertyId });
                }
                return new ObjectResult("Database Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error Creating" + e.Message);
                return new ObjectResult("Database Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpPut("UpdateConsumer")]
        public ActionResult UpdateConsumer(int ConsumerId, [FromBody] Consumer consumer)
        {
            try
            {
                _log.LogInformation("Controller ready for updating new record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                var updateResult = _consumerRepository.UpdateConsumer(ConsumerId, consumer);

                if (updateResult)
                {
                    return new CreatedResult("GetConsumerById", new { id = consumer.ConsumerId });
                }
                return new ObjectResult("Database insertion Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error updating the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpPut("UpdateBusiness")]
        public ActionResult UpdateBusiness(int BusinessId, [FromBody] Business business)
        {
            try
            {
                _log.LogInformation("Controller ready for updating new record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                var updateResult = _consumerRepository.UpdateBusiness(BusinessId, business);

                if (updateResult)
                {
                    return new CreatedResult("GetBusinessById", new { id = business.BusinessId });
                }
                return new ObjectResult("Database insertion Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error updating the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpPut("UpdateProperty")]
        public ActionResult UpdateProperty(int PropertyId, [FromBody] Property property)
        {
            try
            {
                _log.LogInformation("Controller ready for updating new record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                var updateResult = _consumerRepository.UpdateProperty(PropertyId, property);

                if (updateResult)
                {
                    return new CreatedResult("GetPropertyById", new { id = property.PropertyId });
                }
                return new ObjectResult("Database insertion Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error updating the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpDelete("DeleteConsumer")]
        public ActionResult DeleteConsumer(int ConsumerId)
        {
            try
            {
                _log.LogInformation("Controller ready for deleting record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                var deleteResult = _consumerRepository.DeleteConsumer(ConsumerId);

                if (deleteResult)
                {
                    return new CreatedResult("GetConsumerById", new { id = ConsumerId });
                }
                return new ObjectResult("Database deletion Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error deleting the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpDelete("DeleteBusiness")]
        public ActionResult DeleteBusiness(int BusinessId)
        {
            try
            {
                _log.LogInformation("Controller ready for deleting record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                var deleteResult = _consumerRepository.DeleteBusiness(BusinessId);

                if (deleteResult)
                {
                    return new CreatedResult("GetBusinessById", new { id = BusinessId });
                }
                return new ObjectResult("Database deletion Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogInformation("Error deleting the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }

        [HttpDelete("DeleteProperty")]
        public ActionResult DeleteProperty(int PropertyId)
        {
            try
            {
                _log.LogInformation("Controller ready for deleting record");
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }

                var deleteResult = _consumerRepository.DeleteProperty(PropertyId);

                if (deleteResult)
                {
                    return new CreatedResult("GetPropertyById", new { id = PropertyId });
                }
                return new ObjectResult("Database deletion Error") { StatusCode = 500 };
            }
            catch (Exception e)
            {
                _log.LogError("Error deleting the data" + e.Message);
                return new ObjectResult("DataBase Error, Check for Id") { StatusCode = 500 };
            }
        }
    }
}
