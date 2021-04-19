using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
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
        public async Task<ActionResult<List<PhotographToReturnDto>>> GetPhotographs()
        {
            var spec = new PhotographsWithLocationsSpecification();
            var photographs = await _photographRepository.ListAsync(spec);
            return photographs.Select(photograph => new PhotographToReturnDto
            {
                Id = photograph.Id,
                Name = photograph.Name,
                Description = photograph.Description,
                Url = photograph.Url,
                Price = photograph.Price,
                PhotographLocation = photograph.PhotographLocation.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotographToReturnDto>> GetPhotograph(int id)
        {
            var spec = new PhotographsWithLocationsSpecification(id);
            var photograph =  await _photographRepository.GetEntityWithSpec(spec);
            return new PhotographToReturnDto
            {
                Id = photograph.Id,
                Name = photograph.Name,
                Description = photograph.Description,
                Url = photograph.Url,
                Price = photograph.Price,
                PhotographLocation = photograph.PhotographLocation.Name 
            };
       }

        [HttpGet("locations")]
        public async Task<ActionResult<IReadOnlyList<PhotographLocation>>> GetPhotographLocations()
        {
            return Ok(await _photographLocationRepository.GetAllAsync());
        }

    }
}