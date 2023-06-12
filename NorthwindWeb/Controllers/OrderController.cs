using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthwindWeb.Models;
using NorthwindWeb.Services.IServices;

namespace NorthwindWeb.Controllers
{
	public class OrderController : Controller
	{
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;

        public OrderController(IOrderService orderService,
            IProductService productService,
            ICustomerService customerService,
            IEmployeeService employeeService)
        {
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> OrderIndex()
        {
            List<OrderDto> list = new();
            var response = await _orderService.GetAllOrdersAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> OrderIndex(DateTime orderDate)
        {
            if (ModelState.IsValid)
            {
                List<OrderDto> list = new();
                var response = await _orderService.GetAllOrdersByDateAsync<ResponseDto>(orderDate);
                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<OrderDto>>(Convert.ToString(response.Result));
                }
                ViewData["orderDate"] = orderDate.ToString("yyyy-MM-dd");
                return View(list);
            }
            return View(orderDate);
        }

        public async Task<IActionResult> OrderCreate()
        {
            List<ProductModelDto> listProduct = new();
            var responseProduct = await _productService.GetAllProductsAsync<ResponseDto>();
            if (responseProduct != null && responseProduct.IsSuccess)
            {
                listProduct = JsonConvert.DeserializeObject<List<ProductModelDto>>(Convert.ToString(responseProduct.Result));
            }
            List<CustomerDto> listCustomer = new();
            var responseCustomer = await _customerService.GetAllCustomersAsync<ResponseDto>();
            if (responseCustomer != null && responseCustomer.IsSuccess)
            {
                listCustomer = JsonConvert.DeserializeObject<List<CustomerDto>>(Convert.ToString(responseCustomer.Result));
            }
            List<EmployeeDto> listEmployee = new();
            var responseEmployee = await _employeeService.GetAllEmployeesAsync<ResponseDto>();
            if (responseEmployee != null && responseEmployee.IsSuccess)
            {
                listEmployee = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(responseEmployee.Result));
            }
            ViewData["listProduct"] = listProduct;
            ViewData["listCustomer"] = listCustomer;
            ViewData["listEmployee"] = listEmployee;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderCreate(OrderDto model)
        {
            if (ModelState.IsValid && !model.ListOfProduct.GroupBy(x => x.ProductId).Any(g => g.Count() > 1))
            {
                var response = await _orderService.CreateOrderAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> OrderEdit(int id)
        {
            List<EmployeeDto> listEmployee = new();
            var responseEmployee = await _employeeService.GetAllEmployeesAsync<ResponseDto>();
            if (responseEmployee != null && responseEmployee.IsSuccess)
            {
                listEmployee = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(responseEmployee.Result));
            }
            ViewData["listEmployee"] = listEmployee;
            var response = await _orderService.GetOrderByIdAsync<ResponseDto>(id);
            if (response != null && response.IsSuccess)
            {
                OrderDto model = JsonConvert.DeserializeObject<OrderDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> OrderEdit(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderService.UpdateOrderAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> OrderDelete(int id)
        {
            var response = await _orderService.GetOrderByIdAsync<ResponseDto>(id);
            if (response != null && response.IsSuccess)
            {
                OrderDto model = JsonConvert.DeserializeObject<OrderDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> OrderDelete(OrderDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderService.DeleteOrderAsync<ResponseDto>(model.OrderId);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(OrderIndex));
                }
            }
            return View(model);
        }
    }
}

