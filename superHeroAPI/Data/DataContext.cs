using Microsoft.EntityFrameworkCore;

namespace superHeroAPI.Data
{
    public class DataContext : DbContext
    {

         public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }


        // this is our datacontext 
        public DbSet<SuperHero> SuperHeroes{ get; set; }
    }
}
