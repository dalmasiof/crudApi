using crudApi.C_Domain;
using Microsoft.EntityFrameworkCore;

namespace crudApi.D_Repository
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Value).HasPrecision(7, 2);
            builder.Entity<PurchaseOrder>().Property(x => x.Discount).HasPrecision(5, 2);
            builder.Entity<PurchaseOrder>().Property(x => x.Total).HasPrecision(10, 2);
            builder.Entity<PurchaseOrder>().Property(x => x.TotalToPay).HasPrecision(10, 2);

            var products = new Product[]{
                new Product{Id=1,ImgPath="assets/gopro.jpg",Name="GoPro Camera",Value=750.00M},
                new Product{Id=2,ImgPath="assets/gopro.jpg",Name="GoPro Camera",Value=750.00M},
                new Product{Id=3,ImgPath="assets/headset.jpg",Name="HeadSet",Value=55.50M},
                new Product{Id=4,ImgPath="assets/keyboard.jpg",Name="Keyboard",Value=99.99M},
                new Product{Id=5,ImgPath="assets/laptop.jpg",Name="Laptop",Value=1525.00M},
                new Product{Id=6,ImgPath="assets/mousepad.jpg",Name="MousePad",Value=15.50M},
                new Product{Id=7,ImgPath="assets/webcam.jpg",Name="webcam",Value=100.00M}
            };

            var user = new UserData[]{
                new UserData{AvatarUrl="",Email="admin",Id=1,Name="Ademir",Password="admin"}
            };

            builder.Entity<Product>().HasData(products);
            builder.Entity<UserData>().HasData(user);



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