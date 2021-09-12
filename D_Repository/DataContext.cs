using crudApi.C_Domain;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<User> Users { get; set; }

        

    }


}