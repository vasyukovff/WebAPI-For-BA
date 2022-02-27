using Microsoft.AspNetCore.Mvc;
using WebAPIForBA.Dto.Department;
using WebAPIForBA.Filters.Actions;
using WebAPIForBA.Orchestrators;

namespace WebAPIForBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly DepartmentOrchestrator _orchestrator;

        public DepartmentController(DepartmentOrchestrator rep)
        {
            _orchestrator = rep;
        }

        [CustomValidationFilter]
        [HttpGet]
        public IActionResult GetAll(int take = 10)
        {
            return Ok(_orchestrator.GetAll(take));
        }

        [HttpPost]
        public IActionResult Add([FromBody] DepartmentCreateDto data)
        {
            var result = _orchestrator.Add(data);

            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

        [HttpPut]
        public IActionResult Update([FromBody] DepartmentUpdateDto data)
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
