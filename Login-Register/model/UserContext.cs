using Microsoft.EntityFrameworkCore;

namespace Login_Register.model
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
