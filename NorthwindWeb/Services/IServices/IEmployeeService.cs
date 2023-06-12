using System;
namespace NorthwindWeb.Services.IServices
{
	public interface IEmployeeService
	{
        Task<T> GetAllEmployeesAsync<T>();
    }
}

