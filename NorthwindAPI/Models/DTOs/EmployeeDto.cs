using System;
namespace NorthwindAPI.Models.DTOs
{
	public class EmployeeDto
	{
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
    }
}

