using filmapp.entity;
using Microsoft.EntityFrameworkCore;

namespace filmapp.data.Concrete.EfCore
{
    public class FilmSiteContext : DbContext
    {
        public DbSet<Movie> Movies{set;get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=movieDb");
        }
        
    }
}