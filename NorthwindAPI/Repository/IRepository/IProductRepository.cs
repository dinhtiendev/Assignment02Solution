using System;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public interface IProductRepository
	{
        Task<IEnumerable<ProductModelDto>> GetProducts();
    }
}

