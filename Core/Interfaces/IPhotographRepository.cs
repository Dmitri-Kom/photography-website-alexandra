using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPhotographRepository
    {
        Task<Photograph> GetPhotographByIdAsync(int id);
        Task<IReadOnlyList<Photograph>> GetPhotographsAsync();
    }
}