using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using rsAPI.Data.Entities;
using rsAPI.Data.Entities.Concrete;

namespace rsAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<ilanlar> ilanlar { get; set; }
        public DbSet<Kategori> kategoriler { get; set; }
        public DbSet<daireTip> daireTipleri { get; set; }
    }
}
