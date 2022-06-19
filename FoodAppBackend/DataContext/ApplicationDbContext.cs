using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace FoodAppBackend.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
