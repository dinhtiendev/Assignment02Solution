using System;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public interface IEmployeeRepository
	{
        Task<IEnumerable<EmployeeDto>> GetEmployees();
    }
}

