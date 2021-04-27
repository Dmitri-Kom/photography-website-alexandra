using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PhotographsController : BaseApiController
    {
        private readonly IGenericRepository<Photograph> _photographRepository;
        private readonly IGenericRepository<PhotographLocation> _photographLocationRepository;
        private readonly IMapper _mapper;
        public PhotographsController(IGenericRepository<Photograph> photographRepository,
            IGenericRepository<PhotographLocation> photographLocationRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _photographRepository = photographRepository;
            _photographLocationRepository = photographLocationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PhotographToReturnDto>>> GetPhotographs(string sort)
        {
            var spec = new PhotographsWithLocationsSpecification(sort);
            var photographs = await _photographRepository.ListAsync(spec);
            return Ok(_mapper
                .Map<IReadOnlyList<Photograph>, IReadOnlyList<PhotographToReturnDto>>(photographs));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotographToReturnDto>> GetPhotograph(int id)
        {
            var spec = new PhotographsWithLocationsSpecification(id);
            var photograph =  await _photographRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Photograph, PhotographToReturnDto>(photograph);
       }

        [HttpGet("locations")]
        public async Task<ActionResult<IReadOnlyList<PhotographLocation>>> GetPhotographLocations()
        {
            return Ok(await _photographLocationRepository.GetAllAsync());
        }

    }
}