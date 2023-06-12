using System;
using NorthwindWeb.Models;
using NorthwindWeb.Services.IServices;

namespace NorthwindWeb.Services
{
	public class OrderService : BaseService, IOrderService
	{
        private readonly IHttpClientFactory _clientFactory;

        public OrderService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateOrderAsync<T>(OrderDto orderDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderDto,
                Url = SD.OrderAPIBase + "/api/Orders",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteOrderAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.OrderAPIBase + "/api/Orders/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllOrdersAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/Orders",
                AccessToken = ""
            });
        }

        public async Task<T> GetAllOrdersByDateAsync<T>(DateTime orderDate)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/Orders/date/" + orderDate.ToString("yyyy-MM-dd") + "T00%3A00%3A00",
                AccessToken = ""
            });
        }

        public async Task<T> GetOrderByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/Orders/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateOrderAsync<T>(OrderDto orderDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = orderDto,
                Url = SD.OrderAPIBase + "/api/Orders",
                AccessToken = ""
            });
        }
    }
}

