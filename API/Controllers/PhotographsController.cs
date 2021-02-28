using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotographsController : ControllerBase
    {
        private readonly PhotographsShopContext _photographsShopContext;
        public PhotographsController(PhotographsShopContext photographsShopContext)
        {
            _photographsShopContext = photographsShopContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Photograph>>> GetPhotographs()
        {
            var photographs = await _photographsShopContext.Photographs.ToListAsync();
            return Ok(photographs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photograph>> GetPhotograph(int id)
        {
            return await _photographsShopContext.Photographs.FindAsync(id);
        }

    }
}