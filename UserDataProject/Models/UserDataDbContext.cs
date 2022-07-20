using Microsoft.EntityFrameworkCore;

namespace UserDataProject.Models
{
    public class UserDataDbContext : DbContext
    {
        public UserDataDbContext(DbContextOptions<UserDataDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
