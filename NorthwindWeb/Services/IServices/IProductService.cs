using System;
namespace NorthwindWeb.Services.IServices
{
	public interface IProductService
	{
        Task<T> GetAllProductsAsync<T>();
    }
}

