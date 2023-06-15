using DotNetCoreSixPractice.Models.MainModel;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreSixPractice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Student> Students { get; set; }
    }
}
