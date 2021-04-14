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
            return await _photographsShopContext.Photographs.FindAsync(id);
        }

        public async Task<IReadOnlyList<Photograph>> GetPhotographsAsync()
        {
            return await _photographsShopContext.Photographs.ToListAsync();
        }
    }
}