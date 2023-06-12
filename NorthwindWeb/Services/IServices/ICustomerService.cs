using System;
namespace NorthwindWeb.Services.IServices
{
	public interface ICustomerService
	{
        Task<T> GetAllCustomersAsync<T>();
    }
}

