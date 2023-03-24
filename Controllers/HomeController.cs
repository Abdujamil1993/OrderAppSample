using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderAppSample.Models;
using OrderAppSample.Repository;
using OrderAppSample.Specifications;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly OrderDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Order> orderRepo, OrderDbContext orderDbContext)
        {
            _logger = logger;
            _orderRepo = orderRepo;
            _dbContext = orderDbContext;
        }

        public async Task<IActionResult> IndexAsync([FromQuery] OrderSpecParams orderParams)
        {
            var spec = new OrderWithProviderAndOrderItemsSpec(orderParams);
            var products = await _orderRepo.ListAsync(spec);
            var units = _dbContext.OrderItems.Select(t => t.Unit).Distinct();
            ViewBag.Units = units;
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
