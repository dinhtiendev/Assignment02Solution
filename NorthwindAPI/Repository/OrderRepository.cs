using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI.Repository
{
	public class OrderRepository : IOrderRepository
	{
        private readonly NorthwindDbContext _db;
        private IMapper _mapper;

        public OrderRepository(NorthwindDbContext db, IMapper mapper)
		{
            _db = db;
            _mapper = mapper;
		}

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            IEnumerable<Order> orderList = await _db.Orders.Include(x => x.OrderDetails).OrderByDescending(x => x.OrderId).ToListAsync();
            return _mapper.Map<List<OrderDto>>(orderList);
        }

        public async Task<OrderDto> GetOrderById(int OrderId)
        {
            Order order = await _db.Orders.Include(x => x.OrderDetails).Where(x => x.OrderId == OrderId).FirstOrDefaultAsync();
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByDate(DateTime orderDate)
        {
            IEnumerable<Order> orderList = await _db.Orders.Include(x => x.OrderDetails).OrderByDescending(x => x.OrderId).Where(x => x.OrderDate == orderDate).ToListAsync();
            return _mapper.Map<List<OrderDto>>(orderList);
        }

        public async Task<OrderDto> CreateUpdateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            Order oldOrder = await _db.Orders.Include(x => x.OrderDetails).Where(x => x.OrderId == order.OrderId).FirstOrDefaultAsync();
            if (oldOrder != null)
            {
                _db.Entry(oldOrder).State = EntityState.Detached;
                _db.OrderDetails.RemoveRange(oldOrder.OrderDetails);
                foreach (var orderDetail in order.OrderDetails)
                {
                    _db.OrderDetails.Add(orderDetail);
                }
                _db.Orders.Update(order);
            }
            else
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    _db.OrderDetails.Add(orderDetail);
                }
                _db.Orders.Add(order);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            try
            {
                Order order = await _db.Orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.OrderId == orderId);
                if (order == null)
                {
                    return false;
                }
                foreach (var orderDetail in order.OrderDetails)
                {
                    _db.OrderDetails.Remove(orderDetail);
                }
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

