using L34_ClassWork.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace L34_ClassWork
{
    public class OnlineStoreContext : DbContext
    {
        public string _connectionString;
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OnlineStoreContext()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "OnlineStoreEF2";
            builder.DataSource = "WIN-HNJP61VLN18\\SQLEXPRESS";
            builder.IntegratedSecurity = true;

            _connectionString = builder.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasAlternateKey(p => p.Name).HasName("UK_Customer_Name");

            modelBuilder.Entity<OrderItem>().HasKey("OrderId", "ProductId").HasName("PK_OrderItem");
        }
    }
}
