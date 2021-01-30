using System;
using System.Collections.Generic;
using System.Text;

namespace L30_ClassWork.Products
{
    public class Product
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 
        public Product() { }
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID:\t{Id}\t{Name.PadRight(70, '.')}\t{Price:0.00} rub.";
        }
    }   



}
