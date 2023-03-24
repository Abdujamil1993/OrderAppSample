using Microsoft.Extensions.Logging;
using OrderAppSample.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderAppSample.SeedData
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Providers.Any())
                {
                    var providersData =
                        File.ReadAllText("SeedData/Providers.json");
                    var providers = JsonSerializer.Deserialize<List<Provider>>(providersData);
                    foreach (var item in providers)
                    {
                        context.Providers.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Orders.Any())
                {
                    var ordersData =
                        File.ReadAllText("SeedData/Orders.json");
                    var orders = JsonSerializer.Deserialize<List<Order>>(ordersData);
                    foreach (var item in orders)
                    {
                        context.Orders.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.OrderItems.Any())
                {
                    var orderItemsData =
                        File.ReadAllText("SeedData/OrderItems.json");
                    var ordersItems = JsonSerializer.Deserialize<List<OrderItem>>(orderItemsData);
                    foreach (var item in ordersItems)
                    {
                        context.OrderItems.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<OrderDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
