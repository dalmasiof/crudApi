using crudApi.C_Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class DataContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Value).HasPrecision(5, 2);
            builder.Entity<PurchaseOrder>().Property(x => x.Discount).HasPrecision(5, 2);
            builder.Entity<PurchaseOrder>().Property(x => x.Total).HasPrecision(5, 2);
            builder.Entity<PurchaseOrder>().Property(x => x.TotalToPay).HasPrecision(5, 2);

            base.OnModelCreating(builder);
        }
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<UserData> users { get; set; }
        public DbSet<PurchaseOrder> purchaseOrders { get; set; }


    }


}