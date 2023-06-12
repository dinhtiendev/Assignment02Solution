using System;
namespace NorthwindWeb.Models
{
	public class OrderDto
	{
        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<ProductDto> ListOfProduct { get; set; }
    }
}

