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

        public DbSet<Photograph> Photographs { get => photographs; set => photographs = value; }
    }
}