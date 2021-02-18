using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotographsController : ControllerBase
    {
        [HttpGet]
        public string GetPhotographs()
        {
            return "GetPhotographs()";
        }

        [HttpGet("{id}")]
        public string GetPhotograph(int id)
        {
            return "GetPhotograph()";
        }

    }
}