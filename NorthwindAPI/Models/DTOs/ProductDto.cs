using System;
namespace NorthwindAPI.Models.DTOs
{
	public class ProductDto
	{
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}

