using System;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public interface ICustomerRepository
	{
        Task<IEnumerable<CustomerDto>> GetCustomers();
    }
}

