using System.Collections.Generic;
using System.Web.Http;
using BrainShark.BrainWare.WebApp.Infrastructure.Services;
using BrainShark.BrainWare.WebApp.Models;

namespace BrainShark.BrainWare.WebApp.Controllers.API
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            return _orderService.GetForCompany(id);
        }
    }
}