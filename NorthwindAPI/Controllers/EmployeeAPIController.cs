using System;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models.DTOs;
using NorthwindAPI.Repository;

namespace NorthwindAPI.Controllers
{
    [Route("api/Employees")]
    public class EmployeeAPIController : ControllerBase
	{
        protected ResponseDto _response;
        private IEmployeeRepository _employeeRepository;

        public EmployeeAPIController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<EmployeeDto> employeeDtos = await _employeeRepository.GetEmployees();
                _response.Result = employeeDtos;
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

