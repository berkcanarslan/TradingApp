
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradingAppData.Datamodel;
using TradingAppData.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingAppEntity;
using AutoMapper;

namespace TradingApp.Controllers
{
    public class CustomerRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    [ApiController]
    [Route("trading/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger; 
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public CustomerController(ILogger<CustomerController> _logger, IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            logger = _logger;
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        [HttpGet]
        public List<CustomerEntity> Get()
        {
            var list = unitOfWork.CustomerRepository.GetAll().ToList();
            var result = mapper.Map<List<Customer>, List<CustomerEntity>>(list);
            return result;
        }


        [HttpGet]
        public CustomerEntity GetById(long id)
        {
            var customer = unitOfWork.CustomerRepository.GetById(id);
            var result = mapper.Map<Customer, CustomerEntity>(customer);
            return result;
        }



        [HttpPut]
        public ActionResult<CustomerEntity> Update([FromBody] CustomerEntity request)
        {
            if (request == null)
            {
                return NoContent();
            }

            var customer = unitOfWork.CustomerRepository.GetById(request.Id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;

            unitOfWork.CustomerRepository.Update(customer);
            unitOfWork.Save();

            var map = mapper.Map<Customer, CustomerEntity>(customer);
            return Ok(map);
        }


        [HttpPost]
        public ActionResult<CustomerEntity> Create([FromBody] CustomerEntity request)
        {
            if (request == null)
            {
                return NoContent();
            }
            Customer customer = mapper.Map<CustomerEntity, Customer>(request);

            customer.Password = Guid.NewGuid().ToString();
            customer.TradingToken = Guid.NewGuid().ToString();

            unitOfWork.CustomerRepository.Insert(customer);
            unitOfWork.Save();

            return Ok(request);
        }

    }
}