using System;
using AutoMapper;
using NorthwindAPI.Models;
using NorthwindAPI.Models.DTOs;

namespace NorthwindAPI
{
	public class MappingConfig
	{
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>()
                    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                    .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => MapDtoToOrderDetails(src.ListOfProduct)));

                config.CreateMap<Order, OrderDto>()
                    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                    .ForMember(dest => dest.ListOfProduct, opt => opt.MapFrom(src => MapOrderDetailsToDto(src.OrderDetails)));

                config.CreateMap<Product, ProductModelDto>()
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

                config.CreateMap<Customer, CustomerDto>()
                    .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));

                config.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            });

            return mappingConfig;
        }

        private static ICollection<OrderDetail> MapDtoToOrderDetails(List<ProductDto> productDtos)
        {
            var orderDetails = new List<OrderDetail>();

            foreach (var productDto in productDtos)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = productDto.ProductId,
                    Quantity = productDto.Quantity,
                    UnitPrice = productDto.UnitPrice.GetValueOrDefault()
                };
                
                orderDetails.Add(orderDetail);
            }

            return orderDetails;
        }

        private static List<ProductDto> MapOrderDetailsToDto(ICollection<OrderDetail> orderDetails)
        {
            var productDtos = new List<ProductDto>();

            foreach (var orderDetail in orderDetails)
            {
                var productDto = new ProductDto
                {
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice
                };
                productDtos.Add(productDto);
            }

            return productDtos;
        }
    }
}

