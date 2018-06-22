using Microsoft.EntityFrameworkCore;
//using MySqL.Data.EntityFrameworkCore.Extensions;

namespace SakilaWebServer.Models
{
    public class SakilaDbContext : DbContext {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
        : base(options) { }

        public DbSet<Actor> actor { get; set; }
        // DbSet<T> type properties for other domain models
    }

}