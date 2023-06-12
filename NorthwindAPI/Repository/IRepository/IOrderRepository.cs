using System;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public interface IOrderRepository
	{
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderId);
        Task<IEnumerable<OrderDto>> GetOrdersByDate(DateTime orderDate);
        Task<OrderDto> CreateUpdateOrder(OrderDto orderDto);
        Task<bool> DeleteOrder(int orderId);
    }
}

