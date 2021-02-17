using L34_ClassWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace L34_ClassWork
{
    class Program
    {
        static OnlineStoreContext _context = new OnlineStoreContext();
        static void Main(string[] args)
        {
            InsertCustomers();
            //InsertProducts();
            //CreateOrder();
            //SelectCustomers();
            //MoreQueries("Dasha NOT EXISTS");
            //UpdateCustomers();
            //QueryAndUpdateProductDisconnected();
            DeleteCustomer("Mr. Albet");
        }

        private static void DeleteCustomer(string name)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Name == name);
            
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }

            //_context.Database.ExecuteSqlRaw("DELETE FROM dbo.Customer WHERE Id = 0, 15");
        }

        private static void QueryAndUpdateProductDisconnected()
        {
            var product = _context.Products.First();
            product.Price *= 1.1M;
            //_context.Products.Update(product);


            using (var newContext = new OnlineStoreContext())
            {
                newContext.Products.Update(product);
                newContext.SaveChanges();
            }
        }

        private static void UpdateCustomers()
        {
            var customer = _context.Customers.First();
            customer.Name = "Mr. " + customer.Name;
            _context.SaveChanges();
        }

        private static void MoreQueries(string name)
        {
            /*var allCustomers = _context.Customers.Where(x => x.Name == name);
            foreach (var customer in allCustomers)
            {
                Console.WriteLine($"{customer.Id}| {customer.Name}");
            }*/

            //var customer = _context.Customers.Where(x => x.Name.Contains("a")).OrderBy(x => x.Name).First();
            name = "alb";
            var customer = _context.Customers.Where(x => x.Name.Contains(name)).OrderBy(x => x.Name).First();

            Console.WriteLine(customer);
        }

        private static void SelectCustomers()
        {
            using (var context = new OnlineStoreContext())
            {
                var allCustomers = context.Customers.Skip(1).Take(1).OrderBy(c => c.Id).FirstOrDefault();

                Console.WriteLine(allCustomers.Name);


                /*foreach (var customer in allCustomers)
                {
                    Console.WriteLine(customer.Name);
                }

                var allCustomersLinq = (
                    from c
                    in context.Customers
                    select c.Name
                    );
                foreach (var customer in allCustomersLinq)
                {
                    Console.WriteLine(customer);
                }*/
            }
        }

        private static void CreateOrder(string customerName, List<OrderItem> orederItems)
        {
            using (var context = new OnlineStoreContext())
            {
                context.Add(new Order()
                {
                    Customer = context.Customers.Where(x => x.Name == customerName).FirstOrDefault(),
                    OrderDate = DateTimeOffset.Now,
                    Discount = 0,
                    OrderItems = new List<OrderItem>() { new OrderItem() { Product = new Product() { Name = "SamsungTV", Price = 20000}}}
                }) ;
            
            }
        }

        private static void InsertProducts()
        {
            using (var context = new OnlineStoreContext())
            {
                context.Add(new Product() { Name = "IPhone X", Price = 100});
                context.AddRange(new[] { new Product() { Name = "MacBook Pro", Price = 100 }, new Product() { Name = "IWatch", Price = 200 } });
                context.SaveChanges();
            }
        }

        private static void InsertCustomers()
        {

            using (var context = new OnlineStoreContext())
            {
                context.Customers.Add(new Customer() { Name = "Sheva" });
                context.Add(new Customer() { Name = "Albet" });
                context.AddRange(new[] { new Customer() { Name = "Masha" }, new Customer() { Name = "Dasha" } });
                
                context.SaveChanges();
                //Faster if you use bulkcopy(tempTable)
                //Console.WriteLine($"{customer.Name }{customer.Id }");
            }
        }
    }
}
