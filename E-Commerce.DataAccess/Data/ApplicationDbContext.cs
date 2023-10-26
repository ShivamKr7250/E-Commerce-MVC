using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }    

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "SupShiv IT Solution", StreetAddress="Danapur, Khagual", City="Patna", State="Bihar", PostalCode=801105, PhoneNumber="+91-9304961453"},
                new Company { Id = 2, Name = "RF Solutions", StreetAddress = "Dum Dum, Kolata", City = "Kolkata", State = "West Bengal", PostalCode = 700001, PhoneNumber = "+91-9955983347" },
                new Company { Id = 3, Name = "S.K IT Master", StreetAddress = "Amara, Arwal", City = "Arwal", State = "Bihar", PostalCode = 8034505, PhoneNumber = "+91-7250694584" }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodals libero",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 8,
                    ImageUrl =""
                },
                new Product
                {
                    Id = 2,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodals libero",
                    ISBN = "SOTJ111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 9,
                    ImageUrl = ""
                }
                );
        }
    }
}
