using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotographsController : ControllerBase
    {
        private readonly IPhotographRepository _photographRepository;
        public PhotographsController(IPhotographRepository photographRepository)
        {
            _photographRepository = photographRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Photograph>>> GetPhotographs()
        {
            var photographs = await _photographRepository.GetPhotographsAsync();
            return Ok(photographs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photograph>> GetPhotograph(int id)
        {
            return await _photographRepository.GetPhotographByIdAsync(id);
        }

    }
}