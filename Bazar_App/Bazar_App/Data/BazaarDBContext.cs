using Bazar_App.Models;
using Microsoft.EntityFrameworkCore;
using Bazar_App.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Bazar_App.Auth.Models;

namespace Bazar_App.Data
{
    public class BazaarDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BazaarDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Beauty" },
             new Category { Id = 2, Name = "Clothes" },
             new Category { Id = 3, Name = "Mobiles" }
             );

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Liner & Colossal Kajal", Price = 15.5, Description = "Maybelline New York Colossal Bold Liner & Colossal Kajal",ImgUrl= "https://bazartest.blob.core.windows.net/img/Liner.jpg", CategoryId = 1 },
            new Product { Id = 2, Name = "Blushes", Price = 20.00, Description = "URBANMAC Premium Synthetic Kabuki Foundation Face Powder",ImgUrl= "https://bazartest.blob.core.windows.net/img/Blushes.jpg", CategoryId = 1 },
            new Product { Id = 3, Name = "Foundation ", Price = 50.00, Description = "Coloressence Full Coverage Waterproof Lightweight",ImgUrl= "https://bazartest.blob.core.windows.net/img/Foundation.jpg", CategoryId = 1 },
            new Product { Id = 4, Name = "Cotton Born Baby", Price = 15.00, Description = "HIKIPO Presents 100% Cotton Born Baby",ImgUrl= "https://bazartest.blob.core.windows.net/img/CottonBornBaby.jpg", CategoryId = 2 },
            new Product { Id = 5, Name = "Kid's Cotton Combo Pack Of 3 Clothing Set", Price = 243.00, Description = "Babyblossom Baby Kid's Cotton Combo Pack Of 3", ImgUrl= "https://bazartest.blob.core.windows.net/img/Kid'sCottonClothing.jpg", CategoryId = 2 },
            new Product { Id = 6, Name = "Men's Regular Fit T-Shirt", Price = 20.00, Description = "Scott International Men's Regular",ImgUrl= "https://bazartest.blob.core.windows.net/img/Men'sT-Shirt.jpg", CategoryId = 2 },
            new Product { Id = 7, Name = "Oppo A54", Price = 123.00, Description = "Oppo A54 (Starry Blue, 6GB RAM, 128GB Storage)",ImgUrl= "https://bazartest.blob.core.windows.net/img/OppoA54.png", CategoryId = 3 },
            new Product { Id = 8, Name = "Tecno Spark 8 Pro", Price = 432.00, Description = "Tecno Spark 8 Pro (Turquoise Cyan, 7GB Expandable RAM 64GB Storage)",ImgUrl= "https://bazartest.blob.core.windows.net/img/TecnoSpark8Pro.png", CategoryId = 3 }
            );
        }

        //private void SeedRoles(ModelBuilder modelBuilder, string roleName)
        //{
        //    var role = new IdentityRole
        //}
    }
}
