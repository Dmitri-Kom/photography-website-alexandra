using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotographsController : ControllerBase
    {
        private readonly IGenericRepository<Photograph> _photographRepository;
        private readonly IGenericRepository<PhotographLocation> _photographLocationRepository;
        public PhotographsController(IGenericRepository<Photograph> photographRepository, 
                                     IGenericRepository<PhotographLocation> photographLocationRepository)
        {
            _photographRepository = photographRepository;
            _photographLocationRepository = photographLocationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Photograph>>> GetPhotographs()
        {
            var spec = new PhotographsWithLocationsSpecification();
            var photographs = await _photographRepository.ListAsync(spec);
            return Ok(photographs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photograph>> GetPhotograph(int id)
        {
            var spec = new PhotographsWithLocationsSpecification(id);
            return await _photographRepository.GetEntityWithSpec(spec);
        }

        [HttpGet("locations")]
        public async Task<ActionResult<IReadOnlyList<PhotographLocation>>> GetPhotographLocations()
        {
            return Ok(await _photographLocationRepository.GetAllAsync());
        }

    }
}