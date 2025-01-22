using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}
