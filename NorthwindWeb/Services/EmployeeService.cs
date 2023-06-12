using System;
using NorthwindWeb.Models;
using NorthwindWeb.Services.IServices;

namespace NorthwindWeb.Services
{
	public class EmployeeService : BaseService, IEmployeeService
	{
        private readonly IHttpClientFactory _clientFactory;

        public EmployeeService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllEmployeesAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/Employees",
                AccessToken = ""
            });
        }
    }
}

