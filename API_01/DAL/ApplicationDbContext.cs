using API_01.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API_01.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

    }
}
