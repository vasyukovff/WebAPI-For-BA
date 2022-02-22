using Microsoft.AspNetCore.Mvc;
using WebAPIForBA.Dto.Account;
using WebAPIForBA.Orchestrators;

namespace WebAPIForBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly AccountOrchestrator _orchestrator;

        public AccountController(AccountOrchestrator rep)
        {
            _orchestrator = rep;
        }

        [HttpGet]
        public IActionResult GetAll(int take = 10)
        {
            return Ok(_orchestrator.GetAll(take));
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccountCreateDto data)
        {
            var result = _orchestrator.Add(data);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AccountUpdateDto data)
        {
            var result = _orchestrator.Update(data);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _orchestrator.Remove(id);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }
    }
}
