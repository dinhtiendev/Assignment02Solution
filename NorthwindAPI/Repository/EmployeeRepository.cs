using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
        private readonly NorthwindDbContext _db;
        private IMapper _mapper;

        public EmployeeRepository(NorthwindDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            IEnumerable<Employee> EmployeeList = await _db.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(EmployeeList);
        }
    }
}

