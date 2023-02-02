using GameManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Admin> Admin{ get; set; }

    }
}