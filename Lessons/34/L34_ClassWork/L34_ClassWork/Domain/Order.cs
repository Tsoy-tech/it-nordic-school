using System;
using System.Collections.Generic;
using System.Text;

namespace L34_ClassWork.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Discount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
