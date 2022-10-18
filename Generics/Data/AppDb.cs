using Generics.Models;
using Microsoft.EntityFrameworkCore;

namespace Generics.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }
        public DbSet<Director> Directors { get; set; }
        public DbSet<People> People { get; set; }
    }
}
