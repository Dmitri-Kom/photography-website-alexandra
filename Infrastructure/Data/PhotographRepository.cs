using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class PhotographRepository : IPhotographRepository
    {
        public Task<Photograph> GetPhotographByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Photograph>> GetPhotographsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}