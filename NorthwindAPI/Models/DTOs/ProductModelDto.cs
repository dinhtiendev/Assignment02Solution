using System;
namespace NorthwindAPI.Models.DTOs
{
	public class ProductModelDto
	{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
    }
}

