using CQRSMediatr.PostgresEFCore;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.DataStore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Server=localhost;Database=testPostgres;Port=5004;User Id=postgres;Password=P@ssw0rd");
    }
}
