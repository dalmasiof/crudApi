using crudApi.C_Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<UserData> users { get; set; }
        public DbSet<PurchaseOrder> purchaseOrders { get; set; }
        

    }


}