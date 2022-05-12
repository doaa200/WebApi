using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day1of_WenApi.Model
{
    public class SouqEntity : IdentityDbContext<ApplicationUser>
    {
        public SouqEntity()
        {

        }
        public SouqEntity(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> productss { get; set; }
       

    }
}
