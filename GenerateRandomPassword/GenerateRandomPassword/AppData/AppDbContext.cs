using GenerateRandomPassword.AppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenerateRandomPassword.AppData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
