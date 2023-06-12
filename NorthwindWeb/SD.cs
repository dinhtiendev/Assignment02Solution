using System;
namespace NorthwindWeb
{
	public static class SD
	{
        public static string OrderAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

