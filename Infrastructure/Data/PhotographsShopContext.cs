using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PhotographsShopContext : DbContext
    {
        private DbSet<Photograph> photographs;

        public PhotographsShopContext(DbContextOptions<PhotographsShopContext> options) : base(options)
        {
        }

        public DbSet<Photograph> Photographs { get; set; }
        public DbSet<PhotographLocation> PhotographLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}