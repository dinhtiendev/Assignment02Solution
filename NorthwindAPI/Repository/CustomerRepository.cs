using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
        private readonly NorthwindDbContext _db;
        private IMapper _mapper;

        public CustomerRepository(NorthwindDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            IEnumerable<Customer> CustomerList = await _db.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDto>>(CustomerList);
        }
    }
}

