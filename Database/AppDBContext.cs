using Microsoft.EntityFrameworkCore;
using gpsapka.Models;

namespace gpsapka.Database
{
    public class AppDBContext : DbContext //služba pro databázi
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Poloha> polohas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
