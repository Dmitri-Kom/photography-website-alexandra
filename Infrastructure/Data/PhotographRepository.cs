using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PhotographRepository : IPhotographRepository
    {
        private readonly PhotographsShopContext _photographsShopContext;
        public PhotographRepository(PhotographsShopContext photographsShopContext)
        {
            _photographsShopContext = photographsShopContext;
        }

        public async Task<Photograph> GetPhotographByIdAsync(int id)
        {
            return await _photographsShopContext.Photographs.Include(p => p.PhotographLocation).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<PhotographLocation>> GetPhotographLocationsAsync()
        {
            return await _photographsShopContext.PhotographLocations.ToListAsync();
        }

        public async Task<IReadOnlyList<Photograph>> GetPhotographsAsync()
        {
            return await _photographsShopContext.Photographs.Include(p => p.PhotographLocation).ToListAsync();
        }
    }
}