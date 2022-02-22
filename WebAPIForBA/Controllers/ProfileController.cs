using Microsoft.AspNetCore.Mvc;
using WebAPIForBA.Dto.Profile;
using WebAPIForBA.Orchestrators;

namespace WebAPIForBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly ProfileOrchestrator _orchestrator;

        public ProfileController(ProfileOrchestrator rep)
        {
            _orchestrator = rep;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProfileDto dto)
        {
            var result = _orchestrator.Add(dto);

            if(result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int accountId)
        {
            var result = _orchestrator.Get(accountId);

            if (result.IsSuccess)
                return Ok(result.Results);

            return BadRequest(result.ErrorMessage);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProfileDto dto)
        {
            var result = _orchestrator.Update(dto);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }
    }
}
