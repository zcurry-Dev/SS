using Microsoft.EntityFrameworkCore;
using SS.API.Models;

namespace SS.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public int MyProperty { get; set; }

        public DbSet<Values> Values { get; set; }
    }
}