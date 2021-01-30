using System;
using System.Collections.Generic;
using System.Text;

namespace L30_ClassWork.Orders
{
    public class OrderDiscount
    {
        public int Id { get; set; }
        public double Discount { get; set; }

        public OrderDiscount() { }
        public OrderDiscount(int id, double discount)
        {
            Id = id;
            Discount = discount;
        }

        public override string ToString()
        {
            return $"ID:\t{Id}\t{Discount:#0 %}";
        }
    }
}
