using CorrespondenceEF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace CorrespondenceEF
{
    public class CorrespondenceContext : DbContext
    {
        public string _connectionString;
        public DbSet<City> Cities { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PostalItem> PostalItems { get; set; }
        public DbSet<Sending> Sendings { get; set; }
        public DbSet<Status> Statuses { get; set; }


        public CorrespondenceContext()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "CorrespondenceED";
            builder.DataSource = "WIN-HNJP61VLN18\\SQLEXPRESS";
            builder.IntegratedSecurity = true;

            _connectionString = builder.ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
