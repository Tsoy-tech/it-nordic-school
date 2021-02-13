using System;
using System.Collections.Generic;

#nullable disable

namespace ScaffoldingExample
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public double? Discount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
