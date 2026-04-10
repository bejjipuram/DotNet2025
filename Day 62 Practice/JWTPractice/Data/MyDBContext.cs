using Microsoft.EntityFrameworkCore;
using JWTPractice.Models;

namespace JWTPractice.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }

    }
}
