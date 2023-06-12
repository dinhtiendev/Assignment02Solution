using System;
namespace NorthwindAPI.Models.DTOs
{
	public class ResponseDto
	{
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}

