using System;
using NorthwindWeb.Models;

namespace NorthwindWeb.Services.IServices
{
	public interface IOrderService
	{
        Task<T> GetAllOrdersAsync<T>();
        Task<T> GetOrderByIdAsync<T>(int id);
        Task<T> GetAllOrdersByDateAsync<T>(DateTime orderDate);
        Task<T> CreateOrderAsync<T>(OrderDto orderDto);
        Task<T> UpdateOrderAsync<T>(OrderDto orderDto);
        Task<T> DeleteOrderAsync<T>(int id);
    }
}

