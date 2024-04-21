using ASPNET_databases.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ASPNET_databases.DataBase
{
    public class ShopDbContext : IdentityDbContext<User>
    {
         public ShopDbContext() 
        {
            //this.Database.EnsureCreated();    
        }


        public ShopDbContext(DbContextOptions options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    var connStr = "Data Source=DESKTOP-LONMETH\\SQLEXPRESS;Catalog=DonbassShop; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=FalseData";
        //    optionsBuilder.UseSqlServer(connStr);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tank>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Tank>()
                .Property(t => t.Mileage)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Tank>().Property(x => x.Quantity).HasDefaultValue(0);


            modelBuilder.Entity<Class>().HasData(new[]
            {
                new Class() { Id = 1, Name = "Artilery" },
                new Class() { Id = 2, Name = "Light tank" },
                new Class() { Id = 3, Name = "Medium tank" },
                new Class() { Id = 4, Name = "Heavy tank" },
                new Class() { Id = 5, Name = "Anti Air" },
                new Class() { Id = 6, Name = "SAU" },
                new Class() { Id = 7, Name = "Armored Vehicle" }
            });

            modelBuilder.Entity<Tank>().HasData(new[]
            {
                new Tank() { Id = 1, Name = "Mous", ClassId = 4, Mileage = 300000 , Price = 62000000, InStock = true, ImageUrl = "https://static.wikia.nocookie.net/warrior/images/9/99/%D0%9C%D0%B0%D1%83%D1%81.jpg/revision/latest?cb=20161026163157&path-prefix=ru" },
                new Tank() { Id = 2, Name = "FV 4005", ClassId = 6, Mileage = 50000 , Price = 5500000, InStock = true, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIFoboNP10mBMf2M8iP5Oobk33BPO-D8Xnbg&usqp=CAU" },
                new Tank() { Id = 3, Name = "Tiger 2 H", ClassId = 4, Mileage = 1235600 , Price = 3400000, InStock = false, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSd4pM8QXXE0pDnHCzYlFzo00Do0OM-Ji1QTw&usqp=CAU" },
                new Tank() { Id = 4, Name = "M4A3E2", ClassId = 3, Mileage = 230435 , Price = 1800400, InStock = true, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIVy6NiR6fNrBU4hUpEAJ8Rz4M8rKz4B1eVA&usqp=CAU" },
                new Tank() { Id = 5, Name = "Sturer Emil", ClassId = 6, Mileage = 300000 , Price = 650000, InStock = true, ImageUrl = "https://tankhistoria.com/wp-content/uploads/2022/05/Alkett-Factory-March-9th-1942.jpg" },
                new Tank() { Id = 6, Name = "Heavy Gustav", ClassId = 1, Mileage = 350 , Price = 5000000, InStock = false, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHWf6GAXSoEUnSGyN5yErH3cdzeULJv5CIgA&usqp=CAU" }
            });
        }

        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
