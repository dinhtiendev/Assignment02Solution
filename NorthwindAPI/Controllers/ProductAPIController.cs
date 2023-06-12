using System;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models.DTOs;
using NorthwindAPI.Repository;

namespace NorthwindAPI.Controllers
{
    [Route("api/Products")]
    public class ProductAPIController : ControllerBase
	{
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductModelDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}

