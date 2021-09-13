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
        public DbSet<UserFake> UserFakes { get; set; }

        

    }


}