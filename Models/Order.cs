using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAppSample.Models
{
    public class Order : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
