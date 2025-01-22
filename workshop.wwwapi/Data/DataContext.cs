using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.People);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Course> Courses { get; set; } 
    }
}
