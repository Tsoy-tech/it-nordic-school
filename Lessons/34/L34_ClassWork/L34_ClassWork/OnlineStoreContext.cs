using L34_ClassWork.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace L34_ClassWork
{
    public class OnlineStoreContext : DbContext
    { 
        public string _connectionString;
        //public static readonly ConsoleLoggerProvider MyLoggerProvider = new IOptionsMonitor();
        //public static readonly LoggerFactory MyConsoleLoggingFactory = LoggerFactory.Create();
           //new LoggerFactory(
           //new[] { MyLoggerProvider});
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OnlineStoreContext()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "OnlineStoreEF";
            builder.DataSource = "WIN-HNJP61VLN18\\SQLEXPRESS";
            builder.IntegratedSecurity = true;

            _connectionString = builder.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
            {
                builder.AddFilter("DbLoggerCategory.Database.Command.Name",
                    LogLevel.Information).AddConsole();
            }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<OrderItem>().HasKey("OrderId", "ProductId").HasName("PK_OrderItem");
        }
    }
}
