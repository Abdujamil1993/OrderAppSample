using Microsoft.AspNetCore.Mvc;
using OrderAppSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAppSample.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly OrderDbContext _dbContext;
        public OrderItemsController(OrderDbContext orderDbContext)
        {
            _dbContext = orderDbContext;
        }
        public IActionResult Index(int orderId)
        {
            var orderItems = _dbContext.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
            ViewBag.OrderId = orderId;
            return View(orderItems);
        }
    }
}
