using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Models.Listener> Listeners { get; set; }
        public DbSet<Models.Meetup> Meetups { get; set; }
        public DbSet<Models.Speaker> Speakers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
