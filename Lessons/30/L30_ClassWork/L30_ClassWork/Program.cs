using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using L30_ClassWork.Products;

namespace L30_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = @"WIN-HNJP61VLN18\SQLEXPRESS",
                InitialCatalog = "OnlineStore",
                IntegratedSecurity = true
            };

            var repo = new OnlineStoreRepository(connectionStringBuilder.ConnectionString);
            int productCount = repo.GetProductCount();
            Console.WriteLine($"Number of products = {productCount}");

            var products = repo.GetProductList();
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }

            int orderCount = repo.GetOrderCount();
            Console.WriteLine($"Order counts = {productCount}");

            var orderDiscounts = repo.GetOrderDiscountList();
            foreach (var orderDiscount in orderDiscounts)
            {
                Console.WriteLine(orderDiscount.ToString());
            }

            int newOrderId = repo.AddOrder(4, DateTimeOffset.Now, null,
                new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (20, 1),
                    new Tuple<int, int> (7, 4),
                });
            Console.WriteLine($"New order added with ID = {newOrderId}");

            /*---------------------------------------------------------------------------------------*/

            var newProduct = new ProductRestricted("Новые часы Apple IWatch", 9999.99m);
            int newProductId = repo.AddProduct(newProduct);

            Console.WriteLine($"New product added with ID = {newProductId}");

        }
    }            

}
