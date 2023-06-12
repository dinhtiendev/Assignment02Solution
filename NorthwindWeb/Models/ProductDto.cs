using System;
namespace NorthwindWeb.Models
{
	public class ProductDto
	{
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}

