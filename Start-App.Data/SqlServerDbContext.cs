using Microsoft.EntityFrameworkCore;
using Start_App.Domains.Entities;

namespace Start_App.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public DbSet<Person> People { get; set; }
    }
}
