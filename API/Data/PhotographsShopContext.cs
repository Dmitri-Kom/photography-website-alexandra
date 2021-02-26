using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PhotographsShopContext : DbContext
    {
        public PhotographsShopContext(DbContextOptions<PhotographsShopContext> options) : base(options)
        {
        }

        public DbSet<Photograph> Photographs { get; set; }
    }
}