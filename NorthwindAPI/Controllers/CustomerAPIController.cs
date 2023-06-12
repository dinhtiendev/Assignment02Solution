using System;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models.DTOs;
using NorthwindAPI.Repository;

namespace NorthwindAPI.Controllers
{
    [Route("api/Customers")]
    public class CustomerAPIController : ControllerBase
	{
        protected ResponseDto _response;
        private ICustomerRepository _customerRepository;

        public CustomerAPIController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CustomerDto> customerDtos = await _customerRepository.GetCustomers();
                _response.Result = customerDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}

