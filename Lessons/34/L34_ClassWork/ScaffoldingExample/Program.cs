using System;

namespace ScaffoldingExample
{
    class Program
    {

        static void Main(string[] args)
        {
            OnlineStoreContext dbContext = new OnlineStoreContext();
            foreach(Product p in dbContext.Products)
            {
                Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Price} руб.\t{p.OrderItems.Count}");
            }
        }
    }
}
