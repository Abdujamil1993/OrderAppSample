using OrderAppSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAppSample.Specifications
{
    public class OrderWithProviderAndOrderItemsSpec : BaseSpecification<Order>
    {
        public OrderWithProviderAndOrderItemsSpec(OrderSpecParams orderParams)
        : base(x =>
            ((x.Date>=orderParams.StartDate && x.Date <= orderParams.EndDate)) &&
            (string.IsNullOrEmpty(orderParams.Search) || x.Number.ToLower().Contains(orderParams.Search)) &&
            (!orderParams.ProviderId.HasValue || x.ProviderId == orderParams.ProviderId) &&
            (string.IsNullOrEmpty(orderParams.OrderItemSearch) || x.OrderItems.Any(oi =>  oi.Name.ToLower().Contains(orderParams.OrderItemSearch))) &&
            (string.IsNullOrEmpty(orderParams.OrderItemUnit) || x.OrderItems.Any(oi2 => oi2.Unit.ToLower().Contains(orderParams.OrderItemUnit))) &&
            (string.IsNullOrEmpty(orderParams.ProviderName) || x.Provider.Name.ToLower().Contains(orderParams.ProviderName))
        )
        {
        AddInclude(x => x.Provider);
        AddInclude(x => x.OrderItems);
        AddOrderBy(x => x.Date);
}
    }
}
