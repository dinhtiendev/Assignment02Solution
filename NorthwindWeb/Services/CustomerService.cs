using System;
using NorthwindWeb.Models;
using NorthwindWeb.Services.IServices;

namespace NorthwindWeb.Services
{
	public class CustomerService : BaseService, ICustomerService
	{
        private readonly IHttpClientFactory _clientFactory;

        public CustomerService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllCustomersAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/Customers",
                AccessToken = ""
            });
        }
    }
}

