using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
        private readonly NorthwindDbContext _db;
        private IMapper _mapper;

        public ProductRepository(NorthwindDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModelDto>> GetProducts()
        {
            IEnumerable<Product> ProductList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductModelDto>>(ProductList);
        }
    }
}

