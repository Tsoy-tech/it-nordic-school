using System;
using System.Collections.Generic;
using System.Text;

namespace L30_ClassWork.Products
{
    public class ProductRestricted
    {        
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public ProductRestricted() { }
        public ProductRestricted(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }   



}
