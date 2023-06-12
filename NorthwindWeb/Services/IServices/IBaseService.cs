using System;

using NorthwindWeb.Models;

namespace NorthwindWeb.Services.IServices
{
	public interface IBaseService
	{
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}

